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

namespace WFGenerator
{
    public partial class GeneartorTools : Form
    {
        public GeneartorTools()
        {
            string text =  System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\Testodac\abc.xml");
            //Core.UsuallyCommon.XmlHelper.ObjectToXMLFile(text, @"D:\Addins\abc.cs", Encoding.UTF8);

            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitSystemConfig();
             
            InitSnippet();

            //InitSelectDataTree();
        }

        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        public List<Table> listSelectTalbe = new List<Table>();
        public List<Table> listAllTalbe = new List<Table>();


        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            InitAddressServerTree();
        }

        #region Snippet
        List<Snippet> listSnippet = new List<Snippet>();
        public void InitSnippet()
        {
            TreeSnippet.Nodes.Clear();

            listSnippet = sqlite.Snippets.ToList();

            var initSnippets = listSnippet.Where(x => x.ParentId == 0);

            foreach (var snippet in initSnippets)
            {
             
                TreeNode treeNode = new TreeNode() {  Name = snippet.Name,Text = snippet.Name,Tag = snippet};
                TreeSnippet.Nodes.Add(treeNode);
                GetChildSnippet(treeNode, snippet);
            }
        }
        public void GetChildSnippet(TreeNode fatherNode,Snippet fatherSnippet )
        {
            var childs = listSnippet.Where(x => x.ParentId == fatherSnippet.Id);
            foreach (var snippet in childs)
            {
                TreeNode treeNode = new TreeNode() { Name = snippet.Name, Text = snippet.Name, Tag = snippet,Checked =(snippet.IsEnabled && !snippet.IsFloder) };
                fatherNode.Nodes.Add(treeNode);

                GetChildSnippet(treeNode, snippet);
            }
        }
        #endregion

        #region SystemConfig

        public void InitSystemConfig()
        {
            InitClass<ConnectionString>();
            InitClass<DataBaseAddress>();
            InitClass<SQLConfig>();
            InitClass<Variable>();
            InitClass<DataTypeConfig>();
            InitClass<Snippet>();
        }

        public void InitClass<T>() where T : class, new()
        {
            var type = typeof(T);
            var className = type.Name;
            TabPage tpclass = new TabPage() { Name = className, Text = className };

            PanelExtension<T> panel = new PanelExtension<T>();
            tpclass.Controls.Add(panel);
            tabControlSet.TabPages.Add(tpclass);
        }
        #endregion
        
        #region DataBaseTree

        //public void RefreshDataBaseAddressTree()
        //{
        //    InitSelectDataBaseTree();
        //    InitAddressServerTree();
        //}


        //TreeNode datasourcetypetree = new TreeNode() { Text = "DataSource" };
        //TreeNode classsourcetypetree = new TreeNode() { Text = "ClassSource" };
        //TreeNode xmlsourcetypetree = new TreeNode() { Text = "XmlSource" };


        //public void InitSelectDataBaseTree()
        //{

        //    datasourcetypetree.Nodes.Clear();

        //    var selectAddres = listSelectTalbe.GroupBy(x => x.Address).Select(y => y.Key);
        //    var selectDataBase = listSelectTalbe.GroupBy(x => new { x.Address, x.DataBaseName }).Select(y => y.Key.DataBaseName);
        //    foreach (var address in selectAddres)
        //    {
        //        TreeNode treeNode = new TreeNode() { Name = address, Text = address };

        //        foreach (var db in selectDataBase)
        //        {
        //            TreeNode treedb = new TreeNode() { Name = db, Text = db };
        //            var tables = listSelectTalbe.Where(x => x.Address == address && x.DataBaseName == db).ToList();
        //            tables.ForEach(x => treedb.Nodes.Add(new TreeNode() { Name = x.TableName, Text = x.TableName, Tag = x }));
        //            treeNode.Nodes.Add(treedb);
        //        }
        //        datasourcetypetree.Nodes.Add(treeNode);
        //    }


        //    SelectDataTree.ExpandAll();
       
        //}

   

        public void InitAddressServerTree()
        {
            listAllTalbe.Clear();
            TreeServer.Nodes.Clear();
            var address = sqlite.DataBaseAddresses.ToList();
            foreach (var item in address)
            {
                TreeNode treeNode = new TreeNode(item.Address);
                TreeServer.Nodes.Add(treeNode);
                try
                {
                    sh.Init(item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    continue;
                }

                foreach (var db in item.DataBases)
                {
                    TreeNode dbNode = new TreeNode(db.DataBaseName);
                    treeNode.Nodes.Add(dbNode);
                    dbNode.Tag = db;

                    // init table
                    sh.InitTable(db);
                    foreach (var table in db.Tables)
                    {
                        TreeNode tableNode = new TreeNode()
                        {
                            Text = table.TableName,
                            Name = table.TableName,
                            Tag = table
                        };
                        dbNode.Nodes.Add(tableNode);
                        listAllTalbe.Add(table);
                    }

                    // init view

                    // init index

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            var context = txtSearch.Text;
            var listdata = StringHelper.GetStringSingleColumn(context);
            if (listdata.Count > 0)
            {
                listSelectTalbe.Clear();

                listSelectTalbe.AddRange(listAllTalbe.Where(x => listdata.Any(y=>y.ToUpper() == x.TableName.ToUpper())).ToList<Table>());
            }

            if (rdLikdSearch.Checked)
            {
                if (rdFilterTable.Checked)
                {

                }
                else
                {

                }
            }

            if (rdFuzzySearch.Checked)
            {
                if (rdFilterTable.Checked)
                {

                }
                else
                {

                }
            }

            if (rdComplete.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    //InitSelectDataBaseTree();
                }
                else
                {

                }
            }
        }
        private void TreeServer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeCheckStatus(e.Node, e.Node.Checked);
                SetNodeStyle(e.Node);
            }
        }

