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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControlALL = new System.Windows.Forms.TabControl();
            this.tabPageSQLGeneartor = new System.Windows.Forms.TabPage();
            this.tabPageCsharpGenerator = new System.Windows.Forms.TabPage();
            this.tabPageString = new System.Windows.Forms.TabPage();
            this.tabPageSQLCompare = new System.Windows.Forms.TabPage();
            this.tabPageSystemConfig = new System.Windows.Forms.TabPage();
            this.tabControlALL.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
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
            this.tabControlALL.Size = new System.Drawing.Size(800, 465);
            this.tabControlALL.TabIndex = 1;
            // 
            // tabPageSQLGeneartor
            // 
            this.tabPageSQLGeneartor.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLGeneartor.Name = "tabPageSQLGeneartor";
            this.tabPageSQLGeneartor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQLGeneartor.Size = new System.Drawing.Size(792, 439);
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
            // GeneartorTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.tabControlALL);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GeneartorTools";
            this.Text = "GeneratorTools";
            this.tabControlALL.ResumeLayout(false);
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
    }
}

