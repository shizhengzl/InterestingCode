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
        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            var address = sqlite.DataBaseAddresses.ToList();

            foreach (var item in address)
            {
                TreeNode treeNode = new TreeNode(item.Address);
                TreeServer.Nodes.Add(treeNode);
                sh.Init(item);

                foreach (var db in item.DataBases)
                {
                    TreeNode dbNode = new TreeNode(db.DataBaseName);
                    treeNode.Nodes.Add(dbNode);
                    dbNode.Tag = db; 

                    sh.InitTable(db); 
                    foreach (var table in db.Tables)
                    {
                        TreeNode tableNode = new TreeNode(table.TableName);
                        dbNode.Nodes.Add(tableNode);
                    }
                }
            }
        }

        private void TreeServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
          
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(rdLikdSearch.Checked)
            {
                if(rdFilterTable.Checked)
                {

                }
                else
                {

                }
            }

            if(rdFuzzySearch.Checked)
            {
                if (rdFilterTable.Checked)
                {

                }
                else
                {

                }
            }

            if(rdComplete.Checked)
            {
                if (rdFilterTable.Checked)
                {

                }
                else
                {

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
