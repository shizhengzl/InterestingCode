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

namespace WFGenerator
{
    public partial class GeneartorTools : Form
    {
        public GeneartorTools()
        {
            InitializeComponent();
        }

        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            var address = sqlite.DataBaseAddresss.ToList();
          
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
                    dbNode.Nodes.Add(string.Empty);
                }
            }
        }

        private void TreeServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var dbNote = (e.Node as TreeNode);
            if (!(dbNote.Tag != null && dbNote.Tag is Core.UsuallyCommon.DataBase.DataBase))
                return;
            var db = dbNote.Tag as Core.UsuallyCommon.DataBase.DataBase;
            sh.InitTable(db);
            dbNote.Nodes.Clear();
            foreach (var table in db.Tables)
            {
                TreeNode tableNode = new TreeNode(table.TableName);
                dbNote.Nodes.Add(tableNode); 
            }
        }
    }
}
