using Core.UsuallyCommon.DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;
using VSBussinessExtenstion.DataBaseHelper;

namespace WFGenerator.WinfromControl
{
    public class DatabaseTree : TreeView
    {
        public DefaultSqlite sqlite { get; set; }
        public ServicesAddressHelper sh { get; set; }
        public List<Snippet> listSnippet { get; set; }
        public TreeType treeType { get; set; }

        public List<TreeNode> listSelect = new List<TreeNode>();
        public DatabaseTree()
        {
            this.CheckBoxes = true;
            this.AfterCheck += DatabaseTree_AfterCheck;
            this.BeforeExpand += DatabaseTree_BeforeExpand;
        }

        private void DatabaseTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (treeType == TreeType.DataBase)
            {
                var dbNote = (e.Node as TreeNode);
                if (!(dbNote.Tag != null))
                    return;
              
                if (dbNote.Tag is Core.UsuallyCommon.DataBase.Table)
                { 
                    var table = dbNote.Tag as Core.UsuallyCommon.DataBase.Table;
                    sh.InitColumn(table);
                    dbNote.Nodes.Clear();
                    foreach (var column in table.Columns)
                    {
                        TreeNode columnNode = new TreeNode()
                        {
                            Text = column.ColumnName,
                            SelectedImageIndex = (int)ImageEnum.Table,  
                            ImageIndex = (int)ImageEnum.Table,
                            Tag = column
                        };
                        dbNote.Nodes.Add(columnNode);
                    }
                }
            }
        }

        private void DatabaseTree_AfterCheck(object sender, TreeViewEventArgs e)
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

            GetCheckNode(tn, Checked);
        }

        public void GetCheckNode(TreeNode tn,bool Checked)
        {
            var table = tn.Tag as Table;
            if (table == null)
                return;
            if (table.GetType().Name == typeof(Table).Name)
            {
                if (Checked)
                {
                    if (!listSelect.Any(x => x.Equals(tn)))
                        listSelect.Add(tn);
                }
                else
                {
                    if (listSelect.Any(x => x.Equals(tn.Tag)))
                        listSelect.Remove(tn);
                }
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
            {
                SetNodeStyle(Node.Parent);
                GetCheckNode(Node, Node.Checked);
            }
        }


        public override void Refresh()
        {
            this.Nodes.Clear();
            this.listSelect.Clear();
            switch (treeType)
            {
                case TreeType.DataBase:
                    LoadDataBase();
                    break;
                case TreeType.Snippte:
                    LoadSnippet();
                    this.ExpandAll();
                    break;
            }

           
        }

        public void LoadSnippet()
        {
            listSnippet = sqlite.Snippets.ToList();

            var initSnippets = listSnippet.Where(x => x.ParentId == 0);

            foreach (var snippet in initSnippets)
            {
                TreeNode treeNode = new TreeNode()
                {
                    Name = snippet.Name,
                    Text = snippet.Name,
                    SelectedImageIndex = (int)ImageEnum.Folder,
                    ImageIndex = (int)ImageEnum.Folder,
                    Tag = snippet
                };
                this.Nodes.Add(treeNode);
                GetChildSnippet(treeNode, snippet);
            }
        }
        public void GetChildSnippet(TreeNode fatherNode, Snippet fatherSnippet)
        {
            var childs = listSnippet.Where(x => x.ParentId == fatherSnippet.Id);
            foreach (var snippet in childs)
            {
                TreeNode treeNode = new TreeNode()
                {
                    Name = snippet.Name,
                    Text = snippet.Name,
                    Tag = snippet,
                    SelectedImageIndex = snippet.IsFloder
                        ? (int)ImageEnum.Folder : (snippet.IsEnabled ? (int)ImageEnum.Ok : (int)ImageEnum.Error),
                    ImageIndex = snippet.IsFloder
                        ? (int)ImageEnum.Folder : (snippet.IsEnabled ? (int)ImageEnum.Ok : (int)ImageEnum.Error)
                };
                fatherNode.Nodes.Add(treeNode);
                GetChildSnippet(treeNode, snippet);
            }
        }
        public void LoadDataBase()
        {
            var address = sqlite.DataBaseAddresses.ToList();
            foreach (var item in address)
            {
                TreeNode treeNode = new TreeNode(item.Address);
                treeNode.ImageIndex = (int)ImageEnum.Server;
                treeNode.SelectedImageIndex = (int)ImageEnum.Server;
                this.Nodes.Add(treeNode);
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
                    dbNode.ImageIndex = (int)ImageEnum.Database;
                    dbNode.SelectedImageIndex = (int)ImageEnum.Database;
                    treeNode.Nodes.Add(dbNode);
                    dbNode.Tag = db;

                    // init table
                    sh.InitTable(db);
                    foreach (var table in db.Tables)
                    {
                        TreeNode tableNode = new TreeNode()
                        {
                            ImageIndex = (int)ImageEnum.Table,
                            SelectedImageIndex = (int)ImageEnum.Table,
                            Text = table.TableName,
                            Name = table.TableName,
                            Tag = table
                        };

                        tableNode.Nodes.Add(string.Empty);

                        dbNode.Nodes.Add(tableNode);
                    }

                    // init view

                    // init index

                }
            }
        }
    }
}
