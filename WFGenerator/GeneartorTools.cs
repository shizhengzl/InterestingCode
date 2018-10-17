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

namespace WFGenerator
{
    public partial class GeneartorTools : Form
    {
        public GeneartorTools()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitSystemConfig();
        }

        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        public List<Table> listSelectTalbe = new List<Table>();
        public List<Table> listAllTalbe = new List<Table>();


        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            InitAddressServerTree();
        }

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

        public void RefreshDataBaseAddressTree()
        {
            InitSelectDataTree();
            InitAddressServerTree();
        }

        public void InitSelectDataTree()
        {
            SelectDataTree.Nodes.Clear();

            var selectAddres = listSelectTalbe.GroupBy(x => x.Address).Select(y => y.Key);
            var selectDataBase = listSelectTalbe.GroupBy(x => new { x.Address, x.DataBaseName }).Select(y => y.Key.DataBaseName);
            foreach (var address in selectAddres)
            {
                TreeNode treeNode = new TreeNode() { Name = address, Text = address };

                foreach (var db in selectDataBase)
                {
                    TreeNode treedb = new TreeNode() { Name = db, Text = db };
                    var tables = listSelectTalbe.Where(x => x.Address == address && x.DataBaseName == db).ToList();
                    tables.ForEach(x => treedb.Nodes.Add(new TreeNode() { Name = x.TableName, Text = x.TableName, Tag = x }));
                    treeNode.Nodes.Add(treedb);
                }
                SelectDataTree.Nodes.Add(treeNode);
            }
            SelectDataTree.ExpandAll();

        }

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
                    InitSelectDataTree();
                }
                else
                {

                }
            }
        }

        #endregion

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
                InitSelectDataTree();
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
            InitSelectDataTree();
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
