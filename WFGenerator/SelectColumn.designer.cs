namespace WFGenerator {
    partial class SelectColumn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectColumn));
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tselectAll = new System.Windows.Forms.ToolStripButton();
            this.treverse = new System.Windows.Forms.ToolStripButton();
            this.tcansel = new System.Windows.Forms.ToolStripButton();
            this.tok = new System.Windows.Forms.ToolStripButton();
            this.groupBoxGrid = new System.Windows.Forms.GroupBox();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.groupBoxOperation.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBoxGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.toolStrip1);
            this.groupBoxOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxOperation.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(1084, 50);
            this.groupBoxOperation.TabIndex = 0;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "操作选项";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tselectAll,
            this.treverse,
            this.tcansel,
            this.tok});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1078, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tselectAll
            // 
            this.tselectAll.Image = ((System.Drawing.Image)(resources.GetObject("tselectAll.Image")));
            this.tselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tselectAll.Name = "tselectAll";
            this.tselectAll.Size = new System.Drawing.Size(52, 27);
            this.tselectAll.Text = "全选";
            this.tselectAll.Click += new System.EventHandler(this.tselectAll_Click);
            // 
            // treverse
            // 
            this.treverse.Image = ((System.Drawing.Image)(resources.GetObject("treverse.Image")));
            this.treverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.treverse.Name = "treverse";
            this.treverse.Size = new System.Drawing.Size(52, 27);
            this.treverse.Text = "反选";
            this.treverse.Click += new System.EventHandler(this.treverse_Click);
            // 
            // tcansel
            // 
            this.tcansel.Image = ((System.Drawing.Image)(resources.GetObject("tcansel.Image")));
            this.tcansel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tcansel.Name = "tcansel";
            this.tcansel.Size = new System.Drawing.Size(52, 27);
            this.tcansel.Text = "取消";
            this.tcansel.Click += new System.EventHandler(this.tcansel_Click);
            // 
            // tok
            // 
            this.tok.Image = ((System.Drawing.Image)(resources.GetObject("tok.Image")));
            this.tok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tok.Name = "tok";
            this.tok.Size = new System.Drawing.Size(76, 27);
            this.tok.Text = "确定选择";
            this.tok.Click += new System.EventHandler(this.tok_Click);
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.datagrid);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Location = new System.Drawing.Point(0, 50);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(1084, 627);
            this.groupBoxGrid.TabIndex = 1;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "选择列";
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid.Location = new System.Drawing.Point(3, 17);
            this.datagrid.Name = "datagrid";
            this.datagrid.RowTemplate.Height = 23;
            this.datagrid.Size = new System.Drawing.Size(1078, 607);
            this.datagrid.TabIndex = 0;
            this.datagrid.CurrentCellChanged += new System.EventHandler(this.datagrid_CurrentCellChanged);
            // 
            // SelectColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 677);
            this.Controls.Add(this.groupBoxGrid);
            this.Controls.Add(this.groupBoxOperation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择需要生成的列";
            this.groupBoxOperation.ResumeLayout(false);
            this.groupBoxOperation.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxGrid;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tselectAll;
        private System.Windows.Forms.ToolStripButton treverse;
        private System.Windows.Forms.ToolStripButton tcansel;
        private System.Windows.Forms.ToolStripButton tok;
    }
}