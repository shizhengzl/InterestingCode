using Core.UsuallyCommon;
using Core.UsuallyCommon.DataBase;
using EnvDTE;
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

        public Table table { get; set; }
        public SelectTables(Table _table)
        {
            table = _table;
      
            InitializeComponent();
            ComPath.ValueMember = "Path";
            ComPath.DisplayMember = "Name";
            databaseTrees.sqlite = sqlite;
            databaseTrees.sh = sh;
            databaseTrees.ImageList = imageList;
            databaseTrees.treeType = TreeType.DataBase;
            databaseTrees.Refreshs();


            ComPath.Items.Clear();
            List<Projectitems> list = new List<Projectitems>();
            if (ApplicationVsHelper._applicationObject != null)
            {
                foreach (Project project in ApplicationVsHelper._applicationObject.Solution.Projects)
                {
                    if (project.FullName.IndexOf(".exe") > 0)
                        continue;
                    list.Add(new Projectitems() { Name = project.Name, Path = project.FullName.Replace(project.Name + ".csproj", string.Empty) });
                }
            }
            ComPath.DataSource = list;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
             
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAsy_Click(object sender, EventArgs e)
        {
            try
            {
                var path = txtPath.Text;
                if (!string.IsNullOrEmpty(path))
                {
                    var enums = ClassHelper.GetEnums(txtPath.Text);
                    var cb = enums.Select(x => x.Name).ToArray();
                    comEnum.Items.Clear();
                    comEnum.Items.AddRange(cb);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
               
        }

        public class Projectitems
        {
            public string Path { get; set; }

            public string Name { get; set; }
        }

        private void ComPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            var path = cb.SelectedValue.ToString();
            if(!string.IsNullOrEmpty(path))
            {
                txtPath.Text = path + "bin";
            }
        }
    }
}
