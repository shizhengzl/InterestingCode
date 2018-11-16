using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Resources; 
using WFGenerator.Properties;
using System.IO;
using EnvDTE;
using Core.UsuallyCommon;

namespace WFGenerator
{
	public class TreeComboBox : TreeView
	{
		#region 自定义成员变量

		private TextBox m_TextBox;
		private TreeView m_TreeView;
		private Button m_DropdownButton;
		private int m_MaxDropDownItems = 12;
		//是否正在显示下拉列表
		private bool b_Dropdown = false;
		//使能
		private bool b_Enabled = true;
		//事件
		public event EventHandler DropDown;
		public event EventHandler DropDownClosed;
		public event EventHandler EnableChanged;
		public event TreeViewCancelEventHandler BeforeExpand;
		public event TreeViewCancelEventHandler BeforeCollapse;
		public event TreeViewEventHandler AfterExpand;
		public event TreeViewEventHandler AfterCollapse;
		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public TreeComboBox()
		{
			this.InitControls();
			this.LayoutControls();
		}

		#region 内部辅助方法
		/// <summary>
		/// 创建并初始化所有控件，包括添加事件处理函数
		/// </summary>
		private void InitControls()
		{
			//TextBox
			this.m_TextBox = new TextBox();
			this.m_TextBox.KeyDown += new KeyEventHandler(m_TextBox_KeyDown);
			this.m_TextBox.Parent = this;
            this.m_TextBox.Left = this.m_TextBox.Left - 2;
            this.m_TextBox.Top = this.m_TextBox.Top - 2;
			//Button
			this.m_DropdownButton = new Button();

            Assembly asm = Assembly.GetExecutingAssembly();
            //string name = asm.GetName().Name;
            //MessageBox.Show(name);
            //Bitmap bm = new Bitmap(this.GetType(), "bm.png");
            //Bitmap bm = new Bitmap(asm.GetManifestResourceStream(asm.GetName().Name +".bm.png"));
            // Bitmap bm = new Bitmap(@"Controls\Winform\Combobox\TreeComboxbm.png");
            Bitmap bm =  (Bitmap)Resources.ResourceManager.GetObject("bm");
			this.m_DropdownButton.Image = bm;
			this.m_DropdownButton.Width = 16;
			this.m_DropdownButton.Height = this.m_TextBox.Height-2;
			this.m_DropdownButton.Location = new Point(this.m_TextBox.Right-18, 1);
			this.m_DropdownButton.Click += new EventHandler(m_DropdownButton_Click);
			this.m_DropdownButton.FlatStyle = FlatStyle.Flat;
			this.m_DropdownButton.Parent = this;
            //this.m_DropdownButton.BackgroundImage = bm;
            this.m_DropdownButton.FlatStyle = FlatStyle.Flat;
            this.m_DropdownButton.FlatAppearance.BorderSize = 0;
            this.m_DropdownButton.BackColor = Color.Transparent;
            //this.m_DropdownButton.Left = this.m_DropdownButton.Left + 2;
            this.m_DropdownButton.Top = this.m_DropdownButton.Top - 2;
            //this.m_DropdownButton.Bounds
			this.m_DropdownButton.BringToFront();

			//TreeView
			this.m_TreeView = new TreeView();
			this.m_TreeView.Visible = false;
			this.m_TreeView.DoubleClick += new EventHandler(m_TreeView_DoubleClick);
			this.m_TreeView.KeyDown += new KeyEventHandler(m_TreeView_KeyDown);
			this.m_TreeView.LostFocus += new EventHandler(m_TreeView_LostFocus);
			this.m_TreeView.BeforeExpand += new TreeViewCancelEventHandler(m_TreeView_BeforeExpand);
			this.m_TreeView.BeforeCollapse += new TreeViewCancelEventHandler(TreeComboBox_BeforeCollapse);
			this.m_TreeView.AfterExpand += new TreeViewEventHandler(m_TreeView_AfterExpand);
			this.m_TreeView.AfterCollapse += new TreeViewEventHandler(TreeComboBox_AfterCollapse);
			this.m_TreeView.Location = new Point(0, 0);
			this.m_TreeView.Parent = null;

			this.LostFocus += new EventHandler(TreeComboBox_LostFocus);

            this.DropDown += TreeComboBox_DropDown;
		}

        private void TreeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationVsHelper._applicationObject == null)
                    return;

                string url = ApplicationVsHelper._applicationObject.Solution.FullName;
                if (string.IsNullOrEmpty(url) || this.Nodes.Count > 0)
                    return;

