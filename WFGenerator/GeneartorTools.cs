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
            ServerTree.sqlite = sqlite;
            ServerTree.sh = sh;
            ServerTree.ImageList = imageList;
            ServerTree.treeType = TreeType.DataBase;
            ServerTree.Refresh();

            SnippetTree.sqlite = sqlite;
            SnippetTree.CheckBoxes = false;
            SnippetTree.ImageList = imageList;
            SnippetTree.treeType = TreeType.Snippte;
            SnippetTree.Refresh();
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

            var context = txtSearch.Text;
            var listdata = StringHelper.GetStringSingleColumn(context);
            if (listdata.Count > 0)
            {
                listSelectTalbe.Clear();

                listSelectTalbe.AddRange(listAllTalbe.Where(x => listdata.Any(y => y.ToUpper() == x.TableName.ToUpper())).ToList<Table>());
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
   

        private void btnClear_Click(object sender, EventArgs e)
        {
            
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
            if (document != null)
            {
                TreeNode root = new TreeNode() { Text = document.Name };
                TreeViewXML.Nodes.Add(root);
                LoadChild(root, document.ChildNodes);
            }
        }

        public void LoadChild(TreeNode treeNode, XmlNodeList xmlNodes)
        {
            foreach (XmlNode item in xmlNodes)
            {
                if (item.Attributes != null && item.Attributes.Count > 0)
                {
                    TreeNode attributes = new TreeNode() { Text = "Attributes" };

                    foreach (XmlAttribute attribute in item.Attributes)
                    {
                        var attributename = attribute.Name;
                        var attributevalue = attribute.Value;

                        TreeNode attributeNote = new TreeNode() { Text = attributename, Tag = attribute, ToolTipText = attributevalue };
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
