namespace WFGenerator
{
    partial class SetSnippet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSnippet));
            this.lblContext = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGeneratorFileName = new System.Windows.Forms.TextBox();
            this.lalFileName = new System.Windows.Forms.Label();
            this.lblOutPath = new System.Windows.Forms.Label();
            this.txtParentId = new System.Windows.Forms.TextBox();
            this.lblparent = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.IsFloder = new System.Windows.Forms.CheckBox();
            this.IsEnabled = new System.Windows.Forms.CheckBox();
            this.IsSelectGenerator = new System.Windows.Forms.CheckBox();
            this.IsAutoFind = new System.Windows.Forms.CheckBox();
            this.IsMergin = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.txtDataSourceType = new System.Windows.Forms.ComboBox();
            this.txtOutputPath = new WFGenerator.TreeComboBox();
            this.txtText = new WFGenerator.SyntaxTextBox();
            this.SuspendLayout();
            // 
            // lblContext
            // 
            this.lblContext.AutoSize = true;
            this.lblContext.Location = new System.Drawing.Point(688, 130);
            this.lblContext.Name = "lblContext";
            this.lblContext.Size = new System.Drawing.Size(53, 12);
            this.lblContext.TabIndex = 0;
            this.lblContext.Text = "生成内容";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "模板名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(109, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtGeneratorFileName
            // 
            this.txtGeneratorFileName.Location = new System.Drawing.Point(389, 48);
            this.txtGeneratorFileName.Name = "txtGeneratorFileName";
            this.txtGeneratorFileName.Size = new System.Drawing.Size(164, 21);
            this.txtGeneratorFileName.TabIndex = 5;
            // 
            // lalFileName
            // 
            this.lalFileName.AutoSize = true;
            this.lalFileName.Location = new System.Drawing.Point(309, 51);
            this.lalFileName.Name = "lalFileName";
            this.lalFileName.Size = new System.Drawing.Size(65, 12);
            this.lalFileName.TabIndex = 4;
            this.lalFileName.Text = "生成文件名";
            // 
            // lblOutPath
            // 
            this.lblOutPath.AutoSize = true;
            this.lblOutPath.Location = new System.Drawing.Point(50, 83);
            this.lblOutPath.Name = "lblOutPath";
            this.lblOutPath.Size = new System.Drawing.Size(53, 12);
            this.lblOutPath.TabIndex = 6;
            this.lblOutPath.Text = "生成位置";
            // 
            // txtParentId
            // 
            this.txtParentId.Location = new System.Drawing.Point(389, 16);
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.Size = new System.Drawing.Size(164, 21);
            this.txtParentId.TabIndex = 11;
            // 
            // lblparent
            // 
            this.lblparent.AutoSize = true;
            this.lblparent.Location = new System.Drawing.Point(309, 19);
            this.lblparent.Name = "lblparent";
            this.lblparent.Size = new System.Drawing.Size(41, 12);
            this.lblparent.TabIndex = 10;
            this.lblparent.Text = "父目录";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(50, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 12);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "模板类型";
            // 
            // IsFloder
            // 
            this.IsFloder.AutoSize = true;
            this.IsFloder.Location = new System.Drawing.Point(105, 114);
            this.IsFloder.Name = "IsFloder";
            this.IsFloder.Size = new System.Drawing.Size(60, 16);
            this.IsFloder.TabIndex = 12;
            this.IsFloder.Text = "文件夹";
            this.IsFloder.UseVisualStyleBackColor = true;
            // 
            // IsEnabled
            // 
            this.IsEnabled.AutoSize = true;
            this.IsEnabled.Location = new System.Drawing.Point(186, 114);
            this.IsEnabled.Name = "IsEnabled";
            this.IsEnabled.Size = new System.Drawing.Size(48, 16);
            this.IsEnabled.TabIndex = 13;
            this.IsEnabled.Text = "启用";
            this.IsEnabled.UseVisualStyleBackColor = true;
            // 
            // IsSelectGenerator
            // 
            this.IsSelectGenerator.AutoSize = true;
            this.IsSelectGenerator.Location = new System.Drawing.Point(256, 114);
            this.IsSelectGenerator.Name = "IsSelectGenerator";
            this.IsSelectGenerator.Size = new System.Drawing.Size(84, 16);
            this.IsSelectGenerator.TabIndex = 14;
            this.IsSelectGenerator.Text = "选择生成列";
            this.IsSelectGenerator.UseVisualStyleBackColor = true;
            // 
            // IsAutoFind
            // 
            this.IsAutoFind.AutoSize = true;
            this.IsAutoFind.Location = new System.Drawing.Point(444, 114);
            this.IsAutoFind.Name = "IsAutoFind";
            this.IsAutoFind.Size = new System.Drawing.Size(72, 16);
            this.IsAutoFind.TabIndex = 15;
            this.IsAutoFind.Text = "自动查找";
            this.IsAutoFind.UseVisualStyleBackColor = true;
            // 
            // IsMergin
            // 
            this.IsMergin.AutoSize = true;
            this.IsMergin.Location = new System.Drawing.Point(359, 114);
            this.IsMergin.Name = "IsMergin";
            this.IsMergin.Size = new System.Drawing.Size(48, 16);
            this.IsMergin.TabIndex = 16;
            this.IsMergin.Text = "合并";
            this.IsMergin.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(606, 597);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(708, 597);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 18;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // txtDataSourceType
            // 
            this.txtDataSourceType.FormattingEnabled = true;
            this.txtDataSourceType.Location = new System.Drawing.Point(110, 10);
            this.txtDataSourceType.Name = "txtDataSourceType";
            this.txtDataSourceType.Size = new System.Drawing.Size(163, 20);
            this.txtDataSourceType.TabIndex = 19;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(109, 78);
            this.txtOutputPath.MaxDropDownItems = 12;
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(444, 21);
            this.txtOutputPath.TabIndex = 7;
            // 
            // txtText
            // 
            this.txtText.AcceptsTab = true;
            this.txtText.CaseSensitive = false;
            this.txtText.ConfigFile = "C:\\Users\\LYL\\AppData\\Local\\Microsoft\\VisualStudio\\16.0_bd9bec15\\ProjectAssemblies" +
    "\\qy-sf5i201\\csharp.xml";
            this.txtText.FilterAutoComplete = true;
            this.txtText.Location = new System.Drawing.Point(12, 156);
            this.txtText.MaxUndoRedoSteps = 50;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(788, 435);
            this.txtText.TabIndex = 1;
            this.txtText.Text = "";
            this.txtText.WordWrap = false;
            // 
            // SetSnippet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 632);
            this.Controls.Add(this.txtDataSourceType);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.IsMergin);
            this.Controls.Add(this.IsAutoFind);
            this.Controls.Add(this.IsSelectGenerator);
            this.Controls.Add(this.IsEnabled);
            this.Controls.Add(this.IsFloder);
            this.Controls.Add(this.txtParentId);
            this.Controls.Add(this.lblparent);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.lblOutPath);
            this.Controls.Add(this.txtGeneratorFileName);
            this.Controls.Add(this.lalFileName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblContext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetSnippet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetSnippet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContext;
        private SyntaxTextBox txtText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGeneratorFileName;
        private System.Windows.Forms.Label lalFileName;
        private System.Windows.Forms.Label lblOutPath;
        private TreeComboBox txtOutputPath;
        private System.Windows.Forms.TextBox txtParentId;
        private System.Windows.Forms.Label lblparent;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.CheckBox IsFloder;
        private System.Windows.Forms.CheckBox IsEnabled;
        private System.Windows.Forms.CheckBox IsSelectGenerator;
        private System.Windows.Forms.CheckBox IsAutoFind;
        private System.Windows.Forms.CheckBox IsMergin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox txtDataSourceType;
    }
}