                FileInfo file = new FileInfo(url); 
                TreeNode root = new TreeNode();
                root.Text = file.Directory.Name;
                root.Tag = file.Directory.FullName;
                root.ImageIndex = root.SelectedImageIndex = (int)ImageEnum.Folder;
                foreach (Project project in ApplicationVsHelper._applicationObject.Solution.Projects)
                {
                    if (project.FullName.IndexOf(".exe") > 0)
                        continue;
                    TreeNode chldNode = new TreeNode();
                    if (project.UniqueName.IndexOf(".csproj") < 0)
                    {
                        // add float
                        chldNode.Text = project.Name;
                        chldNode.Tag = project.FullName;
                        chldNode.ImageIndex = chldNode.SelectedImageIndex = (int)ImageEnum.Folder;
                        // add proj
                        foreach (ProjectItem item in project.ProjectItems)
                        {
                            if (item.SubProject == null || item.SubProject.UniqueName == null)
                                continue;
                            bool isFloder = item.SubProject != null && item.SubProject.ProjectItems != null;
                            TreeNode tn = new TreeNode();
                            tn.Text = item.SubProject == null ? item.Name : item.SubProject.Name;
                            tn.ToolTipText = item.SubProject.UniqueName.GetFileDirectory();
                            tn.Tag = item.SubProject.UniqueName;//.Replace("\\" + item.SubProject.Name + ".csproj", "");
                            tn.ImageIndex = tn.SelectedImageIndex = isFloder ? (int)ImageEnum.Folder : (int)ImageEnum.Folder;
                            //string floder 
                            string floder = item.SubProject.FullName.Replace("\\" + item.SubProject.Name + ".csproj", "");
                            if (!string.IsNullOrEmpty(floder))
                                GetFiles(floder, tn);
                            if (isFloder)
                                CheckChild(item.SubProject.ProjectItems, tn);
                            chldNode.Nodes.Add(tn);
                        }
                    }
                    else
                    {
                        chldNode.Text = project.Name;
                        chldNode.ToolTipText = project.UniqueName.GetFileDirectory();
                        chldNode.Tag = project.UniqueName.Replace("..\\", ""); // tag->proj 
                        chldNode.ImageIndex = chldNode.SelectedImageIndex = (int)ImageEnum.Database;

                        if (project.ProjectItems != null)
                            CheckChild(project.ProjectItems, chldNode);
                        string floder = project.FullName.Replace("\\" + project.Name + ".csproj", "");
                        if (!string.IsNullOrEmpty(floder))
                            GetFiles(floder, chldNode);
                    }

                    root.Nodes.Add(chldNode);
                }

