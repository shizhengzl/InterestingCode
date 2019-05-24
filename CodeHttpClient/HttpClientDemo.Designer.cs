namespace CodeHttpClient
{
    partial class HttpClientDemo
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
            this.lCookies = new System.Windows.Forms.Label();
            this.tCookes = new System.Windows.Forms.TextBox();
            this.lMins = new System.Windows.Forms.Label();
            this.tMins = new System.Windows.Forms.TextBox();
            this.toks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tIntevers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bStarts = new System.Windows.Forms.Button();
            this.bCloses = new System.Windows.Forms.Button();
            this.timers = new System.Windows.Forms.Timer(this.components);
            this.tmessages = new System.Windows.Forms.TextBox();
            this.tGoodValue = new System.Windows.Forms.TextBox();
            this.lGoodValue = new System.Windows.Forms.Label();
            this.timerpoints = new System.Windows.Forms.Timer(this.components);
            this.tXian = new System.Windows.Forms.TextBox();
            this.lXian = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lCookies
            // 
            this.lCookies.AutoSize = true;
            this.lCookies.Location = new System.Drawing.Point(41, 60);
            this.lCookies.Name = "lCookies";
            this.lCookies.Size = new System.Drawing.Size(47, 12);
            this.lCookies.TabIndex = 0;
            this.lCookies.Text = "Cookies";
            // 
            // tCookes
            // 
            this.tCookes.Location = new System.Drawing.Point(94, 22);
            this.tCookes.Multiline = true;
            this.tCookes.Name = "tCookes";
            this.tCookes.Size = new System.Drawing.Size(305, 108);
            this.tCookes.TabIndex = 1;
            // 
            // lMins
            // 
            this.lMins.AutoSize = true;
            this.lMins.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lMins.Location = new System.Drawing.Point(18, 151);
            this.lMins.Name = "lMins";
            this.lMins.Size = new System.Drawing.Size(72, 16);
            this.lMins.TabIndex = 2;
            this.lMins.Text = "最小坐标";
            // 
            // tMins
            // 
            this.tMins.Location = new System.Drawing.Point(94, 146);
            this.tMins.Name = "tMins";
            this.tMins.Size = new System.Drawing.Size(305, 21);
            this.tMins.TabIndex = 3;
            this.tMins.Text = "256,546";
            // 
            // toks
            // 
            this.toks.Location = new System.Drawing.Point(95, 198);
            this.toks.Name = "toks";
            this.toks.Size = new System.Drawing.Size(304, 21);
            this.toks.TabIndex = 5;
            this.toks.Text = "561,536";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "确定坐标";
            // 
            // tIntevers
            // 
            this.tIntevers.Location = new System.Drawing.Point(95, 249);
            this.tIntevers.Name = "tIntevers";
            this.tIntevers.Size = new System.Drawing.Size(103, 21);
            this.tIntevers.TabIndex = 7;
            this.tIntevers.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "间隔秒";
            // 
            // tNumber
            // 
            this.tNumber.Location = new System.Drawing.Point(296, 254);
            this.tNumber.Name = "tNumber";
            this.tNumber.Size = new System.Drawing.Size(103, 21);
            this.tNumber.TabIndex = 9;
            this.tNumber.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(204, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "加减数值";
            // 
            // bStarts
            // 
            this.bStarts.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bStarts.Location = new System.Drawing.Point(61, 334);
            this.bStarts.Name = "bStarts";
            this.bStarts.Size = new System.Drawing.Size(137, 55);
            this.bStarts.TabIndex = 10;
            this.bStarts.Text = "开启定时器";
            this.bStarts.UseVisualStyleBackColor = true;
            this.bStarts.Click += new System.EventHandler(this.bStarts_Click);
            // 
            // bCloses
            // 
            this.bCloses.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bCloses.Location = new System.Drawing.Point(261, 334);
            this.bCloses.Name = "bCloses";
            this.bCloses.Size = new System.Drawing.Size(138, 55);
            this.bCloses.TabIndex = 11;
            this.bCloses.Text = "关闭定时器";
            this.bCloses.UseVisualStyleBackColor = true;
            this.bCloses.Click += new System.EventHandler(this.bCloses_Click);
            // 
            // timers
            // 
            this.timers.Interval = 1000;
            this.timers.Tick += new System.EventHandler(this.timers_Tick);
            // 
            // tmessages
            // 
            this.tmessages.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tmessages.ForeColor = System.Drawing.Color.Blue;
            this.tmessages.Location = new System.Drawing.Point(418, 22);
            this.tmessages.Multiline = true;
            this.tmessages.Name = "tmessages";
            this.tmessages.Size = new System.Drawing.Size(355, 367);
            this.tmessages.TabIndex = 12;
            // 
            // tGoodValue
            // 
            this.tGoodValue.Location = new System.Drawing.Point(94, 293);
            this.tGoodValue.Name = "tGoodValue";
            this.tGoodValue.Size = new System.Drawing.Size(103, 21);
            this.tGoodValue.TabIndex = 14;
            this.tGoodValue.Text = "1500";
            // 
            // lGoodValue
            // 
            this.lGoodValue.AutoSize = true;
            this.lGoodValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lGoodValue.Location = new System.Drawing.Point(8, 293);
            this.lGoodValue.Name = "lGoodValue";
            this.lGoodValue.Size = new System.Drawing.Size(80, 16);
            this.lGoodValue.TabIndex = 13;
            this.lGoodValue.Text = "GoodValue";
            // 
            // timerpoints
            // 
            this.timerpoints.Enabled = true;
            this.timerpoints.Tick += new System.EventHandler(this.timerpoints_Tick);
            // 
            // tXian
            // 
            this.tXian.Location = new System.Drawing.Point(93, 172);
            this.tXian.Name = "tXian";
            this.tXian.Size = new System.Drawing.Size(305, 21);
            this.tXian.TabIndex = 16;
            this.tXian.Text = "195,473";
            // 
            // lXian
            // 
            this.lXian.AutoSize = true;
            this.lXian.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lXian.Location = new System.Drawing.Point(17, 177);
            this.lXian.Name = "lXian";
            this.lXian.Size = new System.Drawing.Size(24, 16);
            this.lXian.TabIndex = 15;
            this.lXian.Text = "闲";
            // 
            // HttpClientDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tXian);
            this.Controls.Add(this.lXian);
            this.Controls.Add(this.tGoodValue);
            this.Controls.Add(this.lGoodValue);
            this.Controls.Add(this.tmessages);
            this.Controls.Add(this.bCloses);
            this.Controls.Add(this.bStarts);
            this.Controls.Add(this.tNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tIntevers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tMins);
            this.Controls.Add(this.lMins);
            this.Controls.Add(this.tCookes);
            this.Controls.Add(this.lCookies);
            this.Name = "HttpClientDemo";
            this.Text = "HttpClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCookies;
        private System.Windows.Forms.TextBox tCookes;
        private System.Windows.Forms.Label lMins;
        private System.Windows.Forms.TextBox tMins;
        private System.Windows.Forms.TextBox toks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tIntevers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bStarts;
        private System.Windows.Forms.Button bCloses;
        private System.Windows.Forms.Timer timers;
        private System.Windows.Forms.TextBox tmessages;
        private System.Windows.Forms.TextBox tGoodValue;
        private System.Windows.Forms.Label lGoodValue;
        private System.Windows.Forms.Timer timerpoints;
        private System.Windows.Forms.TextBox tXian;
        private System.Windows.Forms.Label lXian;
    }
}

