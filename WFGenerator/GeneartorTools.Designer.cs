namespace WFGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneartorTools));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControlALL = new System.Windows.Forms.TabControl();
            this.tabPageSQLGeneartor = new System.Windows.Forms.TabPage();
            this.PanSelectAndSnippet = new System.Windows.Forms.Panel();
            this.gbSnippet = new System.Windows.Forms.GroupBox();
            this.bgselect = new System.Windows.Forms.GroupBox();
            this.gbleft = new System.Windows.Forms.GroupBox();
            this.tabControlSource = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.gtree = new System.Windows.Forms.GroupBox();
            this.TreeServer = new System.Windows.Forms.TreeView();
            this.toolStripTreeServer = new System.Windows.Forms.ToolStrip();
            this.tabPageSQL = new System.Windows.Forms.TabPage();
            this.tabPageClass = new System.Windows.Forms.TabPage();
            this.pSearch = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdFilterTable = new System.Windows.Forms.RadioButton();
            this.rdFilterColumn = new System.Windows.Forms.RadioButton();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.rdLikdSearch = new System.Windows.Forms.RadioButton();
            this.rdFuzzySearch = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabPageCsharpGenerator = new System.Windows.Forms.TabPage();
            this.tabPageString = new System.Windows.Forms.TabPage();
            this.tabPageSQLCompare = new System.Windows.Forms.TabPage();
            this.tabPageSystemConfig = new System.Windows.Forms.TabPage();
            this.tabControlSet = new System.Windows.Forms.TabControl();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.txtFuzzyPercent = new System.Windows.Forms.TextBox();
            this.treeSelectData = new System.Windows.Forms.TreeView();
            this.rdComplete = new System.Windows.Forms.RadioButton();
            this.tabPageExecl = new System.Windows.Forms.TabPage();
            this.tabControlALL.SuspendLayout();
            this.tabPageSQLGeneartor.SuspendLayout();
            this.PanSelectAndSnippet.SuspendLayout();
            this.bgselect.SuspendLayout();
            this.gbleft.SuspendLayout();
            this.tabControlSource.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.gtree.SuspendLayout();
            this.toolStripTreeServer.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.tabPageSystemConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1215, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControlALL
            // 
            this.tabControlALL.Controls.Add(this.tabPageSQLGeneartor);
            this.tabControlALL.Controls.Add(this.tabPageCsharpGenerator);
            this.tabControlALL.Controls.Add(this.tabPageString);
            this.tabControlALL.Controls.Add(this.tabPageSQLCompare);
            this.tabControlALL.Controls.Add(this.tabPageSystemConfig);
            this.tabControlALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlALL.Location = new System.Drawing.Point(0, 0);
            this.tabControlALL.Name = "tabControlALL";
            this.tabControlALL.SelectedIndex = 0;
            this.tabControlALL.Size = new System.Drawing.Size(1215, 664);
            this.tabControlALL.TabIndex = 1;
            // 
            // tabPageSQLGeneartor
            // 
            this.tabPageSQLGeneartor.Controls.Add(this.PanSelectAndSnippet);
            this.tabPageSQLGeneartor.Controls.Add(this.gbleft);
            this.tabPageSQLGeneartor.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLGeneartor.Name = "tabPageSQLGeneartor";
            this.tabPageSQLGeneartor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLGeneartor.Size = new System.Drawing.Size(1207, 638);
            this.tabPageSQLGeneartor.TabIndex = 0;
            this.tabPageSQLGeneartor.Text = "SQL Generoator";
            this.tabPageSQLGeneartor.UseVisualStyleBackColor = true;
            // 
            // PanSelectAndSnippet
            // 
            this.PanSelectAndSnippet.Controls.Add(this.gbSnippet);
            this.PanSelectAndSnippet.Controls.Add(this.bgselect);
            this.PanSelectAndSnippet.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanSelectAndSnippet.Location = new System.Drawing.Point(370, 3);
            this.PanSelectAndSnippet.Name = "PanSelectAndSnippet";
            this.PanSelectAndSnippet.Size = new System.Drawing.Size(313, 632);
            this.PanSelectAndSnippet.TabIndex = 2;
            // 
            // gbSnippet
            // 
            this.gbSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSnippet.Location = new System.Drawing.Point(0, 332);
            this.gbSnippet.Name = "gbSnippet";
            this.gbSnippet.Size = new System.Drawing.Size(313, 300);
            this.gbSnippet.TabIndex = 2;
            this.gbSnippet.TabStop = false;
            this.gbSnippet.Text = "Snippet";
            // 
            // bgselect
            // 
            this.bgselect.Controls.Add(this.treeSelectData);
            this.bgselect.Dock = System.Windows.Forms.DockStyle.Top;
            this.bgselect.Location = new System.Drawing.Point(0, 0);
            this.bgselect.Name = "bgselect";
            this.bgselect.Size = new System.Drawing.Size(313, 332);
            this.bgselect.TabIndex = 1;
            this.bgselect.TabStop = false;
            this.bgselect.Text = "SelectDataSource";
            // 
            // gbleft
            // 
            this.gbleft.Controls.Add(this.tabControlSource);
            this.gbleft.Controls.Add(this.pSearch);
            this.gbleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbleft.Location = new System.Drawing.Point(3, 3);
            this.gbleft.Name = "gbleft";
            this.gbleft.Size = new System.Drawing.Size(367, 632);
            this.gbleft.TabIndex = 0;
            this.gbleft.TabStop = false;
            this.gbleft.Text = "DataSource";
            // 
            // tabControlSource
            // 
            this.tabControlSource.Controls.Add(this.tabPageConnection);
            this.tabControlSource.Controls.Add(this.tabPageSQL);
            this.tabControlSource.Controls.Add(this.tabPageClass);
            this.tabControlSource.Controls.Add(this.tabPageExecl);
            this.tabControlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSource.Location = new System.Drawing.Point(3, 210);
            this.tabControlSource.Name = "tabControlSource";
            this.tabControlSource.SelectedIndex = 0;
            this.tabControlSource.Size = new System.Drawing.Size(361, 419);
            this.tabControlSource.TabIndex = 2;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.gtree);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(353, 393);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "SQLConnection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // gtree
            // 
            this.gtree.Controls.Add(this.TreeServer);
            this.gtree.Controls.Add(this.toolStripTreeServer);
            this.gtree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtree.Location = new System.Drawing.Point(3, 3);
            this.gtree.Name = "gtree";
            this.gtree.Size = new System.Drawing.Size(347, 387);
            this.gtree.TabIndex = 2;
            this.gtree.TabStop = false;
            this.gtree.Text = "Tree";
            // 
            // TreeServer
            // 
            this.TreeServer.CheckBoxes = true;
            this.TreeServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TreeServer.LineColor = System.Drawing.Color.GreenYellow;
            this.TreeServer.Location = new System.Drawing.Point(3, 42);
            this.TreeServer.Name = "TreeServer";
            this.TreeServer.Size = new System.Drawing.Size(341, 342);
            this.TreeServer.TabIndex = 1;
            this.TreeServer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeServer_BeforeExpand);
            // 
            // toolStripTreeServer
            // 
            this.toolStripTreeServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.tsRemove,
            this.tsRefresh});
            this.toolStripTreeServer.Location = new System.Drawing.Point(3, 17);
            this.toolStripTreeServer.Name = "toolStripTreeServer";
            this.toolStripTreeServer.Size = new System.Drawing.Size(341, 25);
            this.toolStripTreeServer.TabIndex = 0;
            this.toolStripTreeServer.Text = "toolStripTree";
            // 
            // tabPageSQL
            // 
            this.tabPageSQL.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQL.Name = "tabPageSQL";
            this.tabPageSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQL.Size = new System.Drawing.Size(353, 393);
            this.tabPageSQL.TabIndex = 1;
            this.tabPageSQL.Text = "SQL";
            this.tabPageSQL.UseVisualStyleBackColor = true;
            // 
            // tabPageClass
            // 
            this.tabPageClass.Location = new System.Drawing.Point(4, 22);
            this.tabPageClass.Name = "tabPageClass";
            this.tabPageClass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClass.Size = new System.Drawing.Size(353, 393);
            this.tabPageClass.TabIndex = 2;
            this.tabPageClass.Text = "Class";
            this.tabPageClass.UseVisualStyleBackColor = true;
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
            this.rdFilterTable.Location = new System.Drawing.Point(8, 13);
            this.rdFilterTable.Name = "rdFilterTable";
            this.rdFilterTable.Size = new System.Drawing.Size(89, 16);
            this.rdFilterTable.TabIndex = 1;
            this.rdFilterTable.Text = "FilterTable";
            this.rdFilterTable.UseVisualStyleBackColor = true;
            // 
            // rdFilterColumn
            // 
            this.rdFilterColumn.AutoSize = true;
            this.rdFilterColumn.Checked = true;
            this.rdFilterColumn.Location = new System.Drawing.Point(8, 35);
            this.rdFilterColumn.Name = "rdFilterColumn";
            this.rdFilterColumn.Size = new System.Drawing.Size(95, 16);
            this.rdFilterColumn.TabIndex = 2;
            this.rdFilterColumn.TabStop = true;
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
            // tabPageCsharpGenerator
            // 
            this.tabPageCsharpGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabPageCsharpGenerator.Name = "tabPageCsharpGenerator";
            this.tabPageCsharpGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCsharpGenerator.Size = new System.Drawing.Size(1207, 638);
            this.tabPageCsharpGenerator.TabIndex = 1;
            this.tabPageCsharpGenerator.Text = "CSharp Generator";
            this.tabPageCsharpGenerator.UseVisualStyleBackColor = true;
            // 
            // tabPageString
            // 
            this.tabPageString.Location = new System.Drawing.Point(4, 22);
            this.tabPageString.Name = "tabPageString";
            this.tabPageString.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageString.Size = new System.Drawing.Size(1207, 638);
            this.tabPageString.TabIndex = 2;
            this.tabPageString.Text = "String";
            this.tabPageString.UseVisualStyleBackColor = true;
            // 
            // tabPageSQLCompare
            // 
            this.tabPageSQLCompare.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLCompare.Name = "tabPageSQLCompare";
            this.tabPageSQLCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLCompare.Size = new System.Drawing.Size(1207, 638);
            this.tabPageSQLCompare.TabIndex = 3;
            this.tabPageSQLCompare.Text = "SQL Compare";
            this.tabPageSQLCompare.UseVisualStyleBackColor = true;
            // 
            // tabPageSystemConfig
            // 
            this.tabPageSystemConfig.Controls.Add(this.tabControlSet);
            this.tabPageSystemConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemConfig.Name = "tabPageSystemConfig";
            this.tabPageSystemConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystemConfig.Size = new System.Drawing.Size(1207, 638);
            this.tabPageSystemConfig.TabIndex = 4;
            this.tabPageSystemConfig.Text = "System Config";
            this.tabPageSystemConfig.UseVisualStyleBackColor = true;
            // 
            // tabControlSet
            // 
            this.tabControlSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSet.Location = new System.Drawing.Point(3, 3);
            this.tabControlSet.Name = "tabControlSet";
            this.tabControlSet.SelectedIndex = 0;
            this.tabControlSet.Size = new System.Drawing.Size(1201, 632);
            this.tabControlSet.TabIndex = 0;
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
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(228, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // tsAdd
            // 
            this.tsAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsAdd.Image")));
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(117, 22);
            this.tsAdd.Text = "AddConnection";
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
            // 
            // txtFuzzyPercent
            // 
            this.txtFuzzyPercent.Location = new System.Drawing.Point(59, 55);
            this.txtFuzzyPercent.Name = "txtFuzzyPercent";
            this.txtFuzzyPercent.Size = new System.Drawing.Size(32, 21);
            this.txtFuzzyPercent.TabIndex = 3;
            this.txtFuzzyPercent.Text = "90";
            // 
            // treeSelectData
            // 
            this.treeSelectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSelectData.Location = new System.Drawing.Point(3, 17);
            this.treeSelectData.Name = "treeSelectData";
            this.treeSelectData.Size = new System.Drawing.Size(307, 312);
            this.treeSelectData.TabIndex = 0;
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
            // tabPageExecl
            // 
            this.tabPageExecl.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecl.Name = "tabPageExecl";
            this.tabPageExecl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExecl.Size = new System.Drawing.Size(353, 393);
            this.tabPageExecl.TabIndex = 3;
            this.tabPageExecl.Text = "FromExecl";
            this.tabPageExecl.UseVisualStyleBackColor = true;
            // 
            // GeneartorTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 686);
            this.Controls.Add(this.tabControlALL);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GeneartorTools";
            this.Text = "GeneratorTools";
            this.Load += new System.EventHandler(this.GeneartorTools_Load);
            this.tabControlALL.ResumeLayout(false);
            this.tabPageSQLGeneartor.ResumeLayout(false);
            this.PanSelectAndSnippet.ResumeLayout(false);
            this.bgselect.ResumeLayout(false);
            this.gbleft.ResumeLayout(false);
            this.tabControlSource.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.gtree.ResumeLayout(false);
            this.gtree.PerformLayout();
            this.toolStripTreeServer.ResumeLayout(false);
            this.toolStripTreeServer.PerformLayout();
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

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlALL;
        private System.Windows.Forms.TabPage tabPageSQLGeneartor;
        private System.Windows.Forms.TabPage tabPageCsharpGenerator;
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
        private System.Windows.Forms.TreeView TreeServer;
        private System.Windows.Forms.TabControl tabControlSet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdFuzzySearch;
        private System.Windows.Forms.RadioButton rdLikdSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdFilterTable;
        private System.Windows.Forms.RadioButton rdFilterColumn;
        private System.Windows.Forms.TabControl tabControlSource;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.TabPage tabPageSQL;
        private System.Windows.Forms.TabPage tabPageClass;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.TreeView treeSelectData;
        private System.Windows.Forms.TabPage tabPageExecl;
        private System.Windows.Forms.RadioButton rdComplete;
        private System.Windows.Forms.TextBox txtFuzzyPercent;
    }
}