                //GetFiles(file.Directory.FullName, root);
                this.Nodes.Add(root);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提示LoadComboTree" + ex.Message);
            }
        }


        public void CheckChild(ProjectItems projectitems, TreeNode fathernode)
        {
            foreach (ProjectItem item in projectitems)
            {
                if (item.SubProject == null || item.SubProject.UniqueName == null)
                    continue;
                bool isFloder = item.SubProject != null && item.SubProject.ProjectItems != null;
                TreeNode tn = new TreeNode();
                tn.Text = item.SubProject == null ? item.Name : item.SubProject.FullName.Replace(ApplicationVsHelper.VsProjectPath, string.Empty); ;
                tn.ToolTipText = item.SubProject.UniqueName.GetFileDirectory();
                tn.Tag = item.SubProject.UniqueName;//.Replace("\\" + item.SubProject.Name + ".csproj", "");
                tn.ImageIndex = tn.SelectedImageIndex = isFloder ? (int)ImageEnum.Folder : (int)ImageEnum.Folder;

                //string floder 
                string floder = item.SubProject.FullName.Replace("\\" + item.SubProject.Name + ".csproj", "");
                if (!string.IsNullOrEmpty(floder))
                    GetFiles(floder, tn);
                if (isFloder)
                    CheckChild(item.SubProject.ProjectItems, tn);
                fathernode.Nodes.Add(tn);
            }
        }

        private void GetFiles(string filePath, TreeNode node)
        {
            if (!System.IO.Directory.Exists(filePath))
                return;
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles("*.*");
                foreach (FileInfo chlFile in chldFiles)
                {
                    // 处理文件在配置问题
                    //if (FileType != null && !FileType.Contains(chlFile.Extension))
                    //    continue;

                    TreeNode chldNode = new TreeNode();
                    chldNode.Text = chlFile.FullName.Replace(ApplicationVsHelper.VsProjectPath,string.Empty);
                    chldNode.ToolTipText = chlFile.FullName.Replace(ApplicationVsHelper.VsProjectPath, string.Empty);
                    chldNode.Tag = node.Tag;
                    //chldNode.ImageIndex = this.IsFileReturnFlag(chlFile.Extension);
                    chldNode.SelectedImageIndex = chldNode.ImageIndex;
                    node.Nodes.Add(chldNode);
                }
                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chldFolder in chldFolders)
                {
                    TreeNode chldNode = new TreeNode();
                    chldNode.ImageIndex = 2;
                    chldNode.Tag = node.Tag; //chldFolder.FullName.Replace(VsProjectPath, "");
                    chldNode.Text = chldFolder.FullName.Replace(ApplicationVsHelper.VsProjectPath, string.Empty);
                    chldNode.ToolTipText = chldFolder.FullName.Replace(ApplicationVsHelper.VsProjectPath, string.Empty);
                    node.Nodes.Add(chldNode);
                    GetFiles(chldFolder.FullName, chldNode);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提示GetFiles" + ex.Message);
            }

        }

      
        /// <summary>
        /// 布局所有控件，让TextBox尺寸适应容器尺寸
        /// </summary>
        private void LayoutControls()
		{
			this.m_TextBox.Width = this.Width;
			this.Height = this.m_TextBox.Height;
			this.m_DropdownButton.Left = this.m_TextBox.Right - 18;
			this.m_DropdownButton.Height = this.m_TextBox.Height - 2;
			this.m_TreeView.Width = this.Width;
			this.m_TreeView.Height = (int)((this.Font.Height+3) * this.m_MaxDropDownItems);

            //this.m_TreeView.Left = this.m_TreeView.Left - 10;
            //this.m_TreeView.Top = this.m_TreeView.Top - 10;
		}

		/// <summary>
		/// 显示下拉列表
		/// </summary>
		private void ShowDropDown()
		{
			if (this.Parent == null)
				return;

			// 智能计算显示的位置，尝试在下方显示，如果没有足够空间，则在上方显示
			// 尝试在下方的位置（现在只是相对父窗口的相对位置）
			Point pos = new Point(this.Left, this.Bottom-1);

			// 把位置映射到顶层窗口,获取父窗口的屏幕坐标
			Point parentPos = this.Parent.PointToScreen(this.Parent.Location);
			// 获取顶层窗口的屏幕坐标
			Point topParentPos = this.TopLevelControl.PointToScreen(this.Parent.Location);
			// 把相对父窗口的位置变换为相对顶级窗口的位置，因为popup的父是顶级窗口
			pos.Offset(parentPos.X - topParentPos.X, parentPos.Y - topParentPos.Y);

			// 检查是否有足够空间用于在label下方显示day picker
			if ((pos.Y + this.m_TreeView.Height) > this.TopLevelControl.ClientRectangle.Height)
			{
				// 没有足够的空间（超出了顶级窗口客户区），尝试在上方显示将Y方向，向上平移
				pos.Y -= (this.Height + this.m_TreeView.Height);
				if (pos.Y < 0)
				{
					// 如果上方仍然没有空间显示，则显示在顶级窗口的底部
					pos.Y = (this.TopLevelControl.ClientRectangle.Height -this.m_TreeView.Height);
				}
			}

			// 尝试停靠,如果右边超过顶级窗口的客户区，则将控件向左移动，并紧靠在顶级窗口右侧
			if ((pos.X + this.m_TreeView.Width) > this.TopLevelControl.ClientRectangle.Width)
				pos.X = (this.TopLevelControl.ClientRectangle.Width - this.m_TreeView.Width);	

			this.m_TreeView.Location = pos;// this.Parent.PointToScreen(pt);
			this.m_TreeView.Visible = true;
			this.m_TreeView.Parent = this.TopLevelControl;
			this.m_TreeView.BringToFront();
			this.b_Dropdown = true;
			//raise event
			if (this.DropDown != null)
				this.DropDown(this, EventArgs.Empty);
			this.m_TreeView.Focus();
		}

		/// <summary>
		/// 隐藏下拉列表
		/// </summary>
		private void HideDropDown()
		{
			if (this.DropDownClosed != null)
				this.DropDownClosed(this,EventArgs.Empty);
			this.m_TreeView.Parent = null;
			this.m_TreeView.Visible = false;
			this.b_Dropdown = false;
		}
		#endregion

		#region 事件处理 - TextBox
		/// <summary>
		/// 在编辑框中按下按键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (this.b_Dropdown)
					this.HideDropDown();
				else
					this.ShowDropDown();
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.ShowDropDown();
				this.m_TreeView.Focus();
			}
		}

		#endregion

		#region 事件处理 - TreeView
		/// <summary>
		/// 在下拉列表中选择了一个节点的事件处理！
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_TreeView_KeyDown(object sender, KeyEventArgs e)
		{
			//如果按下回车表示要选中当前节点
			if (e.KeyCode == Keys.Enter)
			{
				this.m_TreeView_DoubleClick(sender, EventArgs.Empty);
			}
		}

		/// <summary>
		/// 失去焦点时，如果不是被下拉按钮夺取的焦点，则隐藏它！
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void m_TreeView_LostFocus(object sender, EventArgs e)
		{
			if(!this.m_DropdownButton.Focused)
				this.HideDropDown();
		}

		/// <summary>
		/// 在下拉列表中双击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_TreeView_DoubleClick(object sender, EventArgs e)
		{
			TreeNode node = this.m_TreeView.SelectedNode;
			if (node != null)
				this.m_TextBox.Text = node.Text.ToString();

			if (this.b_Dropdown)
			{
				this.HideDropDown();
			}
		}

		void TreeComboBox_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if (this.AfterCollapse != null)
				this.AfterCollapse(this, e);
		}

		void TreeComboBox_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			if (this.BeforeCollapse != null)
				this.BeforeCollapse(this, e);
		}

		void m_TreeView_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (this.AfterExpand != null)
				this.AfterExpand(this,e);
		}

		void m_TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (this.BeforeExpand != null)
				this.BeforeExpand(this, e);
		}


		#endregion

		#region 事件处理 - Button
		private void m_DropdownButton_Click(object sender, EventArgs e)
		{
			//throw new Exception("The method or operation is not implemented.");
			if (this.b_Dropdown)
				this.HideDropDown();
			else
				this.ShowDropDown();
		}
		#endregion

		#region 事件处理 - 自身
		/// <summary>
		/// 失去焦点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TreeComboBox_LostFocus(object sender, EventArgs e)
		{
			if (this.b_Dropdown)
				this.HideDropDown();
		}

		/// <summary>
		/// 重设尺寸
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.LayoutControls();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.LayoutControls();
		}

		#endregion

		#region 外部属性封装

		/// <summary>
		/// 获取节点集合
		/// </summary>
		public TreeNodeCollection Nodes
		{
			get { return this.m_TreeView.Nodes; }
		}

		/// <summary>
		/// 设置或者获取节点的图片列表
		/// </summary>
		public ImageList ImageList
		{
			get
			{
				return this.m_TreeView.ImageList;
			}
			set
			{
				this.m_TreeView.ImageList = value;
			}
		}

		/// <summary>
		/// 重写enabled属性
		/// </summary>
		public new bool Enabled
		{
			get { return this.b_Enabled; }
			set
			{
				if (this.b_Enabled != value)
				{
					this.b_Enabled = value;
					this.m_DropdownButton.Enabled = value;
					this.b_Enabled = value;
					//当灰掉时，隐藏下拉列表
					if (!this.b_Enabled && this.b_Dropdown)
						this.HideDropDown();
					if (this.EnableChanged != null)
						this.EnableChanged(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// 字体
		/// </summary>
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				this.m_TextBox.Font = value;
				this.m_TreeView.Font = value;
				//调整布局
				this.LayoutControls();
			}
		}

		/// <summary>
		/// 重写Text
		/// </summary>
		public override string Text
		{
			get
			{
				return this.m_TextBox.Text.ToString();
			}
			set
			{
				if (this.Text != value)
				{
					this.m_TextBox.Text = value;
				}
			}
		}

		/// <summary>
		/// 是否显示lines
		/// </summary>
		public bool ShowLines
		{
			get { return this.m_TreeView.ShowLines; }
			set { this.m_TreeView.ShowLines = value; }
		}

		/// <summary>
		/// 是否显示+ -按钮
		/// </summary>
		public bool ShowPlusMinus
		{
			get { return this.m_TreeView.ShowPlusMinus; }
			set { this.m_TreeView.ShowPlusMinus = value; }
		}

		/// <summary>
		/// 是否显示root lines
		/// </summary>
		public bool ShowRootLines 
		{
			get { return this.m_TreeView.ShowRootLines; }
			set { this.m_TreeView.ShowRootLines = value; }
		}

		/// <summary>
		/// 是否显示root lines
		/// </summary>
		public bool ShowNodeToolTips
		{
			get { return this.m_TreeView.ShowNodeToolTips; }
			set { this.m_TreeView.ShowNodeToolTips = value; }
		}

		/// <summary>
		/// 获取或者设置选中的节点！
		/// </summary>
		public TreeNode SelectedNode
		{
			get
			{
				return this.m_TreeView.SelectedNode;
			}
			set
			{
				this.m_TreeView.SelectedNode = value;
				if (value != null)
					this.Text = value.Text.ToString();
			}
		}

		public int MaxDropDownItems
		{
			get
			{
				return this.m_MaxDropDownItems;
			}
			set
			{
				if (this.m_MaxDropDownItems != value)
				{
					this.m_MaxDropDownItems = value;
					this.m_TreeView.Height = this.m_TextBox.Height * value;
				}
			}
		}

		#endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TreeComboBox
            // 
            this.Name = "TreeComboBox";
            this.Size = new System.Drawing.Size(269, 600);
            this.ResumeLayout(false);

        }

	}
}
