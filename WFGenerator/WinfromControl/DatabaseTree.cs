using Core.UsuallyCommon;
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

        public SelectDataSoruceType selectDataSoruceType { get; set; }

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

        public void GetCheckNode(TreeNode tn, bool Checked)
        {
            dynamic table = tn.Tag as Table;
            if (table == null)
                table = tn.Tag as Method;
            if (table == null)
                table = tn.Tag as Proterty;
            if (table == null) 
                return;
            if (table.GetType().Name == typeof(Table).Name || table.GetType().Name == typeof(Method).Name
                || table.GetType().Name == typeof(Core.UsuallyCommon.Proterty).Name)
            {
                if (Checked)
                {
                    if (!listSelect.Any(x => x.Equals(tn)))
                        listSelect.Add(tn);
                }
                else
                {
                    var name = string.Empty;
                    if (tn.Tag is Table)
                        name = ((Table)tn.Tag).TableName;
                    if (tn.Tag is Method)
                        name = ((Method)tn.Tag).MethodName;
                    if (tn.Tag is Proterty)
                        name = ((Proterty)tn.Tag).PropertyName;
                    if (listSelect.Any(x => x.Name == name))
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


        public void Refreshs(List<string> list = null,SearchType searchType = 0, object objects = null,string addresses = "",string databases= "")
        {
            this.Nodes.Clear();
            this.listSelect.Clear();
            switch (treeType)
            {
                case TreeType.DataBase:
                    LoadDataBase(list, searchType, addresses,databases);
                    break;
                case TreeType.Snippte:
                    LoadSnippet();
                    this.ExpandAll();
                    break;
                case TreeType.Class:
                    LoadClass(objects);
                    this.ExpandAll();
                    break;
            }
        }

        public void LoadClass(object objects)
        {
            List<Classs> classses = (List<Classs>)objects;

            TreeNode namespaces = new TreeNode();

            if(classses.Count > 0){
                namespaces.Text = classses.FirstOrDefault().NameSpace;
                this.Nodes.Add(namespaces);
            }

            foreach (Classs item in classses)
            {
                TreeNode classnote = new TreeNode()
                {
                    Name = item.ClassName,
                    Text = item.ClassName,
                    Tag = item,
                    SelectedImageIndex = (int)ImageEnum.Table,
                    ImageIndex = (int)ImageEnum.Table
                };
                namespaces.Nodes.Add(classnote);
                 
                TreeNode propertyFloder = new TreeNode()
                {
                    Name = "Property",
                    Text = "Property", 
                    SelectedImageIndex = (int)ImageEnum.Folder,
                    ImageIndex = (int)ImageEnum.Table
                };

                TreeNode methodFloder = new TreeNode()
                {
                    Name = "Method",
                    Text = "Method", 
                    SelectedImageIndex = (int)ImageEnum.Folder,
                    ImageIndex = (int)ImageEnum.Table
                };

                classnote.Nodes.Add(propertyFloder);
                classnote.Nodes.Add(methodFloder);

                // add property
                foreach (var property in item.Protertys)
                {
                    TreeNode propertynote = new TreeNode()
                    {
                        Name = property.PropertyName,
                        Text = property.PropertyName,
                        Tag = property,
                        SelectedImageIndex = (int)ImageEnum.Edit,
                        ImageIndex = (int)ImageEnum.Edit
                    };
                    propertyFloder.Nodes.Add(propertynote);
                }

                // add method 
                foreach (var method in item.Methods)
                {
                    TreeNode methodnote = new TreeNode()
                    {
                        Name = method.MethodName,
                        Text = method.MethodName,
                        Tag = method,
                        SelectedImageIndex = (int)ImageEnum.Edit,
                        ImageIndex = (int)ImageEnum.Edit
                    };
                    methodFloder.Nodes.Add(methodnote);
                } 
            }
        }

        public void LoadSnippet()
        {
            listSnippet = sqlite.Snippets.AsNoTracking().ToList();

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
        public void LoadDataBase(List<string> list = null,
            SearchType searchType = 0,string addresses = "",string databases = "" )
        {
            var address = sqlite.DataBaseAddresses.ToList();
            if(!string.IsNullOrEmpty(addresses))
            {
                address = address.Where(x => x.Address == addresses && x.DefaultDatabase == databases).ToList();
            }
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

                if(!string.IsNullOrEmpty(databases))
                {
                    item.DataBases = item.DataBases.Where(x => x.DataBaseName == databases).ToList();
                }

                foreach (var db in item.DataBases)
                {
                    TreeNode dbNode = new TreeNode(db.DataBaseName);
                    dbNode.ImageIndex = (int)ImageEnum.Database;
                    dbNode.SelectedImageIndex = (int)ImageEnum.Database;
                    treeNode.Nodes.Add(dbNode);
                    dbNode.Tag = db;

                    // init table
                    sh.InitTable(db,list,searchType);
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

                        //tableNode.Nodes.Add(string.Empty);

                        dbNode.Nodes.Add(tableNode);
                    }

                    // init view

                    // init index

                }
            }
        }
    }
}
