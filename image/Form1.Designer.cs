namespace image
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图均衡化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阈值滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.均值滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中值滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.低通滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对比度扩展ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消除小区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空域增强ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平腐蚀ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘增强ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kirsch算子锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplace算子锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewitt算子锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roberts算子锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobel算子锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(483, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(450, 425);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 486);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像灰度值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "G";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(310, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "R";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(597, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像坐标";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(173, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(27, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "X";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.图像处理ToolStripMenuItem,
            this.空域增强ToolStripMenuItem,
            this.图像锐化ToolStripMenuItem,
            this.dealToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开图片ToolStripMenuItem,
            this.保存图片ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开图片ToolStripMenuItem
            // 
            this.打开图片ToolStripMenuItem.Name = "打开图片ToolStripMenuItem";
            this.打开图片ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.打开图片ToolStripMenuItem.Text = "打开图片";
            this.打开图片ToolStripMenuItem.Click += new System.EventHandler(this.打开图片ToolStripMenuItem_Click);
            // 
            // 保存图片ToolStripMenuItem
            // 
            this.保存图片ToolStripMenuItem.Name = "保存图片ToolStripMenuItem";
            this.保存图片ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.保存图片ToolStripMenuItem.Text = "保存图片";
            this.保存图片ToolStripMenuItem.Click += new System.EventHandler(this.保存图片ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 图像处理ToolStripMenuItem
            // 
            this.图像处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直方图均衡化ToolStripMenuItem,
            this.阈值滤波ToolStripMenuItem,
            this.均值滤波ToolStripMenuItem,
            this.中值滤波ToolStripMenuItem,
            this.低通滤波ToolStripMenuItem,
            this.对比度扩展ToolStripMenuItem,
            this.消除小区域ToolStripMenuItem});
            this.图像处理ToolStripMenuItem.Name = "图像处理ToolStripMenuItem";
            this.图像处理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.图像处理ToolStripMenuItem.Text = "图像处理";
            // 
            // 直方图均衡化ToolStripMenuItem
            // 
            this.直方图均衡化ToolStripMenuItem.Name = "直方图均衡化ToolStripMenuItem";
            this.直方图均衡化ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.直方图均衡化ToolStripMenuItem.Text = "直方图均衡化";
            this.直方图均衡化ToolStripMenuItem.Click += new System.EventHandler(this.直方图均衡化ToolStripMenuItem_Click);
            // 
            // 阈值滤波ToolStripMenuItem
            // 
            this.阈值滤波ToolStripMenuItem.Name = "阈值滤波ToolStripMenuItem";
            this.阈值滤波ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.阈值滤波ToolStripMenuItem.Text = " 阈值滤波";
            this.阈值滤波ToolStripMenuItem.Click += new System.EventHandler(this.阈值滤波ToolStripMenuItem_Click);
            // 
            // 均值滤波ToolStripMenuItem
            // 
            this.均值滤波ToolStripMenuItem.Name = "均值滤波ToolStripMenuItem";
            this.均值滤波ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.均值滤波ToolStripMenuItem.Text = "均值滤波";
            this.均值滤波ToolStripMenuItem.Click += new System.EventHandler(this.均值滤波ToolStripMenuItem_Click);
            // 
            // 中值滤波ToolStripMenuItem
            // 
            this.中值滤波ToolStripMenuItem.Name = "中值滤波ToolStripMenuItem";
            this.中值滤波ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.中值滤波ToolStripMenuItem.Text = "中值滤波";
            this.中值滤波ToolStripMenuItem.Click += new System.EventHandler(this.中值滤波ToolStripMenuItem_Click);
            // 
            // 低通滤波ToolStripMenuItem
            // 
            this.低通滤波ToolStripMenuItem.Name = "低通滤波ToolStripMenuItem";
            this.低通滤波ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.低通滤波ToolStripMenuItem.Text = "低通滤波";
            this.低通滤波ToolStripMenuItem.Click += new System.EventHandler(this.低通滤波ToolStripMenuItem_Click);
            // 
            // 对比度扩展ToolStripMenuItem
            // 
            this.对比度扩展ToolStripMenuItem.Name = "对比度扩展ToolStripMenuItem";
            this.对比度扩展ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.对比度扩展ToolStripMenuItem.Text = "对比度扩展";
            this.对比度扩展ToolStripMenuItem.Click += new System.EventHandler(this.对比度扩展ToolStripMenuItem_Click);
            // 
            // 消除小区域ToolStripMenuItem
            // 
            this.消除小区域ToolStripMenuItem.Name = "消除小区域ToolStripMenuItem";
            this.消除小区域ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.消除小区域ToolStripMenuItem.Text = "消除小区域";
            this.消除小区域ToolStripMenuItem.Click += new System.EventHandler(this.消除小区域ToolStripMenuItem_Click);
            // 
            // 空域增强ToolStripMenuItem
            // 
            this.空域增强ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.水平腐蚀ToolStripMenuItem,
            this.边缘增强ToolStripMenuItem});
            this.空域增强ToolStripMenuItem.Name = "空域增强ToolStripMenuItem";
            this.空域增强ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.空域增强ToolStripMenuItem.Text = "空域增强";
            // 
            // 水平腐蚀ToolStripMenuItem
            // 
            this.水平腐蚀ToolStripMenuItem.Name = "水平腐蚀ToolStripMenuItem";
            this.水平腐蚀ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.水平腐蚀ToolStripMenuItem.Text = "水平腐蚀";
            this.水平腐蚀ToolStripMenuItem.Click += new System.EventHandler(this.水平腐蚀ToolStripMenuItem_Click);
            // 
            // 边缘增强ToolStripMenuItem
            // 
            this.边缘增强ToolStripMenuItem.Name = "边缘增强ToolStripMenuItem";
            this.边缘增强ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.边缘增强ToolStripMenuItem.Text = "边缘增强";
            this.边缘增强ToolStripMenuItem.Click += new System.EventHandler(this.边缘增强ToolStripMenuItem_Click);
            // 
            // 图像锐化ToolStripMenuItem
            // 
            this.图像锐化ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kirsch算子锐化ToolStripMenuItem,
            this.laplace算子锐化ToolStripMenuItem,
            this.prewitt算子锐化ToolStripMenuItem,
            this.roberts算子锐化ToolStripMenuItem,
            this.sobel算子锐化ToolStripMenuItem});
            this.图像锐化ToolStripMenuItem.Name = "图像锐化ToolStripMenuItem";
            this.图像锐化ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.图像锐化ToolStripMenuItem.Text = "图像锐化";
            this.图像锐化ToolStripMenuItem.Click += new System.EventHandler(this.图像锐化ToolStripMenuItem_Click);
            // 
            // kirsch算子锐化ToolStripMenuItem
            // 
            this.kirsch算子锐化ToolStripMenuItem.Name = "kirsch算子锐化ToolStripMenuItem";
            this.kirsch算子锐化ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.kirsch算子锐化ToolStripMenuItem.Text = "kirsch算子锐化";
            this.kirsch算子锐化ToolStripMenuItem.Click += new System.EventHandler(this.kirsch算子锐化ToolStripMenuItem_Click);
            // 
            // laplace算子锐化ToolStripMenuItem
            // 
            this.laplace算子锐化ToolStripMenuItem.Name = "laplace算子锐化ToolStripMenuItem";
            this.laplace算子锐化ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.laplace算子锐化ToolStripMenuItem.Text = "laplace算子锐化";
            this.laplace算子锐化ToolStripMenuItem.Click += new System.EventHandler(this.laplace算子锐化ToolStripMenuItem_Click);
            // 
            // prewitt算子锐化ToolStripMenuItem
            // 
            this.prewitt算子锐化ToolStripMenuItem.Name = "prewitt算子锐化ToolStripMenuItem";
            this.prewitt算子锐化ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.prewitt算子锐化ToolStripMenuItem.Text = "prewitt算子锐化";
            this.prewitt算子锐化ToolStripMenuItem.Click += new System.EventHandler(this.prewitt算子锐化ToolStripMenuItem_Click);
            // 
            // roberts算子锐化ToolStripMenuItem
            // 
            this.roberts算子锐化ToolStripMenuItem.Name = "roberts算子锐化ToolStripMenuItem";
            this.roberts算子锐化ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.roberts算子锐化ToolStripMenuItem.Text = "roberts算子锐化";
            this.roberts算子锐化ToolStripMenuItem.Click += new System.EventHandler(this.roberts算子锐化ToolStripMenuItem_Click);
            // 
            // sobel算子锐化ToolStripMenuItem
            // 
            this.sobel算子锐化ToolStripMenuItem.Name = "sobel算子锐化ToolStripMenuItem";
            this.sobel算子锐化ToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.sobel算子锐化ToolStripMenuItem.Text = "sobel算子锐化";
            this.sobel算子锐化ToolStripMenuItem.Click += new System.EventHandler(this.sobel算子锐化ToolStripMenuItem_Click);
            // 
            // dealToolStripMenuItem
            // 
            this.dealToolStripMenuItem.Name = "dealToolStripMenuItem";
            this.dealToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.dealToolStripMenuItem.Text = "deal";
            this.dealToolStripMenuItem.Click += new System.EventHandler(this.dealToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "label5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(683, 468);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 599);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空域增强ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像锐化ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem 直方图均衡化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阈值滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 均值滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中值滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kirsch算子锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplace算子锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewitt算子锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roberts算子锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobel算子锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 低通滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对比度扩展ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水平腐蚀ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘增强ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消除小区域ToolStripMenuItem;
    }
}

