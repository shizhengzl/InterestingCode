﻿namespace WFGenerator
{
    partial class GeneartorTools
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneartorTools));
            this.statusStripMessage = new System.Windows.Forms.StatusStrip();
            this.tabControlALL = new System.Windows.Forms.TabControl();
            this.tabPageSQLGeneartor = new System.Windows.Forms.TabPage();
            this.groupGenerator = new System.Windows.Forms.GroupBox();
            this.tabControlGeneartor = new System.Windows.Forms.TabControl();
            this.tabPageStruct = new System.Windows.Forms.TabPage();
            this.txtGenerator = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tGenerator = new System.Windows.Forms.ToolStripButton();
            this.tGeneratorFile = new System.Windows.Forms.ToolStripButton();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.PanSelectAndSnippet = new System.Windows.Forms.Panel();
            this.gbSnippet = new System.Windows.Forms.GroupBox();
            this.SnippetTree = new WFGenerator.WinfromControl.DatabaseTree();
            this.bgselect = new System.Windows.Forms.GroupBox();
            this.tabControlSelect = new System.Windows.Forms.TabControl();
            this.tabPageSelectSQL = new System.Windows.Forms.TabPage();
            this.gtree = new System.Windows.Forms.GroupBox();
            this.ServerTree = new WFGenerator.WinfromControl.DatabaseTree();
            this.toolStripTreeServer = new System.Windows.Forms.ToolStrip();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabPageSelectClass = new System.Windows.Forms.TabPage();
            this.tabPageSelectXML = new System.Windows.Forms.TabPage();
            this.TreeViewXML = new System.Windows.Forms.TreeView();
            this.gbleft = new System.Windows.Forms.GroupBox();
            this.tabControlSource = new System.Windows.Forms.TabControl();
            this.tpSource = new System.Windows.Forms.TabPage();
            this.btnString = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtXmlSelect = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.pSearch = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdFilterTable = new System.Windows.Forms.RadioButton();
            this.rdFilterColumn = new System.Windows.Forms.RadioButton();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.rdComplete = new System.Windows.Forms.RadioButton();
            this.txtFuzzyPercent = new System.Windows.Forms.TextBox();
            this.rdLikdSearch = new System.Windows.Forms.RadioButton();
            this.rdFuzzySearch = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabPageString = new System.Windows.Forms.TabPage();
            this.tabPageSQLCompare = new System.Windows.Forms.TabPage();
            this.tabPageSystemConfig = new System.Windows.Forms.TabPage();
            this.tabControlSet = new System.Windows.Forms.TabControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.ClassTree = new WFGenerator.WinfromControl.DatabaseTree();
            this.tabControlALL.SuspendLayout();
            this.tabPageSQLGeneartor.SuspendLayout();
            this.groupGenerator.SuspendLayout();
            this.tabControlGeneartor.SuspendLayout();
            this.tabPageStruct.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.PanSelectAndSnippet.SuspendLayout();
            this.gbSnippet.SuspendLayout();
            this.bgselect.SuspendLayout();
            this.tabControlSelect.SuspendLayout();
            this.tabPageSelectSQL.SuspendLayout();
            this.gtree.SuspendLayout();
            this.toolStripTreeServer.SuspendLayout();
            this.tabPageSelectClass.SuspendLayout();
            this.tabPageSelectXML.SuspendLayout();
            this.gbleft.SuspendLayout();
            this.tabControlSource.SuspendLayout();
            this.tpSource.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.tabPageSystemConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMessage
            // 
            this.statusStripMessage.Location = new System.Drawing.Point(0, 664);
            this.statusStripMessage.Name = "statusStripMessage";
            this.statusStripMessage.Size = new System.Drawing.Size(1215, 22);
            this.statusStripMessage.TabIndex = 0;
            this.statusStripMessage.Text = "statusStrip1";
            // 
            // tabControlALL
            // 
            this.tabControlALL.Controls.Add(this.tabPageSQLGeneartor);
            this.tabControlALL.Controls.Add(this.tabPageString);
            this.tabControlALL.Controls.Add(this.tabPageSQLCompare);
            this.tabControlALL.Controls.Add(this.tabPageSystemConfig);
            this.tabControlALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlALL.ImageList = this.imageList;
            this.tabControlALL.Location = new System.Drawing.Point(0, 0);
            this.tabControlALL.Name = "tabControlALL";
            this.tabControlALL.SelectedIndex = 0;
            this.tabControlALL.Size = new System.Drawing.Size(1215, 664);
            this.tabControlALL.TabIndex = 1;
            // 
            // tabPageSQLGeneartor
            // 
            this.tabPageSQLGeneartor.Controls.Add(this.groupGenerator);
            this.tabPageSQLGeneartor.Controls.Add(this.PanSelectAndSnippet);
            this.tabPageSQLGeneartor.Controls.Add(this.gbleft);
            this.tabPageSQLGeneartor.ImageIndex = 4;
            this.tabPageSQLGeneartor.Location = new System.Drawing.Point(4, 23);
            this.tabPageSQLGeneartor.Name = "tabPageSQLGeneartor";
            this.tabPageSQLGeneartor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLGeneartor.Size = new System.Drawing.Size(1207, 637);
            this.tabPageSQLGeneartor.TabIndex = 0;
            this.tabPageSQLGeneartor.Text = "SQL Generoator";
            this.tabPageSQLGeneartor.UseVisualStyleBackColor = true;
            // 
            // groupGenerator
            // 
            this.groupGenerator.Controls.Add(this.tabControlGeneartor);
            this.groupGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGenerator.Location = new System.Drawing.Point(683, 3);
            this.groupGenerator.Name = "groupGenerator";
            this.groupGenerator.Size = new System.Drawing.Size(521, 631);
            this.groupGenerator.TabIndex = 4;
            this.groupGenerator.TabStop = false;
            this.groupGenerator.Text = "GroupGenerator";
            // 
            // tabControlGeneartor
            // 
            this.tabControlGeneartor.Controls.Add(this.tabPageStruct);
            this.tabControlGeneartor.Controls.Add(this.tabPageData);
            this.tabControlGeneartor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGeneartor.Location = new System.Drawing.Point(3, 17);
            this.tabControlGeneartor.Name = "tabControlGeneartor";
            this.tabControlGeneartor.SelectedIndex = 0;
            this.tabControlGeneartor.Size = new System.Drawing.Size(515, 611);
            this.tabControlGeneartor.TabIndex = 0;
            // 
            // tabPageStruct
            // 
            this.tabPageStruct.Controls.Add(this.txtGenerator);
            this.tabPageStruct.Controls.Add(this.toolStrip1);
            this.tabPageStruct.Location = new System.Drawing.Point(4, 22);
            this.tabPageStruct.Name = "tabPageStruct";
            this.tabPageStruct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStruct.Size = new System.Drawing.Size(507, 585);
            this.tabPageStruct.TabIndex = 0;
            this.tabPageStruct.Text = "Struct Generator";
            this.tabPageStruct.UseVisualStyleBackColor = true;
            // 
            // txtGenerator
            // 
            this.txtGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGenerator.Location = new System.Drawing.Point(3, 28);
            this.txtGenerator.Multiline = true;
            this.txtGenerator.Name = "txtGenerator";
            this.txtGenerator.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGenerator.Size = new System.Drawing.Size(501, 554);
            this.txtGenerator.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tGenerator,
            this.tGeneratorFile});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(501, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tGenerator
            // 
            this.tGenerator.Image = ((System.Drawing.Image)(resources.GetObject("tGenerator.Image")));
            this.tGenerator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tGenerator.Name = "tGenerator";
            this.tGenerator.Size = new System.Drawing.Size(87, 22);
            this.tGenerator.Text = "Generator";
            this.tGenerator.Click += new System.EventHandler(this.tGenerator_Click);
            // 
            // tGeneratorFile
            // 
            this.tGeneratorFile.Image = ((System.Drawing.Image)(resources.GetObject("tGeneratorFile.Image")));
            this.tGeneratorFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tGeneratorFile.Name = "tGeneratorFile";
            this.tGeneratorFile.Size = new System.Drawing.Size(106, 22);
            this.tGeneratorFile.Text = "GeneratorFile";
            this.tGeneratorFile.Click += new System.EventHandler(this.tGeneratorFile_Click);
            // 
            // tabPageData
            // 
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(507, 585);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data Generator";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // PanSelectAndSnippet
            // 
            this.PanSelectAndSnippet.Controls.Add(this.gbSnippet);
            this.PanSelectAndSnippet.Controls.Add(this.bgselect);
            this.PanSelectAndSnippet.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanSelectAndSnippet.Location = new System.Drawing.Point(370, 3);
            this.PanSelectAndSnippet.Name = "PanSelectAndSnippet";
            this.PanSelectAndSnippet.Size = new System.Drawing.Size(313, 631);
            this.PanSelectAndSnippet.TabIndex = 2;
            // 
            // gbSnippet
            // 
            this.gbSnippet.Controls.Add(this.SnippetTree);
            this.gbSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSnippet.Location = new System.Drawing.Point(0, 332);
            this.gbSnippet.Name = "gbSnippet";
            this.gbSnippet.Size = new System.Drawing.Size(313, 299);
            this.gbSnippet.TabIndex = 2;
            this.gbSnippet.TabStop = false;
            this.gbSnippet.Text = "Snippet";
            // 
            // SnippetTree
            // 
            this.SnippetTree.CheckBoxes = true;
            this.SnippetTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SnippetTree.listSnippet = null;
            this.SnippetTree.Location = new System.Drawing.Point(3, 17);
            this.SnippetTree.Name = "SnippetTree";
            this.SnippetTree.sh = null;
            this.SnippetTree.Size = new System.Drawing.Size(307, 279);
            this.SnippetTree.sqlite = null;
            this.SnippetTree.TabIndex = 0;
            this.SnippetTree.treeType = WFGenerator.TreeType.DataBase;
            this.SnippetTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SnippetTree_NodeMouseDoubleClick);
            // 
            // bgselect
            // 
            this.bgselect.Controls.Add(this.tabControlSelect);
            this.bgselect.Dock = System.Windows.Forms.DockStyle.Top;
            this.bgselect.Location = new System.Drawing.Point(0, 0);
            this.bgselect.Name = "bgselect";
            this.bgselect.Size = new System.Drawing.Size(313, 332);
            this.bgselect.TabIndex = 1;
            this.bgselect.TabStop = false;
            this.bgselect.Text = "SelectDataSource";
            // 
            // tabControlSelect
            // 
            this.tabControlSelect.Controls.Add(this.tabPageSelectSQL);
            this.tabControlSelect.Controls.Add(this.tabPageSelectClass);
            this.tabControlSelect.Controls.Add(this.tabPageSelectXML);
            this.tabControlSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSelect.Location = new System.Drawing.Point(3, 17);
            this.tabControlSelect.Name = "tabControlSelect";
            this.tabControlSelect.SelectedIndex = 0;
            this.tabControlSelect.Size = new System.Drawing.Size(307, 312);
            this.tabControlSelect.TabIndex = 0;
            // 
            // tabPageSelectSQL
            // 
            this.tabPageSelectSQL.Controls.Add(this.gtree);
            this.tabPageSelectSQL.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelectSQL.Name = "tabPageSelectSQL";
            this.tabPageSelectSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelectSQL.Size = new System.Drawing.Size(299, 286);
            this.tabPageSelectSQL.TabIndex = 0;
            this.tabPageSelectSQL.Text = "SQL";
            this.tabPageSelectSQL.UseVisualStyleBackColor = true;
            // 
            // gtree
            // 
            this.gtree.Controls.Add(this.ServerTree);
            this.gtree.Controls.Add(this.toolStripTreeServer);
            this.gtree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtree.Location = new System.Drawing.Point(3, 3);
            this.gtree.Name = "gtree";
            this.gtree.Size = new System.Drawing.Size(293, 280);
            this.gtree.TabIndex = 2;
            this.gtree.TabStop = false;
            this.gtree.Text = "Tree";
            // 
            // ServerTree
            // 
            this.ServerTree.CheckBoxes = true;
            this.ServerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerTree.listSnippet = null;
            this.ServerTree.Location = new System.Drawing.Point(3, 42);
            this.ServerTree.Name = "ServerTree";
            this.ServerTree.sh = null;
            this.ServerTree.Size = new System.Drawing.Size(287, 235);
            this.ServerTree.sqlite = null;
            this.ServerTree.TabIndex = 1;
            this.ServerTree.treeType = WFGenerator.TreeType.DataBase;
            // 
            // toolStripTreeServer
            // 
            this.toolStripTreeServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.tsRemove,
            this.tsRefresh});
            this.toolStripTreeServer.Location = new System.Drawing.Point(3, 17);
            this.toolStripTreeServer.Name = "toolStripTreeServer";
            this.toolStripTreeServer.Size = new System.Drawing.Size(287, 25);
            this.toolStripTreeServer.TabIndex = 0;
            this.toolStripTreeServer.Text = "toolStripTree";
            // 
            // tsAdd
            // 
            this.tsAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsAdd.Image")));
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(52, 22);
            this.tsAdd.Text = "Add";
            // 
            // tsRemove
            // 
            this.tsRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsRemove.Image")));
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(75, 22);
            this.tsRemove.Text = "Remove";
            // 
            // tsRefresh
            // 
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(72, 22);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // tabPageSelectClass
            // 
            this.tabPageSelectClass.Controls.Add(this.ClassTree);
            this.tabPageSelectClass.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelectClass.Name = "tabPageSelectClass";
            this.tabPageSelectClass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelectClass.Size = new System.Drawing.Size(299, 286);
            this.tabPageSelectClass.TabIndex = 1;
            this.tabPageSelectClass.Text = "Class";
            this.tabPageSelectClass.UseVisualStyleBackColor = true;
            // 
            // tabPageSelectXML
            // 
            this.tabPageSelectXML.Controls.Add(this.TreeViewXML);
            this.tabPageSelectXML.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelectXML.Name = "tabPageSelectXML";
            this.tabPageSelectXML.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelectXML.Size = new System.Drawing.Size(299, 286);
            this.tabPageSelectXML.TabIndex = 2;
            this.tabPageSelectXML.Text = "XML";
            this.tabPageSelectXML.UseVisualStyleBackColor = true;
            // 
            // TreeViewXML
            // 
            this.TreeViewXML.CheckBoxes = true;
            this.TreeViewXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewXML.Location = new System.Drawing.Point(3, 3);
            this.TreeViewXML.Name = "TreeViewXML";
            this.TreeViewXML.ShowNodeToolTips = true;
            this.TreeViewXML.Size = new System.Drawing.Size(293, 280);
            this.TreeViewXML.TabIndex = 0;
            // 
            // gbleft
            // 
            this.gbleft.Controls.Add(this.tabControlSource);
            this.gbleft.Controls.Add(this.pSearch);
            this.gbleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbleft.Location = new System.Drawing.Point(3, 3);
            this.gbleft.Name = "gbleft";
            this.gbleft.Size = new System.Drawing.Size(367, 631);
            this.gbleft.TabIndex = 0;
            this.gbleft.TabStop = false;
            this.gbleft.Text = "DataSource";
            // 
            // tabControlSource
            // 
            this.tabControlSource.Controls.Add(this.tpSource);
            this.tabControlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSource.Location = new System.Drawing.Point(3, 210);
            this.tabControlSource.Name = "tabControlSource";
            this.tabControlSource.SelectedIndex = 0;
            this.tabControlSource.Size = new System.Drawing.Size(361, 418);
            this.tabControlSource.TabIndex = 2;
            // 
            // tpSource
            // 
            this.tpSource.Controls.Add(this.btnString);
            this.tpSource.Controls.Add(this.btnSelectFolder);
            this.tpSource.Controls.Add(this.txtXmlSelect);
            this.tpSource.Controls.Add(this.btnSelectFile);
            this.tpSource.Location = new System.Drawing.Point(4, 22);
            this.tpSource.Name = "tpSource";
            this.tpSource.Padding = new System.Windows.Forms.Padding(3);
            this.tpSource.Size = new System.Drawing.Size(353, 392);
            this.tpSource.TabIndex = 4;
            this.tpSource.Text = "From Source";
            this.tpSource.UseVisualStyleBackColor = true;
            // 
            // btnString
            // 
            this.btnString.Location = new System.Drawing.Point(234, 119);
            this.btnString.Name = "btnString";
            this.btnString.Size = new System.Drawing.Size(88, 23);
            this.btnString.TabIndex = 3;
            this.btnString.Text = "String Load";
            this.btnString.UseVisualStyleBackColor = true;
            this.btnString.Click += new System.EventHandler(this.btnString_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(129, 119);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(99, 23);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // txtXmlSelect
            // 
            this.txtXmlSelect.AllowDrop = true;
            this.txtXmlSelect.Location = new System.Drawing.Point(6, 6);
            this.txtXmlSelect.Multiline = true;
            this.txtXmlSelect.Name = "txtXmlSelect";
            this.txtXmlSelect.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXmlSelect.Size = new System.Drawing.Size(341, 91);
            this.txtXmlSelect.TabIndex = 1;
            this.txtXmlSelect.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtXmlSelect_DragDrop);
            this.txtXmlSelect.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtXmlSelect_DragEnter);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(18, 119);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(105, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.btnClear);
            this.pSearch.Controls.Add(this.btnSearch);
            this.pSearch.Controls.Add(this.groupBox1);
            this.pSearch.Controls.Add(this.gbSearch);
            this.pSearch.Controls.Add(this.txtSearch);
            this.pSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSearch.Location = new System.Drawing.Point(3, 17);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(361, 193);
            this.pSearch.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(228, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(298, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 32);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdFilterTable);
            this.groupBox1.Controls.Add(this.rdFilterColumn);
            this.groupBox1.Location = new System.Drawing.Point(229, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 57);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FilterMode";
            // 
            // rdFilterTable
            // 
            this.rdFilterTable.AutoSize = true;
            this.rdFilterTable.Checked = true;
            this.rdFilterTable.Location = new System.Drawing.Point(8, 13);
            this.rdFilterTable.Name = "rdFilterTable";
            this.rdFilterTable.Size = new System.Drawing.Size(89, 16);
            this.rdFilterTable.TabIndex = 1;
            this.rdFilterTable.TabStop = true;
            this.rdFilterTable.Text = "FilterTable";
            this.rdFilterTable.UseVisualStyleBackColor = true;
            // 
            // rdFilterColumn
            // 
            this.rdFilterColumn.AutoSize = true;
            this.rdFilterColumn.Location = new System.Drawing.Point(8, 35);
            this.rdFilterColumn.Name = "rdFilterColumn";
            this.rdFilterColumn.Size = new System.Drawing.Size(95, 16);
            this.rdFilterColumn.TabIndex = 2;
            this.rdFilterColumn.Text = "FilterColumn";
            this.rdFilterColumn.UseVisualStyleBackColor = true;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.rdComplete);
            this.gbSearch.Controls.Add(this.txtFuzzyPercent);
            this.gbSearch.Controls.Add(this.rdLikdSearch);
            this.gbSearch.Controls.Add(this.rdFuzzySearch);
            this.gbSearch.Location = new System.Drawing.Point(228, 5);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(125, 79);
            this.gbSearch.TabIndex = 3;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "MatchMode";
            // 
            // rdComplete
            // 
            this.rdComplete.AutoSize = true;
            this.rdComplete.Checked = true;
            this.rdComplete.Location = new System.Drawing.Point(8, 34);
            this.rdComplete.Name = "rdComplete";
            this.rdComplete.Size = new System.Drawing.Size(71, 16);
            this.rdComplete.TabIndex = 4;
            this.rdComplete.TabStop = true;
            this.rdComplete.Text = "Complete";
            this.rdComplete.UseVisualStyleBackColor = true;
            // 
            // txtFuzzyPercent
            // 
            this.txtFuzzyPercent.Location = new System.Drawing.Point(59, 55);
            this.txtFuzzyPercent.Name = "txtFuzzyPercent";
            this.txtFuzzyPercent.Size = new System.Drawing.Size(32, 21);
            this.txtFuzzyPercent.TabIndex = 3;
            this.txtFuzzyPercent.Text = "90";
            // 
            // rdLikdSearch
            // 
            this.rdLikdSearch.AutoSize = true;
            this.rdLikdSearch.Location = new System.Drawing.Point(8, 13);
            this.rdLikdSearch.Name = "rdLikdSearch";
            this.rdLikdSearch.Size = new System.Drawing.Size(83, 16);
            this.rdLikdSearch.TabIndex = 1;
            this.rdLikdSearch.Text = "LikeSerach";
            this.rdLikdSearch.UseVisualStyleBackColor = true;
            // 
            // rdFuzzySearch
            // 
            this.rdFuzzySearch.AutoSize = true;
            this.rdFuzzySearch.Location = new System.Drawing.Point(8, 55);
            this.rdFuzzySearch.Name = "rdFuzzySearch";
            this.rdFuzzySearch.Size = new System.Drawing.Size(53, 16);
            this.rdFuzzySearch.TabIndex = 2;
            this.rdFuzzySearch.Text = "Fuzzy";
            this.rdFuzzySearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(219, 184);
            this.txtSearch.TabIndex = 0;
            // 
            // tabPageString
            // 
            this.tabPageString.ImageIndex = 4;
            this.tabPageString.Location = new System.Drawing.Point(4, 23);
            this.tabPageString.Name = "tabPageString";
            this.tabPageString.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageString.Size = new System.Drawing.Size(1207, 637);
            this.tabPageString.TabIndex = 2;
            this.tabPageString.Text = "String";
            this.tabPageString.UseVisualStyleBackColor = true;
            // 
            // tabPageSQLCompare
            // 
            this.tabPageSQLCompare.ImageIndex = 4;
            this.tabPageSQLCompare.Location = new System.Drawing.Point(4, 23);
            this.tabPageSQLCompare.Name = "tabPageSQLCompare";
            this.tabPageSQLCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLCompare.Size = new System.Drawing.Size(1207, 637);
            this.tabPageSQLCompare.TabIndex = 3;
            this.tabPageSQLCompare.Text = "SQL Compare";
            this.tabPageSQLCompare.UseVisualStyleBackColor = true;
            // 
            // tabPageSystemConfig
            // 
            this.tabPageSystemConfig.Controls.Add(this.tabControlSet);
            this.tabPageSystemConfig.ImageIndex = 4;
            this.tabPageSystemConfig.Location = new System.Drawing.Point(4, 23);
            this.tabPageSystemConfig.Name = "tabPageSystemConfig";
            this.tabPageSystemConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystemConfig.Size = new System.Drawing.Size(1207, 637);
            this.tabPageSystemConfig.TabIndex = 4;
            this.tabPageSystemConfig.Text = "System Config";
            this.tabPageSystemConfig.UseVisualStyleBackColor = true;
            // 
            // tabControlSet
            // 
            this.tabControlSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSet.ImageList = this.imageList;
            this.tabControlSet.Location = new System.Drawing.Point(3, 3);
            this.tabControlSet.Name = "tabControlSet";
            this.tabControlSet.SelectedIndex = 0;
            this.tabControlSet.Size = new System.Drawing.Size(1201, 631);
            this.tabControlSet.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add_edit_24px.png");
            this.imageList.Images.SetKeyName(1, "database_24px.png");
            this.imageList.Images.SetKeyName(2, "edit_24px.png");
            this.imageList.Images.SetKeyName(3, "folder_24px.png");
            this.imageList.Images.SetKeyName(4, "generate_tables_24px.png");
            this.imageList.Images.SetKeyName(5, "refresh_24px.png");
            this.imageList.Images.SetKeyName(6, "remove_24px.png");
            this.imageList.Images.SetKeyName(7, "server_24px.png");
            this.imageList.Images.SetKeyName(8, "table_24px.png");
            this.imageList.Images.SetKeyName(9, "dialog_ok_24px.png");
            this.imageList.Images.SetKeyName(10, "error_24px.png");
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Multiselect = true;
            // 
            // ClassTree
            // 
            this.ClassTree.CheckBoxes = true;
            this.ClassTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassTree.listSnippet = null;
            this.ClassTree.Location = new System.Drawing.Point(3, 3);
            this.ClassTree.Name = "ClassTree";
            this.ClassTree.sh = null;
            this.ClassTree.Size = new System.Drawing.Size(293, 280);
            this.ClassTree.sqlite = null;
            this.ClassTree.TabIndex = 0;
            this.ClassTree.treeType = WFGenerator.TreeType.DataBase;
            // 
            // GeneartorTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 686);
            this.Controls.Add(this.tabControlALL);
            this.Controls.Add(this.statusStripMessage);
            this.Name = "GeneartorTools";
            this.Text = "GeneratorTools";
            this.Load += new System.EventHandler(this.GeneartorTools_Load);
            this.tabControlALL.ResumeLayout(false);
            this.tabPageSQLGeneartor.ResumeLayout(false);
            this.groupGenerator.ResumeLayout(false);
            this.tabControlGeneartor.ResumeLayout(false);
            this.tabPageStruct.ResumeLayout(false);
            this.tabPageStruct.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PanSelectAndSnippet.ResumeLayout(false);
            this.gbSnippet.ResumeLayout(false);
            this.bgselect.ResumeLayout(false);
            this.tabControlSelect.ResumeLayout(false);
            this.tabPageSelectSQL.ResumeLayout(false);
            this.gtree.ResumeLayout(false);
            this.gtree.PerformLayout();
            this.toolStripTreeServer.ResumeLayout(false);
            this.toolStripTreeServer.PerformLayout();
            this.tabPageSelectClass.ResumeLayout(false);
            this.tabPageSelectXML.ResumeLayout(false);
            this.gbleft.ResumeLayout(false);
            this.tabControlSource.ResumeLayout(false);
            this.tpSource.ResumeLayout(false);
            this.tpSource.PerformLayout();
            this.pSearch.ResumeLayout(false);
            this.pSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.tabPageSystemConfig.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMessage;
        private System.Windows.Forms.TabControl tabControlALL;
        private System.Windows.Forms.TabPage tabPageSQLGeneartor;
        private System.Windows.Forms.TabPage tabPageString;
        private System.Windows.Forms.TabPage tabPageSQLCompare;
        private System.Windows.Forms.TabPage tabPageSystemConfig;
        private System.Windows.Forms.GroupBox gbleft;
        private System.Windows.Forms.Panel PanSelectAndSnippet;
        private System.Windows.Forms.GroupBox gbSnippet;
        private System.Windows.Forms.GroupBox bgselect;
        private System.Windows.Forms.GroupBox gtree;
        private System.Windows.Forms.ToolStrip toolStripTreeServer;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.TabControl tabControlSet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdFuzzySearch;
        private System.Windows.Forms.RadioButton rdLikdSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdFilterTable;
        private System.Windows.Forms.RadioButton rdFilterColumn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.RadioButton rdComplete;
        private System.Windows.Forms.TextBox txtFuzzyPercent;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.TabControl tabControlSelect;
        private System.Windows.Forms.TabPage tabPageSelectSQL;
        private System.Windows.Forms.TabPage tabPageSelectClass;
        private System.Windows.Forms.TabPage tabPageSelectXML;
        private System.Windows.Forms.TreeView TreeViewXML;
        private System.Windows.Forms.ImageList imageList;
        private WinfromControl.DatabaseTree ServerTree;
        private WinfromControl.DatabaseTree SnippetTree;
        private System.Windows.Forms.GroupBox groupGenerator;
        private System.Windows.Forms.TabControl tabControlGeneartor;
        private System.Windows.Forms.TabPage tabPageStruct;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TextBox txtGenerator;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tGenerator;
        private System.Windows.Forms.ToolStripButton tGeneratorFile;
        private System.Windows.Forms.TabControl tabControlSource;
        private System.Windows.Forms.TabPage tpSource;
        private System.Windows.Forms.Button btnString;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtXmlSelect;
        private System.Windows.Forms.Button btnSelectFile;
        private WinfromControl.DatabaseTree ClassTree;
    }
}