        private void SetNodeCheckStatus(TreeNode tn, bool Checked)
        {
            if (tn == null) return;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                tnChild.Checked = Checked;
                SetNodeCheckStatus(tnChild, Checked);
            }
            var obj = tn.Tag;
            if (obj is Table)
            {
                var table = ((Table)obj);
                if (tn.Checked)
                {
                    if (!listSelectTalbe.Any(x => x.TableName == table.TableName))
                        listSelectTalbe.Add(table);
                }
                else
                {
                    listSelectTalbe.Where(x => x.TableName == table.TableName).ToList().ForEach(x => listSelectTalbe.Remove(x));
                }
                //InitSelectDataBaseTree();
            }
        }

        private void SetNodeStyle(TreeNode Node)
        {
            int nNodeCount = 0;
            if (Node.Nodes.Count != 0)
            {
                foreach (TreeNode tnTemp in Node.Nodes)
                {
                    if (tnTemp.Checked == true)
                        nNodeCount++;
                }

                if (nNodeCount == Node.Nodes.Count)
                {
                    Node.Checked = true;
                    //Node.ExpandAll();
                    Node.ForeColor = Color.Black;
                }
                else if (nNodeCount == 0)
                {
                    Node.Checked = false;
                    //Node.Collapse();
                    Node.ForeColor = Color.Black;
                }
                else
                {
                    Node.Checked = true;
                    Node.ForeColor = Color.Gray;
                }
            }
            //当前节点选择完后，判断父节点的状态，调用此方法递归。  
            if (Node.Parent != null)
                SetNodeStyle(Node.Parent);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listSelectTalbe.Clear();
            //InitSelectDataBaseTree();
        }

        #endregion
        

        private void tabControlSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var choseName = tabControlSource.SelectedTab.Text.ToString().ToLower() ;
        }

        private void btnxmlString_Click(object sender, EventArgs e)
        {
            var xmlString = txtXmlSelect.Text;
            if (string.IsNullOrEmpty(xmlString))
                return; 
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString); 
            InitXmlTree(document); 
        }

        public void InitXmlTree(XmlDocument document)
        {
            TreeViewXML.Nodes.Clear();  
            if(document != null)
            {
                TreeNode root = new TreeNode() {  Text = document.Name};
                TreeViewXML.Nodes.Add(root);
                LoadChild(root, document.ChildNodes);
            }
        }

        public void LoadChild( TreeNode treeNode, XmlNodeList xmlNodes)
        {
            foreach (XmlNode item in xmlNodes)
            { 
                if (item.Attributes != null && item.Attributes.Count > 0)
                {
                    TreeNode attributes = new TreeNode() { Text = "Attributes"};
                
                    foreach (XmlAttribute attribute in item.Attributes)
                    {
                        var attributename = attribute.Name;
                        var attributevalue = attribute.Value;

                        TreeNode attributeNote = new TreeNode() { Text = attributename ,Tag = attribute,ToolTipText = attributevalue };
                        attributes.Nodes.Add(attributeNote);
                    } 
                    treeNode.Nodes.Add(attributes);
                }
                if (item.NodeType != XmlNodeType.Text && item.NodeType != XmlNodeType.Comment)
                {
                    var notename = item.Name;
                    var notevalue = item.InnerText;

                    TreeNode xmlNote = new TreeNode() { Text = notename, Tag = item, ToolTipText = notevalue };

                    treeNode.Nodes.Add(xmlNote);

                    LoadChild(xmlNote, item.ChildNodes);
                } 
            }
        }
    }

    public class ExtenstionClass
    {
        public static List<T> GetList<T>(DefaultSqlite sqlite)
        {
            var tables = FindTable<T>(sqlite);
            var query = (IEnumerable<T>)
                sqlite.GetType().GetProperty(tables).GetValue(sqlite, null);
            return query.ToList<T>();

        }

        public static string FindTable<T>(DefaultSqlite sqlite)
        {
            var metadata = ((IObjectContextAdapter)sqlite).ObjectContext.MetadataWorkspace;

            var tables = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>()
                .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            return tables.FirstOrDefault(x => x.Name == typeof(T).Name).Table;
        }
    }
}
