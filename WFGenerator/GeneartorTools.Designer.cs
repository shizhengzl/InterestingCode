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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControlALL = new System.Windows.Forms.TabControl();
            this.tabPageSQLGeneartor = new System.Windows.Forms.TabPage();
            this.tabPageCsharpGenerator = new System.Windows.Forms.TabPage();
            this.tabPageString = new System.Windows.Forms.TabPage();
            this.tabPageSQLCompare = new System.Windows.Forms.TabPage();
            this.tabPageSystemConfig = new System.Windows.Forms.TabPage();
            this.gbleft = new System.Windows.Forms.GroupBox();
            this.bgselect = new System.Windows.Forms.GroupBox();
            this.PanSelectAndSnippet = new System.Windows.Forms.Panel();
            this.gbSnippet = new System.Windows.Forms.GroupBox();
            this.pSearch = new System.Windows.Forms.Panel();
            this.gtree = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TreeServer = new System.Windows.Forms.TreeView();
            this.tabControlALL.SuspendLayout();
            this.tabPageSQLGeneartor.SuspendLayout();
            this.gbleft.SuspendLayout();
            this.PanSelectAndSnippet.SuspendLayout();
            this.gtree.SuspendLayout();
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
            // tabPageCsharpGenerator
            // 
            this.tabPageCsharpGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabPageCsharpGenerator.Name = "tabPageCsharpGenerator";
            this.tabPageCsharpGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCsharpGenerator.Size = new System.Drawing.Size(792, 439);
            this.tabPageCsharpGenerator.TabIndex = 1;
            this.tabPageCsharpGenerator.Text = "CSharp Generator";
            this.tabPageCsharpGenerator.UseVisualStyleBackColor = true;
            // 
            // tabPageString
            // 
            this.tabPageString.Location = new System.Drawing.Point(4, 22);
            this.tabPageString.Name = "tabPageString";
            this.tabPageString.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageString.Size = new System.Drawing.Size(792, 439);
            this.tabPageString.TabIndex = 2;
            this.tabPageString.Text = "String";
            this.tabPageString.UseVisualStyleBackColor = true;
            // 
            // tabPageSQLCompare
            // 
            this.tabPageSQLCompare.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLCompare.Name = "tabPageSQLCompare";
            this.tabPageSQLCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLCompare.Size = new System.Drawing.Size(792, 439);
            this.tabPageSQLCompare.TabIndex = 3;
            this.tabPageSQLCompare.Text = "SQL Compare";
            this.tabPageSQLCompare.UseVisualStyleBackColor = true;
            // 
            // tabPageSystemConfig
            // 
            this.tabPageSystemConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemConfig.Name = "tabPageSystemConfig";
            this.tabPageSystemConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystemConfig.Size = new System.Drawing.Size(792, 439);
            this.tabPageSystemConfig.TabIndex = 4;
            this.tabPageSystemConfig.Text = "System Config";
            this.tabPageSystemConfig.UseVisualStyleBackColor = true;
            // 
            // gbleft
            // 
            this.gbleft.Controls.Add(this.gtree);
            this.gbleft.Controls.Add(this.pSearch);
            this.gbleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbleft.Location = new System.Drawing.Point(3, 3);
            this.gbleft.Name = "gbleft";
            this.gbleft.Size = new System.Drawing.Size(367, 632);
            this.gbleft.TabIndex = 0;
            this.gbleft.TabStop = false;
            this.gbleft.Text = "DataSource";
            // 
            // bgselect
            // 
            this.bgselect.Dock = System.Windows.Forms.DockStyle.Top;
            this.bgselect.Location = new System.Drawing.Point(0, 0);
            this.bgselect.Name = "bgselect";
            this.bgselect.Size = new System.Drawing.Size(313, 332);
            this.bgselect.TabIndex = 1;
            this.bgselect.TabStop = false;
            this.bgselect.Text = "SelectDataSource";
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
            // pSearch
            // 
            this.pSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSearch.Location = new System.Drawing.Point(3, 17);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(361, 117);
            this.pSearch.TabIndex = 1;
            // 
            // gtree
            // 
            this.gtree.Controls.Add(this.TreeServer);
            this.gtree.Controls.Add(this.toolStrip1);
            this.gtree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtree.Location = new System.Drawing.Point(3, 134);
            this.gtree.Name = "gtree";
            this.gtree.Size = new System.Drawing.Size(361, 495);
            this.gtree.TabIndex = 2;
            this.gtree.TabStop = false;
            this.gtree.Text = "Tree";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(355, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStripTree";
            // 
            // TreeServer
            // 
            this.TreeServer.CheckBoxes = true;
            this.TreeServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TreeServer.LineColor = System.Drawing.Color.GreenYellow;
            this.TreeServer.Location = new System.Drawing.Point(3, 42);
            this.TreeServer.Name = "TreeServer";
            this.TreeServer.Size = new System.Drawing.Size(355, 450);
            this.TreeServer.TabIndex = 1;
            this.TreeServer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeServer_BeforeExpand);
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
            this.gbleft.ResumeLayout(false);
            this.PanSelectAndSnippet.ResumeLayout(false);
            this.gtree.ResumeLayout(false);
            this.gtree.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.TreeView TreeServer;
    }
}
