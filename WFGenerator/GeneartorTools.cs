using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;
using System.Data.Entity;
using System.Linq.Expressions;
using VSBussinessExtenstion.DataBaseHelper;
using Core.UsuallyCommon.DataBase;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using Core.UsuallyCommon;
using System.Reflection;
using System.Xml;
using EnvDTE80;
using NLog;

namespace WFGenerator
{

    public enum FunctionMode
    {
        SQLGenerator = 0,
        String = 1,
        SQLCompare = 2,
        SystemConfig = 3
    }
    public partial class GeneartorTools : Form
    {
        //实例化Logger对象，默认logger的名称是当前类的名称（包括类所在的命名空间名称）
        Logger logger = LogManager.GetLogger("NLogs");
        public GeneartorTools(DTE2 applicationObject = null)
        {
            ApplicationVsHelper._applicationObject = applicationObject;
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitSystemConfig();
        }

        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            ServerTree.sqlite = sqlite;
            ServerTree.sh = sh;
            ServerTree.ImageList = imageList;
            ServerTree.treeType = TreeType.DataBase;
            ServerTree.Refreshs();

            SnippetTree.sqlite = sqlite;
            SnippetTree.CheckBoxes = false;
            SnippetTree.ImageList = imageList;
            SnippetTree.treeType = TreeType.Snippte;
            SnippetTree.Refreshs();

            ClassTree.ImageList = imageList;
            ClassTree.treeType = TreeType.Class;

            generatorClass = new GeneratorClass(this.tsmessage);
        }

        #region Variabled 
        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        public List<Table> listAllTalbe = new List<Table>();
        public GeneratorClass generatorClass { get; set; }
        #endregion

        #region SystemConfig
        
        public void InitSystemConfig()
        { 
            InitClass<DataBaseAddress>();
            InitClass<SQLConfig>();
            InitClass<Variable>();
            InitClass<DataTypeConfig>();
            InitClass<Snippet>();
            InitClass<Intellisence>();
            InitClass<Core.UsuallyCommon.DataBase.Control>();
            InitClass<CodeAppend>();
        }

        public void InitClass<T>() where T : class, new()
        {
            var type = typeof(T);
            var className = type.Name;
            TabPage tpclass = new TabPage() { Name = className, Text = className };

            PanelExtension<T> panel = new PanelExtension<T>(this);
            tpclass.Controls.Add(panel);
            tabControlSet.TabPages.Add(tpclass);
        }
        #endregion 

        #region Filter 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var context = txtSearch.Text;
            var listdata = StringHelper.GetStringSingleColumn(context);
            SelectDataSoruceType selecttype = Core.UsuallyCommon.Extensions.EnumParse<SelectDataSoruceType>(tabControlSelect.SelectedIndex.ToString());

            if (listdata.Count == 0)
                return;

