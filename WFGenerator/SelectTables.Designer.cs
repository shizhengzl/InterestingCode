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
            this.databaseTrees = new WFGenerator.WinfromControl.DatabaseTree();
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
            // databaseTrees
            // 
            this.databaseTrees.CheckBoxes = true;
            this.databaseTrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseTrees.listSnippet = null;
            this.databaseTrees.Location = new System.Drawing.Point(0, 0);
            this.databaseTrees.Name = "databaseTrees";
            this.databaseTrees.selectDataSoruceType = WFGenerator.SelectDataSoruceType.DataBase;
            this.databaseTrees.sh = null;
            this.databaseTrees.Size = new System.Drawing.Size(387, 524);
            this.databaseTrees.sqlite = null;
            this.databaseTrees.TabIndex = 0;
            this.databaseTrees.treeType = WFGenerator.TreeType.DataBase;
            this.databaseTrees.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.databaseTrees_NodeMouseDoubleClick);
            // 
            // SelectTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 524);
            this.Controls.Add(this.databaseTrees);
            this.Name = "SelectTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectTables";
            this.ResumeLayout(false);

        }

        #endregion

        private WinfromControl.DatabaseTree databaseTrees;
        public System.Windows.Forms.ImageList imageList;
    }
}