namespace WFGenerator
{
    partial class SelectTables
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTables));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.tabEnum = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comEnum = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAsy = new System.Windows.Forms.Button();
            this.ComPath = new System.Windows.Forms.ComboBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.databaseTrees = new WFGenerator.WinfromControl.DatabaseTree();
            this.tabs.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabEnum.SuspendLayout();
            this.SuspendLayout();
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
            // tabs
            // 
            this.tabs.Controls.Add(this.tabTable);
            this.tabs.Controls.Add(this.tabEnum);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(452, 524);
            this.tabs.TabIndex = 1;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.databaseTrees);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(444, 498);
            this.tabTable.TabIndex = 0;
            this.tabTable.Text = "Table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // tabEnum
            // 
            this.tabEnum.Controls.Add(this.txtPath);
            this.tabEnum.Controls.Add(this.lblPath);
            this.tabEnum.Controls.Add(this.ComPath);
            this.tabEnum.Controls.Add(this.btnAsy);
            this.tabEnum.Controls.Add(this.btnOk);
            this.tabEnum.Controls.Add(this.comEnum);
            this.tabEnum.Controls.Add(this.label2);
            this.tabEnum.Controls.Add(this.label1);
            this.tabEnum.Location = new System.Drawing.Point(4, 22);
            this.tabEnum.Name = "tabEnum";
            this.tabEnum.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnum.Size = new System.Drawing.Size(444, 498);
            this.tabEnum.TabIndex = 1;
            this.tabEnum.Text = "Enum";
            this.tabEnum.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "解析路劲";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "请选择枚举";
            // 
            // comEnum
            // 
            this.comEnum.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comEnum.FormattingEnabled = true;
            this.comEnum.Location = new System.Drawing.Point(80, 134);
            this.comEnum.Name = "comEnum";
            this.comEnum.Size = new System.Drawing.Size(356, 29);
            this.comEnum.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(279, 302);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAsy
            // 
            this.btnAsy.Location = new System.Drawing.Point(361, 181);
            this.btnAsy.Name = "btnAsy";
            this.btnAsy.Size = new System.Drawing.Size(75, 23);
            this.btnAsy.TabIndex = 5;
            this.btnAsy.Text = "自动解析";
            this.btnAsy.UseVisualStyleBackColor = true;
            this.btnAsy.Click += new System.EventHandler(this.btnAsy_Click);
            // 
            // ComPath
            // 
            this.ComPath.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComPath.FormattingEnabled = true;
            this.ComPath.Location = new System.Drawing.Point(81, 15);
            this.ComPath.Name = "ComPath";
            this.ComPath.Size = new System.Drawing.Size(355, 29);
            this.ComPath.TabIndex = 6;
            this.ComPath.SelectedIndexChanged += new System.EventHandler(this.ComPath_SelectedIndexChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(10, 87);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(53, 12);
            this.lblPath.TabIndex = 7;
            this.lblPath.Text = "解析目录";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(81, 84);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(355, 21);
            this.txtPath.TabIndex = 8;
            // 
            // databaseTrees
            // 
            this.databaseTrees.CheckBoxes = true;
            this.databaseTrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseTrees.listSnippet = null;
            this.databaseTrees.Location = new System.Drawing.Point(3, 3);
            this.databaseTrees.Name = "databaseTrees";
            this.databaseTrees.selectDataSoruceType = WFGenerator.SelectDataSoruceType.DataBase;
            this.databaseTrees.sh = null;
            this.databaseTrees.Size = new System.Drawing.Size(438, 492);
            this.databaseTrees.sqlite = null;
            this.databaseTrees.TabIndex = 0;
            this.databaseTrees.treeType = WFGenerator.TreeType.DataBase;
            this.databaseTrees.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.databaseTrees_NodeMouseDoubleClick);
            // 
            // SelectTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 524);
            this.Controls.Add(this.tabs);
            this.Name = "SelectTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectTables";
            this.tabs.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabEnum.ResumeLayout(false);
            this.tabEnum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WinfromControl.DatabaseTree databaseTrees;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.TabPage tabEnum;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comEnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsy;
        private System.Windows.Forms.ComboBox ComPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
    }
}