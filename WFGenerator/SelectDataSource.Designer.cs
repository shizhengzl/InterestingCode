namespace WFGenerator
{
    partial class SelectDataSource
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
            this.txturl = new System.Windows.Forms.TextBox();
            this.lblurl = new System.Windows.Forms.Label();
            this.lalname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblkey = new System.Windows.Forms.Label();
            this.lblvalue = new System.Windows.Forms.Label();
            this.lblparent = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.comkey = new System.Windows.Forms.ComboBox();
            this.comvalue = new System.Windows.Forms.ComboBox();
            this.comparent = new System.Windows.Forms.ComboBox();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnEnum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(121, 45);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(461, 21);
            this.txturl.TabIndex = 0;
            this.txturl.Text = "/api/@TableName/Get";
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Location = new System.Drawing.Point(59, 48);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(29, 12);
            this.lblurl.TabIndex = 1;
            this.lblurl.Text = "URL:";
            // 
            // lalname
            // 
            this.lalname.AutoSize = true;
            this.lalname.Location = new System.Drawing.Point(59, 84);
            this.lalname.Name = "lalname";
            this.lalname.Size = new System.Drawing.Size(29, 12);
            this.lalname.TabIndex = 3;
            this.lalname.Text = "Name";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(121, 81);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(261, 21);
            this.txtname.TabIndex = 2;
            // 
            // lblkey
            // 
            this.lblkey.AutoSize = true;
            this.lblkey.Location = new System.Drawing.Point(59, 137);
            this.lblkey.Name = "lblkey";
            this.lblkey.Size = new System.Drawing.Size(23, 12);
            this.lblkey.TabIndex = 7;
            this.lblkey.Text = "Key";
            // 
            // lblvalue
            // 
            this.lblvalue.AutoSize = true;
            this.lblvalue.Location = new System.Drawing.Point(59, 172);
            this.lblvalue.Name = "lblvalue";
            this.lblvalue.Size = new System.Drawing.Size(35, 12);
            this.lblvalue.TabIndex = 9;
            this.lblvalue.Text = "Value";
            // 
            // lblparent
            // 
            this.lblparent.AutoSize = true;
            this.lblparent.Location = new System.Drawing.Point(59, 210);
            this.lblparent.Name = "lblparent";
            this.lblparent.Size = new System.Drawing.Size(41, 12);
            this.lblparent.TabIndex = 11;
            this.lblparent.Text = "Parent";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(492, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "O k";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comkey
            // 
            this.comkey.FormattingEnabled = true;
            this.comkey.Location = new System.Drawing.Point(121, 137);
            this.comkey.Name = "comkey";
            this.comkey.Size = new System.Drawing.Size(461, 20);
            this.comkey.TabIndex = 13;
            // 
            // comvalue
            // 
            this.comvalue.FormattingEnabled = true;
            this.comvalue.Location = new System.Drawing.Point(121, 172);
            this.comvalue.Name = "comvalue";
            this.comvalue.Size = new System.Drawing.Size(461, 20);
            this.comvalue.TabIndex = 14;
            // 
            // comparent
            // 
            this.comparent.FormattingEnabled = true;
            this.comparent.Location = new System.Drawing.Point(121, 207);
            this.comparent.Name = "comparent";
            this.comparent.Size = new System.Drawing.Size(461, 20);
            this.comparent.TabIndex = 15;
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(388, 81);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(75, 23);
            this.btnChose.TabIndex = 16;
            this.btnChose.Text = "选择表";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnEnum
            // 
            this.btnEnum.Location = new System.Drawing.Point(469, 81);
            this.btnEnum.Name = "btnEnum";
            this.btnEnum.Size = new System.Drawing.Size(75, 23);
            this.btnEnum.TabIndex = 17;
            this.btnEnum.Text = "选择枚举";
            this.btnEnum.UseVisualStyleBackColor = true;
            this.btnEnum.Click += new System.EventHandler(this.btnEnum_Click);
            // 
            // SelectDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 349);
            this.Controls.Add(this.btnEnum);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.comparent);
            this.Controls.Add(this.comvalue);
            this.Controls.Add(this.comkey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblparent);
            this.Controls.Add(this.lblvalue);
            this.Controls.Add(this.lblkey);
            this.Controls.Add(this.lalname);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblurl);
            this.Controls.Add(this.txturl);
            this.Name = "SelectDataSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectDataSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.Label lalname;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblkey;
        private System.Windows.Forms.Label lblvalue;
        private System.Windows.Forms.Label lblparent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comkey;
        private System.Windows.Forms.ComboBox comvalue;
        private System.Windows.Forms.ComboBox comparent;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnEnum;
    }
}