using Core.UsuallyCommon.DataBase;
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
using VSBussinessExtenstion.DataBaseHelper;

namespace WFGenerator
{
    public partial class SelectTables : Form
    {
        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();

        public Table  table { get; set; }
        public SelectTables(Table _table)
        {
            table = _table;
            InitializeComponent();

            databaseTrees.sqlite = sqlite;
            databaseTrees.sh = sh;
            databaseTrees.ImageList = imageList;
            databaseTrees.treeType = TreeType.DataBase;
            databaseTrees.Refreshs();
        }

      
        private void databaseTrees_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = (TreeNode)e.Node;
            if (treeNode != null)
            {
                table = treeNode.Tag as Table;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