            if (rdLikdSearch.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata, SearchType.LikeSearch);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }

            if (rdFuzzySearch.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata, SearchType.FuzzySearch);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }

            if (rdComplete.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata, SearchType.Complete);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Generator 
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            ServerTree.Refreshs();
            SnippetTree.Refreshs();
        }

        private void tGenerator_Click(object sender, EventArgs e)
        {
            // 获取所有启用的模板 判断启用类型
            SelectDataSoruceType selecttype = Core.UsuallyCommon.Extensions.EnumParse<SelectDataSoruceType>(tabControlSelect.SelectedIndex.ToString());
            var listNode = sqlite.Snippets.Where(x=>x.IsEnabled).ToList();
            foreach (Snippet snippet in listNode)
            {
                if (!snippet.IsFloder && snippet.IsEnabled)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            List<TreeNode> listsource = ServerTree.listSelect as List<TreeNode>;
                            tmessages.Text = string.Empty;
                            listsource.ForEach(x =>
                            {
                                var table = x.Tag as Table;
                                sh.InitColumn(table);
                                StringBuilder sb = new StringBuilder();
                                txtGenerator.Text = generatorClass.GetGenerator(snippet,table,ref sb,false); 
                                tmessages.AppendText(sb.ToString());
                            });
                           
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
            } 
        }

        private void SnippetTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var snippet = e.Node.Tag as Snippet;
            if (snippet.IsFloder)
                return;
           
            ShowText(snippet); 

        }

        public void ShowText(Snippet snippet)
        {
            txtGenerator.Text = string.Empty;
            SelectDataSoruceType selecttype = Core.UsuallyCommon.Extensions.EnumParse<SelectDataSoruceType>(tabControlSelect.SelectedIndex.ToString());

            switch (selecttype)
            {
                case SelectDataSoruceType.DataBase:
                    if (snippet.DataSourceType == DataSourceType.DatabaseType)
                    {
                        List<TreeNode> listsource = ServerTree.listSelect as List<TreeNode>; 
                        if(listsource.FirstOrDefault() == null)
                        {
                            txtGenerator.Text = "请选择表";
                            return;
                        }
                        var table = listsource.FirstOrDefault().Tag as Table;
                        sh.InitColumn(table);
                        StringBuilder sb = new StringBuilder();
                        txtGenerator.Text = generatorClass.GetGenerator(snippet, table, ref sb,true); 
                        tmessages.Text = sb.ToString();  
                    } 
                    break;
                case SelectDataSoruceType.Class:
                    //if (snippet.DataSourceType == DataSourceType.CSharpType)
                    //    txtGenerator.AppendText(generatorClass.GetGenerator(snippet, ClassTree.listSelect));
                    break;
                case SelectDataSoruceType.XML:
                    break;
            }
        }
 
        private void txtXmlSelect_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.txtXmlSelect.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtXmlSelect_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            var context = Core.UsuallyCommon.IoHelper.FileReader(path);

            txtXmlSelect.Text = context;

            //还原鼠标形状        
            this.txtXmlSelect.Cursor = System.Windows.Forms.Cursors.IBeam;

            if (!string.IsNullOrEmpty(context))
            {
                GeneratorClass(context);
            }
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXmlSelect.Text))
            {
                return;
            }
            GeneratorClass(txtXmlSelect.Text);
        }

        private void GeneratorClass(string context)
        {
            CSharpParser cSharpParser = new CSharpParser(context);
            try
            {
                ClassTree.Refreshs(null, 0, cSharpParser.GetClass());
                tabControlSelect.SelectedIndex = (int)SelectDataSoruceType.Class;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

        } 

        private void tabControlALL_SelectedIndexChanged(object sender, EventArgs e)
        {
            FunctionMode mode = Core.UsuallyCommon.Extensions.EnumParse<FunctionMode>(tabControlALL.SelectedIndex.ToString());
            switch (mode)
            {
                case FunctionMode.SQLCompare:
                    LoadSQLCompare();
                    break;
            }
        }
        #endregion

        #region SQLCompare

        public bool IsLoadCompare = false;
        public void LoadSQLCompare()
        {
            if (!IsLoadCompare)
            { 
                comSource.Items.Add(string.Empty);
                comTraget.Items.Add(string.Empty);
                comSourceDatabase.Items.Add(string.Empty);
                comTragetDatabase.Items.Add(string.Empty);
                sqlite.DataBaseAddresses.ToList().ForEach(x => comSource.Items.Add(x.Address));
                sqlite.DataBaseAddresses.ToList().ForEach(x => comTraget.Items.Add(x.Address));

                DataBaseSearch.sqlite = sqlite;
                DataBaseSearch.sh = sh;
                DataBaseSearch.ImageList = imageList;
                DataBaseSearch.treeType = TreeType.DataBase; 
            }
        }

        private void comSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var addresses = comSource.Text;
            if(!string.IsNullOrEmpty(addresses))
            {
                comSourceDatabase.Items.Clear();
                comSourceDatabase.Items.Add(string.Empty);
                // load db
                // load db
                var baseaddress = sqlite.DataBaseAddresses.Where(x => x.Address == addresses).ToList();
                foreach (var item in baseaddress)
                {
                    sh.InitDatabase(item);
                    item.DataBases.ForEach(x => comSourceDatabase.Items.Add(x.DataBaseName));
                }
            }
        }

        private void comTraget_SelectedIndexChanged(object sender, EventArgs e)
        {
            var addresses = comTraget.Text;
            if (!string.IsNullOrEmpty(addresses))
            {

                comTragetDatabase.Items.Clear();
                comTragetDatabase.Items.Add(string.Empty);
                // load db
                var baseaddress = sqlite.DataBaseAddresses.Where(x=>x.Address == addresses).ToList();
                foreach (var item in baseaddress)
                {
                    sh.InitDatabase(item);
                    item.DataBases.ForEach(x => comTragetDatabase.Items.Add(x.DataBaseName));
                } 
            }
        }


        private void comSourceDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            var databases = comSourceDatabase.Text;
            var addresses = comSource.Text;
            if (!string.IsNullOrEmpty(databases))
            {
                DataBaseSearch.Refreshs(null, 0,  null, addresses,databases);
            }
        }

        private void comTragetDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            var context = textSearch.Text;
            var databases = comSourceDatabase.Text;
            var addresses = comSource.Text;
            if (!string.IsNullOrEmpty(context) && !string.IsNullOrEmpty(addresses) && !string.IsNullOrEmpty(databases))
            {
                var listdata = StringHelper.GetStringSingleColumn(context);
                DataBaseSearch.listSelect.Clear();
                DataBaseSearch.Refreshs(listdata, SearchType.LikeSearch,null, addresses, databases);
            }
         
        }
        private void btnComplete_Click(object sender, EventArgs e)
        {
            var context = textSearch.Text;
            var databases = comSourceDatabase.Text;
            var addresses = comSource.Text;
            if (!string.IsNullOrEmpty(context) && !string.IsNullOrEmpty(addresses) && !string.IsNullOrEmpty(databases))
            {
                var listdata = StringHelper.GetStringSingleColumn(context);
                DataBaseSearch.listSelect.Clear();
                DataBaseSearch.Refreshs(listdata, SearchType.Complete, null, addresses, databases);
            } 
        }

        private void btnFuzzy_Click(object sender, EventArgs e)
        {
            var context = textSearch.Text;
            var databases = comSourceDatabase.Text;
            var addresses = comSource.Text;
            if (!string.IsNullOrEmpty(context) && !string.IsNullOrEmpty(addresses) && !string.IsNullOrEmpty(databases))
            {
                var listdata = StringHelper.GetStringSingleColumn(context);
                DataBaseSearch.listSelect.Clear();
                DataBaseSearch.Refreshs(listdata, SearchType.FuzzySearch, null, addresses, databases);
            }
        } 

        private void btnExportSQL_Click(object sender, EventArgs e)
        {
            var source = comSource.Text;
            var sourceDatabase = comSourceDatabase.Text;

            var target = comTraget.Text;
            var tragetDatabase = comTragetDatabase.Text;

            var sourcedb = InitBase(source, sourceDatabase);
            var tragetdb = InitBase(target, tragetDatabase);

            var listsourcecolumns = sourcedb.DataBases.FirstOrDefault().Tables.SelectMany(x => x.Columns);

            var listtargetcolumns = tragetdb.DataBases.FirstOrDefault().Tables.SelectMany(x => x.Columns);

            var query = from sources in listsourcecolumns
                        join targets in listtargetcolumns
                        on new { sources.TableName, sources.ColumnName, sources.SQLType }
                        equals new { targets.TableName, targets.ColumnName, targets.SQLType }
                        select sources;

            var columns = query.ToList<Column>();
            var groups = columns.GroupBy(x => x.TableName).Select(y => y.Key);

            StringBuilder sb = new StringBuilder();
            foreach (var group in groups)
            {
                var columnstring = GetColumns(columns.Where(x => x.TableName == group).ToList());
                sb.AppendLine($"INSERT INTO {group} ({columnstring}) SELECT {columnstring} FROM [{target}].[{tragetdb.DataBases.FirstOrDefault().DataBaseName}].dbo.[{group}]");
                sb.AppendLine();
                sb.AppendLine();
            }

            txtExportSQL.Text = sb.ToString();
            MessageBox.Show("执行完成!");
        }

        public string GetColumns(List<Column> columns)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var column in columns)
            {
                if(string.IsNullOrEmpty(sb.ToString()))
                {
                    sb.Append(column.ColumnName);
                }
                else
                {
                    sb.Append($",{column.ColumnName}");
                }
            }
            return sb.ToString();
        }

        public string GetMaxLenghtColumns(List<Column> columns,DataBaseAddress tragetDataBase)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var column in columns)
            {
                sb.Append($"SELECT '[{tragetDataBase.DataBases.FirstOrDefault().DataBaseName}].dbo.[{column.TableName}].[{column.ColumnName}] 长度过长' FROM [{tragetDataBase.Address}].[{tragetDataBase.DataBases.FirstOrDefault().DataBaseName}].dbo.[{column.TableName}] WHERE DATALENGTH({column.ColumnName}) > {column.MaxLength}");
            }
            return sb.ToString();
        }

        public DataBaseAddress InitBase(string source,string sourceDatabase)
        {
            var listtable = GetSelectTables();

            var sourdeAddress = sqlite.DataBaseAddresses.FirstOrDefault(x => x.Address == source && x.DefaultDatabase == sourceDatabase);
            sh.InitDatabase(sourdeAddress);
            var sourcedatabase = sourdeAddress.DataBases.FirstOrDefault(x => x.DataBaseName == sourceDatabase);
            sh.InitTable(sourcedatabase);
            sourcedatabase.Tables = sourcedatabase.Tables.Where(x => listtable.Contains(x.TableName)).ToList();
            sourcedatabase.Tables.ForEach(x => sh.InitColumn(x));

            return sourdeAddress;
        }

        public List<string> GetSelectTables()
        {
            var listsource = DataBaseSearch.listSelect;
            List<string> listtable = new List<string>();
            foreach (TreeNode note in listsource)
            {
                if(note.Tag is Table)
                {
                    var table = note.Tag as Table;
                    listtable.Add(table.TableName);
                }
            }
            return listtable;
        }

        private void btnCheckSQL_Click(object sender, EventArgs e)
        {
            var source = comSource.Text;
            var sourceDatabase = comSourceDatabase.Text;

            var target = comTraget.Text;
            var tragetDatabase = comTragetDatabase.Text;

            var sourcedb = InitBase(source, sourceDatabase);
            var tragetdb = InitBase(target, tragetDatabase);

            var listsourcecolumns = sourcedb.DataBases.FirstOrDefault().Tables.SelectMany(x => x.Columns);

            var listtargetcolumns = tragetdb.DataBases.FirstOrDefault().Tables.SelectMany(x => x.Columns);

            var query = from sources in listsourcecolumns
                        join targets in listtargetcolumns
                        on new { sources.TableName, sources.ColumnName, sources.SQLType }
                        equals new { targets.TableName, targets.ColumnName, targets.SQLType }
                        where sources.MaxLength < targets.MaxLength
                        select sources;

            var columns = query.ToList<Column>();
            var groups = columns.GroupBy(x => x.TableName).Select(y => y.Key);

            StringBuilder sb = new StringBuilder();
            foreach (var group in groups)
            {
                var columnstring = GetMaxLenghtColumns(columns.Where(x => x.TableName == group).ToList(), tragetdb);
                sb.AppendLine(columnstring);
                sb.AppendLine();
                sb.AppendLine();
            } 
            txtExportSQL.Text = sb.ToString();
            MessageBox.Show("执行完成!");
        }
        #endregion

        private void CMS启用_Click(object sender, EventArgs e)
        {
            if (SnippetTree.SelectedNode != null)
            {
                Snippet snippet = (Snippet)SnippetTree.SelectedNode.Tag;
                List<Snippet> listEnabled = new List<Snippet>();
                GetChildSnippet(snippet, ref listEnabled);
                foreach (Snippet sp in listEnabled)
                    sqlite.Snippets.FirstOrDefault(x => x.Id == sp.Id).IsEnabled = true;
                sqlite.SaveChanges();
                SnippetTree.Refreshs();
            }
        }

        public List<Snippet> GetChildSnippet(Snippet sp, ref List<Snippet> list)
        {
            list.Add(sp);
            List<Snippet> childList = sqlite.Snippets.Where(x => x.ParentId == sp.Id).ToList();
            foreach (Snippet s in childList)
            {
                GetChildSnippet(s, ref list);
            }
            return list;
        }

        private void CMS禁用_Click(object sender, EventArgs e)
        {
            if (SnippetTree.SelectedNode != null)
            {
                Snippet snippet = (Snippet)SnippetTree.SelectedNode.Tag;
                List<Snippet> listEnabled = new List<Snippet>();
                GetChildSnippet(snippet, ref listEnabled);
                foreach (Snippet sp in listEnabled)
                    sqlite.Snippets.FirstOrDefault(x => x.Id == sp.Id).IsEnabled = false;
                sqlite.SaveChanges();
                SnippetTree.Refreshs();
            }
        }

        private void CMS删除_Click(object sender, EventArgs e)
        {
            if (SnippetTree.SelectedNode != null)
            {
                Snippet snippet = (Snippet)SnippetTree.SelectedNode.Tag;
                List<Snippet> listDelete = new List<Snippet>();
                GetChildSnippet(snippet, ref listDelete);
                listDelete.ForEach(x => sqlite.Snippets.Remove(sqlite.Snippets.FirstOrDefault(y=>y.Id == x.Id)));
                 
            }
         }

        private void CMS看生成代码_Click(object sender, EventArgs e)
        {
            if (SnippetTree.SelectedNode != null)
            {
                Snippet snippet = (Snippet)SnippetTree.SelectedNode.Tag;
                if(!snippet.IsFloder)
                {
                    ShowText(snippet);
                }
            }
        }

        private void SnippetTree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = SnippetTree.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                SnippetTree.SelectedNode = node;
                Snippet sp = (Snippet)node.Tag;
                this.CMS新建模板.Visible = sp.IsFloder;
            }
            else
                this.CMS新建模板.Visible = false;
        }

        private void CMS新建模板_Click(object sender, EventArgs e)
        { 
            Snippet sp = (Snippet)SnippetTree.SelectedNode.Tag;

            SetSnippet ss = new SetSnippet(null, sp);
            ss.ShowDialog();
            SnippetTree.Refreshs();
        }

        private void CMS修改_Click(object sender, EventArgs e)
        {
            Snippet sp = (Snippet)SnippetTree.SelectedNode.Tag;
            Snippet parent = null;
            var parentNote = SnippetTree.SelectedNode.Parent;
            if (parentNote != null)
                parent = (Snippet)parentNote.Tag;
            SetSnippet ss = new SetSnippet(sp, parent);
            ss.ShowDialog();
            SnippetTree.Refreshs();
        }
    }

    public class ExtenstionClass
    {
        public static List<T> GetList<T>(DefaultSqlite sqlite)
        {
            var tables = FindTable<T>(sqlite);
            IEnumerable<T> query;
            try
            {
                query = (IEnumerable<T>)
                sqlite.GetType().GetProperty(tables ).GetValue(sqlite, null);
            }
            catch (Exception)
            {
                query = (IEnumerable<T>)
                 sqlite.GetType().GetProperty(typeof(T).Name).GetValue(sqlite, null);
            }
            return query.ToList<T>();

        }

        public static string FindTable<T>(DefaultSqlite sqlite)
        {
            var metadata = ((IObjectContextAdapter)sqlite).ObjectContext.MetadataWorkspace;

            var res = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>();
            var tables = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>()
                .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            return sqlite.GetType().GetProperties().Where(x => x.Name.Contains(typeof(T).Name)).FirstOrDefault().Name;
            //return tables.FirstOrDefault(x => x.Name.Contains == typeof(T).Name).Table;
        }
    }
}
