using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        int iw, ih;
        int BPP = 4;
        

        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "图像文件(*.BMP)|*.BMP|All File(*.*)|*.*";
            saveFileDialog1.ShowDialog();
            str = saveFileDialog1.FileName;
            pictureBox2.Image.Save(str);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 打开图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;//先设置两个picturebox为空
            pictureBox2.Image = null;
            //使用 OpenFileDialog类打开图片
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图像文件(*.bmp;*.jpg;*gif;*png;*.tif;*.wmf)|"
             + "*.bmp;*jpg;*gif;*png;*.tif;*.wmf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bitmap = (Bitmap)Image.FromFile(open.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                pictureBox1.Refresh();
                pictureBox1.Image = bitmap;
                label5.Text = "原图";
                iw = bitmap.Width;
                ih = bitmap.Height;
            }

        }

        //读取灰度值及坐标
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Color pointRGB = bitmap.GetPixel(e.X, e.Y);
            textBox1.Text = pointRGB.R.ToString();
            textBox2.Text = pointRGB.G.ToString();
            textBox3.Text = pointRGB.B.ToString();
            textBox4.Text = e.X.ToString();
            textBox5.Text = e.Y.ToString();
            int a = int.Parse(textBox1.Text);
        }


        private void 直方图均衡化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = " 图像增强 直方图均衡化";
                Bitmap bm = new Bitmap(pictureBox1.Image);
                //获取直方图
                int[] hist = gethist(bm, iw, ih);

                //直方图均匀化
                bm = histequal(bm, hist, iw, ih);

                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "直方图均衡化结果";

            }
        }


        //获取直方图
        public int[] gethist(Bitmap bm, int iw, int ih)
        {
            int[] h = new int[256];
            for (int j = 0; j < ih; j++)
            {
                for (int i = 0; i < iw; i++)
                {
                    int grey = (bm.GetPixel(i, j)).R;
                    h[grey]++;
                }
            }
            return h;
        }
        //直方图均衡化
        public Bitmap histequal(Bitmap bm, int[] hist, int iw, int ih)
        {
            Color c = new Color();
            double p = (double)255 / (iw * ih);
            double[] sum = new double[256];
            int[] outg = new int[256];
            int r, g, b;
            sum[0] = hist[0];
            for (int i = 1; i < 256; i++)
                sum[i] = sum[i - 1] + hist[i];



            //灰度变换:i-->outg[i] 
            for (int i = 0; i < 256; i++)
                outg[i] = (int)(p * sum[i]);

            for (int j = 0; j < ih; j++)
            {
                for (int i = 0; i < iw; i++)
                {
                    r = (bm.GetPixel(i, j)).R;
                    g = (bm.GetPixel(i, j)).G;
                    b = (bm.GetPixel(i, j)).B;
                    c = Color.FromArgb(outg[r], outg[g], outg[b]);
                    bm.SetPixel(i, j, c);
                }
            }
            return bm;
        }

        public void drawHist(int[] h1, int[] h2)
        {
            //画原图直方图------------------------------------------
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue);
            g.Clear(this.BackColor);

            //找出最大的数,进行标准化.
            int maxn = h1[0];
            for (int i = 1; i < 256; i++)
                if (maxn < h1[i])
                    maxn = h1[i];

            for (int i = 0; i < 256; i++)
                h1[i] = h1[i] * 250 / maxn;

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 255, 255);

            pen1.Color = Color.Red;
            for (int i = 0; i < 256; i++)
                g.DrawLine(pen1, i, 255, i, 255 - h1[i]);

            g.DrawString("" + maxn, this.Font, new SolidBrush(Color.Blue), 0, 0);

            label6.Text = "原图直方图";

            //画均衡化后直方图------------------------------------------
            g = pictureBox2.CreateGraphics();
            pen1 = new Pen(Color.Blue);
            g.Clear(this.BackColor);

            //找出最大的数,进行标准化.
            maxn = h2[0];
            for (int i = 1; i < 256; i++)
                if (maxn < h2[i])
                    maxn = h2[i];

            for (int i = 0; i < 256; i++)
                h2[i] = h2[i] * 250 / maxn;

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 255, 255);

            pen1.Color = Color.Red;
            for (int i = 0; i < 256; i++)
                g.DrawLine(pen1, i, 255, i, 255 - h2[i]);

            g.DrawString("" + maxn, this.Font, new SolidBrush(Color.Blue), 0, 0);
            label7.Text = "均衡化后直方图";

        }

        private void 阈值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = "图像增强 阈值滤波";
                Bitmap bm = new Bitmap(pictureBox1.Image);
                //阈值滤波
                bm = threshold(bm, iw, ih);

                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "阈值滤波结果";
            }
        }


        //3×3阈值滤波
        public Bitmap threshold(Bitmap bm, int iw, int ih)
        {
            Bitmap obm = new Bitmap(pictureBox1.Image);


            int avr,  //灰度平均 
            sum,  //灰度和
            num = 0, //计数器
            nT = 4, //计数器阈值
            T = 50; //阈值
            int pij, pkl, //(i,j),(i+k,j+l)处灰度值
            err;  //误差


            for (int j = 1; j < ih - 1; j++)
            {
                for (int i = 1; i < iw - 1; i++)
                {
                    //取3×3块的9个象素, 求和
                    sum = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if ((k != 0) || (l != 0))
                            {
                                pkl = (bm.GetPixel(i + k, j + l)).R;
                                pij = (bm.GetPixel(i, j)).R;
                                err = Math.Abs(pkl - pij);
                                sum = sum + pkl;
                                if (err > T) num++;
                            }
                        }
                    }
                    avr = (int)(sum / 8.0f);  //平均值
                    if (num > nT)
                        obm.SetPixel(i, j, Color.FromArgb(avr, avr, avr));
                }
            }
            return obm;
        }

        private void 均值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = "数字图像处理";
                Bitmap bm = new Bitmap(pictureBox1.Image);
                bm = average(bm, iw, ih);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "均值滤波结果";
            }
        }
        //均值滤波
        public Bitmap average(Bitmap bm, int iw, int ih)
        {
            Bitmap obm = new Bitmap(pictureBox1.Image);
            for (int j = 1; j < ih - 1; j++)
            {
                for (int i = 1; i < iw - 1; i++)
                {
                    int avr;
                    int avr1;
                    int avr2;
                    int sum = 0;
                    int sum1 = 0;
                    int sum2 = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            sum = sum + (bm.GetPixel(i + k, j + 1).R);
                            sum1 = sum1 + (bm.GetPixel(i + k, j + 1).G);
                            sum2 = sum2 + (bm.GetPixel(i + k, j + 1).B);
                        }
                    }
                    avr = (int)(sum / 9.0f);
                    avr1 = (int)(sum1 / 9.0f);
                    avr2 = (int)(sum2 / 9.0f);
                    obm.SetPixel(i, j, Color.FromArgb(avr, avr1, avr2));
                }
            }
            return obm;
        }

        private void 中值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {

                this.Text = "图像增强 中值滤波";
                Bitmap bm = new Bitmap(pictureBox1.Image);
                int num = 3;
                //中值滤波
                bm = median(bm, iw, ih, num);

                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label2.Location = new Point(370, 280);
                if (num == 1) label7.Text = "1X5窗口滤波结果";
                else if (num == 2) label7.Text = "5X1窗口滤波结果";
                else if (num == 3) label7.Text = "5X5窗口滤波结果";

            }
        }

        //中值滤波方法
        public Bitmap median(Bitmap bm, int iw, int ih, int n)
        {
            Bitmap obm = new Bitmap(pictureBox1.Image);
            for (int j = 2; j < ih - 2; j++)
            {
                int[] dt;
                int[] dt1;
                int[] dt2;
                for (int i = 2; i < iw - 2; i++)
                {
                    int m = 0, r = 0, r1 = 0, r2 = 0, a = 0, b = 0;
                    if (n == 3)
                    {
                        dt = new int[25];
                        dt1 = new int[25];
                        dt2 = new int[25];
                        //取5×5块的25个象素
                        for (int k = -2; k < 3; k++)
                        {
                            for (int l = -2; l < 3; l++)
                            {
                                //取(i+k,j+l)处的象素，赋于数组dt
                                dt[m] = (bm.GetPixel(i + k, j + l)).R;
                                dt1[a] = (bm.GetPixel(i + k, j + l)).G;
                                dt2[b] = (bm.GetPixel(i + k, j + l)).B;
                                m++;
                                a++;
                                b++;
                            }
                        }
                        //冒泡排序,输出中值
                        r = median_sorter(dt, 25); //中值 
                        r1 = median_sorter(dt1, 25);
                        r2 = median_sorter(dt2, 25);
                    }
                    else if (n == 1)
                    {
                        dt = new int[5];

                        //取1×5窗口5个像素
                        dt[0] = (bm.GetPixel(i, j - 2)).R;
                        dt[1] = (bm.GetPixel(i, j - 1)).R;
                        dt[2] = (bm.GetPixel(i, j)).R;
                        dt[3] = (bm.GetPixel(i, j + 1)).R;
                        dt[4] = (bm.GetPixel(i, j + 2)).R;
                        r = median_sorter(dt, 5); //中值
                        dt1 = new int[5];


                        //取1×5窗口5个像素
                        dt1[0] = (bm.GetPixel(i, j - 2)).G;
                        dt1[1] = (bm.GetPixel(i, j - 1)).G;
                        dt1[2] = (bm.GetPixel(i, j)).G;
                        dt1[3] = (bm.GetPixel(i, j + 1)).G;
                        dt1[4] = (bm.GetPixel(i, j + 2)).G;
                        r1 = median_sorter(dt1, 5); //中值 
                        dt2 = new int[5];


                        //取1×5窗口5个像素
                        dt2[0] = (bm.GetPixel(i, j - 2)).B;
                        dt2[1] = (bm.GetPixel(i, j - 1)).B;
                        dt2[2] = (bm.GetPixel(i, j)).B;
                        dt2[3] = (bm.GetPixel(i, j + 1)).B;
                        dt2[4] = (bm.GetPixel(i, j + 2)).B;
                        r2 = median_sorter(dt2, 5); //中值    
                    }
                    else if (n == 2)
                    {
                        dt = new int[5];


                        //取5×1窗口5个像素
                        dt[0] = (bm.GetPixel(i - 2, j)).R;
                        dt[1] = (bm.GetPixel(i - 1, j)).R;
                        dt[2] = (bm.GetPixel(i, j)).R;
                        dt[3] = (bm.GetPixel(i + 1, j)).R;
                        dt[4] = (bm.GetPixel(i + 2, j)).R;
                        r = median_sorter(dt, 5); //中值 dt = new int[5];


                        //取5×1窗口5个像素
                        dt1 = new int[5];
                        dt1[0] = (bm.GetPixel(i - 2, j)).G;
                        dt1[1] = (bm.GetPixel(i - 1, j)).G;
                        dt1[2] = (bm.GetPixel(i, j)).G;
                        dt1[3] = (bm.GetPixel(i + 1, j)).G;
                        dt1[4] = (bm.GetPixel(i + 2, j)).G;
                        r1 = median_sorter(dt1, 5); //中值 

                        //取5×1窗口5个像素
                        dt2 = new int[5];
                        dt2[0] = (bm.GetPixel(i - 2, j)).B;
                        dt2[1] = (bm.GetPixel(i - 1, j)).B;
                        dt2[2] = (bm.GetPixel(i, j)).B;
                        dt2[3] = (bm.GetPixel(i + 1, j)).B;
                        dt2[4] = (bm.GetPixel(i + 2, j)).B;
                        r2 = median_sorter(dt2, 5); //中值 

                    }
                    obm.SetPixel(i, j, Color.FromArgb(r, r1, r2));  //输出   
                }
            }
            return obm;
        }


        //冒泡排序,输出中值
        public int median_sorter(int[] dt, int m)
        {
            int tem;
            for (int k = m - 1; k >= 1; k--)
                for (int l = 1; l <= k; l++)
                    if (dt[l - 1] > dt[l])
                    {
                        tem = dt[l];
                        dt[l] = dt[l - 1];
                        dt[l - 1] = tem;
                    }
            return dt[(int)(m / 2)];
        }

        private void 图像锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public Bitmap detect(Bitmap bm, int iw, int ih, int num)
        {

            Bitmap b1 = new Bitmap(pictureBox1.Image);

            Color c = new Color();
            int i, j, r;
            int[,] inr = new int[iw, ih]; //红色分量矩阵
            int[,] ing = new int[iw, ih]; //绿色分量矩阵
            int[,] inb = new int[iw, ih]; //蓝色分量矩阵
            int[,] gray = new int[iw, ih];//灰度图像矩阵 

            //转变为灰度图像矩阵

            for (j = 0; j < ih; j++)
            {
                for (i = 0; i < iw; i++)
                {
                    c = bm.GetPixel(i, j);
                    inr[i, j] = c.R;
                    ing[i, j] = c.G;
                    inb[i, j] = c.B;
                    gray[i, j] = (int)((c.R + c.G + c.B) / 3.0);
                }
            }
            if (num == 1)//Kirsch
            {
                int[,] kir0 = {{ 5, 5, 5},
                               {-3, 0,-3},
                               {-3,-3,-3}},//kir0

                 kir1 = {{-3, 5, 5},
                         {-3, 0, 5},
                         {-3,-3,-3}},//kir1

                 kir2 = {{-3,-3, 5},
                         {-3, 0, 5},
                         {-3,-3, 5}},//kir2

                 kir3 = {{-3,-3,-3},
                         {-3, 0, 5},
                         {-3, 5, 5}},//kir3

                 kir4 = {{-3,-3,-3},
                         {-3, 0,-3},
                         { 5, 5, 5}},//kir4

                 kir5 = {{-3,-3,-3},
                         { 5, 0,-3},
                         { 5, 5,-3}},//kir5

                 kir6 = {{ 5,-3,-3},
                         { 5, 0,-3},
                         { 5,-3,-3}},//kir6

                 kir7 = {{ 5, 5,-3},
                         { 5, 0,-3},
                         {-3,-3,-3}};//kir7 
                //边缘检测

                int[,] edge0 = new int[iw, ih];

                int[,] edge1 = new int[iw, ih];

                int[,] edge2 = new int[iw, ih];

                int[,] edge3 = new int[iw, ih];

                int[,] edge4 = new int[iw, ih];

                int[,] edge5 = new int[iw, ih];

                int[,] edge6 = new int[iw, ih];

                int[,] edge7 = new int[iw, ih];

                edge0 = edgeEnhance(gray, kir0, iw, ih);
                edge1 = edgeEnhance(gray, kir1, iw, ih);
                edge2 = edgeEnhance(gray, kir2, iw, ih);
                edge3 = edgeEnhance(gray, kir3, iw, ih);
                edge4 = edgeEnhance(gray, kir4, iw, ih);
                edge5 = edgeEnhance(gray, kir5, iw, ih);
                edge6 = edgeEnhance(gray, kir6, iw, ih);
                edge7 = edgeEnhance(gray, kir7, iw, ih);

                int[] tem = new int[8];
                int max;
                for (j = 0; j < ih; j++)
                {
                    for (i = 0; i < iw; i++)
                    {
                        tem[0] = edge0[i, j];
                        tem[1] = edge1[i, j];
                        tem[2] = edge2[i, j];
                        tem[3] = edge3[i, j];
                        tem[4] = edge4[i, j];
                        tem[5] = edge5[i, j];
                        tem[6] = edge6[i, j];
                        tem[7] = edge7[i, j];
                        max = 0;
                        for (int k = 0; k < 8; k++)
                            if (tem[k] > max) max = tem[k];
                        if (max > 255) max = 255;
                        r = 255 - max;
                        b1.SetPixel(i, j, Color.FromArgb(r, r, r));
                    }
                }
            }
            else if (num == 2)   //Laplace
            {
                int[,] lap1 = {{ 1, 1, 1},
                               { 1,-8, 1},
                               { 1, 1, 1}};

                /*byte[][] lap2 = {{ 0, 1, 0},
                   { 1,-4, 1},
                   { 0, 1, 0}}; */

                //边缘增强
                int[,] edge = edgeEnhance(gray, lap1, iw, ih);

                for (j = 0; j < ih; j++)
                {
                    for (i = 0; i < iw; i++)
                    {
                        r = edge[i, j];
                        if (r > 255) r = 255;

                        if (r < 0) r = 0;
                        c = Color.FromArgb(r, r, r);
                        b1.SetPixel(i, j, c);
                    }
                }
            }
            else if (num == 3)//Prewitt
            {
                //Prewitt算子D_x模板
                int[,] pre1 = {{ 1, 0,-1},
                               { 1, 0,-1},
                               { 1, 0,-1}};

                //Prewitt算子D_y模板
                int[,] pre2 = {{ 1, 1, 1},
                               { 0, 0, 0},
                               {-1,-1,-1}};
                int[,] edge1 = edgeEnhance(gray, pre1, iw, ih);

                int[,] edge2 = edgeEnhance(gray, pre2, iw, ih);
                for (j = 0; j < ih; j++)
                {
                    for (i = 0; i < iw; i++)
                    {
                        r = Math.Max(edge1[i, j], edge2[i, j]);

                        if (r > 255) r = 255;
                        c = Color.FromArgb(r, r, r);
                        b1.SetPixel(i, j, c);
                    }
                }
            }

            else if (num == 5)    //Sobel
            {
                int[,] sob1 = {{ 1, 0,-1},
                               { 2, 0,-2},
                               { 1, 0,-1}};
                int[,] sob2 = {{ 1, 2, 1},
                               { 0, 0, 0},
                               {-1,-2,-1}};


                int[,] edge1 = edgeEnhance(gray, sob1, iw, ih);
                int[,] edge2 = edgeEnhance(gray, sob2, iw, ih);
                for (j = 0; j < ih; j++)
                {
                    for (i = 0; i < iw; i++)
                    {
                        r = Math.Max(edge1[i, j], edge2[i, j]);
                        if (r > 255) r = 255;
                        c = Color.FromArgb(r, r, r);
                        b1.SetPixel(i, j, c);
                    }
                }
            }
            return b1;
        }
        private void kirsch算子锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                // this.Text = " 图像 - 图像锐化 - Kirsch算子";
                Bitmap bm = new Bitmap(pictureBox1.Image);
                //1: Kirsch锐化
                bm = detect(bm, iw, ih, 1);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = " Kirsch算子 锐化结果";
            }
        }
        public int[,] edgeEnhance(int[,] ing, int[,] tmp, int iw, int ih)
        {
            int[,] ed = new int[iw, ih];
            for (int j = 1; j < ih - 1; j++)
            {
                for (int i = 1; i < iw - 1; i++)
                {
                    ed[i, j] = Math.Abs(tmp[0, 0] * ing[i - 1, j - 1]
                     + tmp[0, 1] * ing[i - 1, j] + tmp[0, 2] * ing[i - 1, j + 1]
                     + tmp[1, 0] * ing[i, j - 1] + tmp[1, 1] * ing[i, j]
                     + tmp[1, 2] * ing[i, j + 1] + tmp[2, 0] * ing[i + 1, j - 1]
                     + tmp[2, 1] * ing[i + 1, j] + tmp[2, 2] * ing[i + 1, j + 1]);
                }
            }
            return ed;
        }
        //Laplace算子
        private void laplace算子锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);

                //2: Laplace锐化 
                bm = detect(bm, iw, ih, 2);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "Laplace算子 锐化结果";
            }
        }

        //Prewitt算子
        private void prewitt算子锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {

                Bitmap bm = new Bitmap(pictureBox1.Image);
                //3:Prewitt锐化
                bm = detect(bm, iw, ih, 3);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label2.Location = new Point(390, 280);
                label7.Text = " Prewitt算子 锐化结果";
            }
        }


        //Roberts算子
        private void roberts算子锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);
                //Robert边缘检测 
                bm = robert(bm, iw, ih);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label2.Location = new Point(390, 280);
                label7.Text = "Roberts算子 锐化结果";
            }
        }

        //roberts算法
        public Bitmap robert(Bitmap bm, int iw, int ih)
        {
            int r, r0, r1, r2, r3, g, g0, g1, g2, g3, b, b0, b1, b2, b3;
            Bitmap obm = new Bitmap(pictureBox1.Image);
            int[,] inr = new int[iw, ih];//红色分量矩阵
            int[,] ing = new int[iw, ih];//绿色分量矩阵
            int[,] inb = new int[iw, ih];//蓝色分量矩阵
            int[,] gray = new int[iw, ih];//灰度图像矩阵  

            for (int j = 1; j < ih - 1; j++)
            {
                for (int i = 1; i < iw - 1; i++)
                {
                    r0 = (bm.GetPixel(i, j)).R;
                    r1 = (bm.GetPixel(i, j + 1)).R;
                    r2 = (bm.GetPixel(i + 1, j)).R;
                    r3 = (bm.GetPixel(i + 1, j + 1)).R;

                    r = (int)Math.Sqrt((r0 - r3) * (r0 - r3) + (r1 - r2) * (r1 - r2));

                    g0 = (bm.GetPixel(i, j)).G;
                    g1 = (bm.GetPixel(i, j + 1)).G;
                    g2 = (bm.GetPixel(i + 1, j)).G;
                    g3 = (bm.GetPixel(i + 1, j + 1)).G;
                    g = (int)Math.Sqrt((g0 - g3) * (g0 - g3) + (g1 - g2) * (g1 - g2));

                    b0 = (bm.GetPixel(i, j)).B;
                    b1 = (bm.GetPixel(i, j + 1)).B;
                    b2 = (bm.GetPixel(i + 1, j)).B;
                    b3 = (bm.GetPixel(i + 1, j + 1)).B;
                    b = (int)Math.Sqrt((b0 - b3) * (b0 - b3)+ (b1 - b2) * (b1 - b2));

                    if (r < 0)
                        r = 255;     //黑色，边缘点
                    if (r > 255)
                        r = 0;

                    obm.SetPixel(i, j, Color.FromArgb(r, r, r));
                }
            }
            return obm;
        }
        //Sobel算子
        private void sobel算子锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);
                //5: Sobel锐化
                bm = Sobel(bm);

                pictureBox2.Refresh();
                pictureBox2.Image = bm;

                label7.Text = " Sobel算子 锐化结果";
            }
        }

        private Bitmap Gradient(Bitmap b1,Bitmap b2)
        {
            int width = b1.Width;
            int height = b1.Height;

            BitmapData data1 = b1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            BitmapData data2 = b2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* p1 = (byte*)data1.Scan0;
                byte* p2 = (byte*)data2.Scan0;

                int offset = data1.Stride - width * 4;

                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            int power = (int)Math.Sqrt((p1[i] * p1[i] + p2[i] * p2[i]));
                            p1[i] = (byte)(power > 255 ? 255 : power);
                        }//i

                        p1 += 4;
                        p2 += 4;
                    }//x
                    p1 += offset;
                    p2 += offset;
                }//y
            }
            b1.UnlockBits(data1);
            b2.UnlockBits(data2);

            Bitmap dstImage = (Bitmap)b1.Clone();

            b1.Dispose();
            b2.Dispose();

            return dstImage;
        }

        public Bitmap Sobel(Bitmap bm)
        {
            Matrix3x3 m1 = new Matrix3x3();
            Matrix3x3 m2 = new Matrix3x3();
            Matrix3x3 m3 = new Matrix3x3();
            Matrix3x3 m4 = new Matrix3x3();

            m1.Init(0);
            m1.topLeft = m1.topRight = -1;
            m1.bottomLeft = m1.bottomRight = 1;
            m1.topMid = -2;
            m1.bottomMid = 2;
            Bitmap bl = m1.Convolute((Bitmap)bm.Clone());

            m2.Init(0);
            m2.topLeft = m2.bottomLeft = -1;
            m2.topRight = m2.bottomRight = 1;
            m2.midLeft = -2;
            m2.midRight = 2;
            Bitmap b2 = m2.Convolute((Bitmap)bm.Clone());

            m3.Init(0);
            m3.topMid = m3.midRight = 1;
            m3.midLeft = m3.bottomMid = -1;
            m3.topRight = 2;
            m3.bottomLeft = -2;
            Bitmap b3 = m3.Convolute((Bitmap)bm.Clone());

            m4.Init(0);
            m4.topMid = m4.midLeft = -1;
            m4.midRight = m4.bottomMid = 1;
            m4.topLeft = -2;
            m4.bottomRight = 2;
            Bitmap b4 = m4.Convolute((Bitmap)bm.Clone());

            bm = Gradient(Gradient(bl, b2), Gradient(b3, b4));
            bl.Dispose();
            b2.Dispose();
            b3.Dispose();
            b4.Dispose();
            return bm;

        }
        private void 低通滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);
                int num;
                for (num = 1; num < 4; num++)
                {
                    //低通滤波
                    bm = lowpass(bm, iw, ih, num);

                    pictureBox2.Refresh();
                    pictureBox2.Image = bm;

                    if (num == 1) label7.Text = "1*5模板低通滤波结果";
                    else if (num == 2) label7.Text = "5*1模板低通滤波结果";
                    else if (num == 3) label7.Text = "5*5模板低通滤波结果";
                }
            }


        }
        //3×3低通滤波方法
        public Bitmap lowpass(Bitmap bm, int iw, int ih, int n)
        {
            Bitmap obm = new Bitmap(pictureBox1.Image);
            int[,] h;

            //定义扩展输入图像矩阵
            int[,] ex_inpix = exinpix(bm, iw, ih);

            //低通滤波
            for (int j = 1; j < ih + 1; j++)
            {
                for (int i = 1; i < iw + 1; i++)
                {
                    int r = 0, sum = 0;

                    //低通模板 
                    h = low_matrix(n);

                    //求3×3窗口9个像素加权和
                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                            sum = sum + h[k + 1, l + 1] * ex_inpix[i + k, j + l];

                    if (n == 1)
                        r = (int)(sum / 9); //h1平均值
                    else if (n == 2)
                        r = (int)(sum / 10); //h2
                    else if (n == 3)
                        r = (int)(sum / 16); //h3 
                    obm.SetPixel(i - 1, j - 1, Color.FromArgb(r, r, r)); //输出   
                }
            }
            return obm;
        }
        //定义扩展输入图像矩阵
        public int[,] exinpix(Bitmap bm, int iw, int ih)
        {
            int[,] ex_inpix = new int[iw + 2, ih + 2];
            //获取非边界灰度值
            for (int j = 0; j < ih; j++)
                for (int i = 0; i < iw; i++)
                    ex_inpix[i + 1, j + 1] = (bm.GetPixel(i, j)).R;
            //四角点处理
            ex_inpix[0, 0] = ex_inpix[1, 1];
            ex_inpix[0, ih + 1] = ex_inpix[1, ih];
            ex_inpix[iw + 1, 0] = ex_inpix[iw, 1];
            ex_inpix[iw + 1, ih + 1] = ex_inpix[iw, ih];
            //上下边界处理
            for (int j = 1; j < ih + 1; j++)
            {
                ex_inpix[0, j] = ex_inpix[1, j]; //上边界 
                ex_inpix[iw + 1, j] = ex_inpix[iw, j];//下边界
            }

            //左右边界处理
            for (int i = 1; i < iw + 1; i++)
            {
                ex_inpix[i, 0] = ex_inpix[i, 1]; //左边界 
                ex_inpix[i, ih + 1] = ex_inpix[i, ih];//右边界
            }
            return ex_inpix;
        }
        //低通滤波模板
        public int[,] low_matrix(int n)
        {
            int[,] h = new int[3, 3];
            if (n == 1) //h1
            {
                h[0, 0] = 1; h[0, 1] = 1; h[0, 2] = 1;
                h[1, 0] = 1; h[1, 1] = 1; h[1, 2] = 1;
                h[2, 0] = 1; h[2, 1] = 1; h[2, 2] = 1;
            }
            else if (n == 2)//h2
            {
                h[0, 0] = 1; h[0, 1] = 1; h[0, 2] = 1;
                h[1, 0] = 1; h[1, 1] = 2; h[1, 2] = 1;
                h[2, 0] = 1; h[2, 1] = 1; h[2, 2] = 1;
            }
            else if (n == 3)//h3
            {
                h[0, 0] = 1; h[0, 1] = 2; h[0, 2] = 1;
                h[1, 0] = 2; h[1, 1] = 4; h[1, 2] = 2;
                h[2, 0] = 1; h[2, 1] = 2; h[2, 2] = 1;
            }
            return h;
        }


        private void 对比度扩展ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = " 图像增强 对比度扩展 ";
                Bitmap bm = new Bitmap(pictureBox1.Image);

                bm = KiContrast(bm, 50);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "对比度扩展结果";
            }
        }

        public static Bitmap KiContrast(Bitmap bm, int degree)
        {
            if (bm == null)
            {
                return null;
            }

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;

            try
            {

                double pixel = 0;
                double contrast = (100.0 + degree) / 100.0;
                contrast *= contrast;
                int width = bm.Width;
                int height = bm.Height;
                BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[i] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                bm.UnlockBits(data);
                return bm;
            }
            catch
            {
                return null;
            }

        }

        private void dealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);

                bm = dealimage(bm,22);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
            }
        }

        public static Bitmap dealimage(Bitmap bm, int degree)
        {
            if (bm == null)
            {
                return null;
            }


            try
            {

                double pixel = 0;
                int width = bm.Width;
                int height = bm.Height;
                BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 4;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                                if (p[i] < degree-2) pixel = 255;
                                if (p[i] > degree) pixel = 0;
                                p[i] = (byte)pixel;
                            } // i
                            p += 4;
                        } // x
                        p += offset;
                    } // y
                }
                bm.UnlockBits(data);
                return bm;
            }
            catch
            {
                return null;
            }

        }
        //水平腐蚀
        public byte[,] InitArray(int width,int height,byte init)
        {
            byte[,] dst = new byte[width, height];

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    dst[x, y] = init;
                }//x
            }//y

            return dst;
        }

        public byte[,] ErosionHorz(byte[,] src)
        {
            int width = src.GetLength(0);
            int height = src.GetLength(1);

            byte[,] dst = InitArray(width, height, 255);

            int topRect = 0;
            int bottomRect = height;
            int leftRect = 1;
            int rightRect = width - 1;

            for(int y = topRect; y < bottomRect; y++)
            {
                for(int x = leftRect; x < rightRect; x++)
                {
                    byte c = 0;

                    for(int i = -1; i <= 1; i++)
                    {
                        if (src[x + i, y] > 127)
                        {
                            c = 255;
                            break;
                        }
                    }//i

                    dst[x, y] = c;
                }//x
            }//y

            return dst;
        }

        public byte[,] Image2Array(Bitmap bm)
        {
            int width = bm.Width;
            int height = bm.Height;

            byte[,] GrayArray = new byte[width, height];
            BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

            unsafe
            {

                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * 4;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // 因为已经是灰度色， 这里只取蓝色分量作为灰度
                        GrayArray[x, y] = p[0];
                        p += 4;
                    } // x

                    p += offset;
                } // y
                bm.UnlockBits(data);

                return GrayArray;
            }
        }

        public Bitmap Array2Image(byte[,] GrayArray)
        {
            int width = GrayArray.GetLength(0);
            int height = GrayArray.GetLength(1);

            Bitmap b = new Bitmap(width, height);
            BitmapData data = b.LockBits(new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * 4;
                for (int y = 0; y < height; y++)
                { 
                    for (int x = 0; x < width; x++)
                    {
                        p[0] = p[1] = p[2] = GrayArray[x, y];
                        p[3] = 255;
                        p += 4;
                    } // x

                    p += offset;
                } // Y
            }
            b.UnlockBits(data);
            return b;
        }

        private void 水平腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = "水平腐蚀";
                Bitmap bm = new Bitmap(pictureBox1.Image);

                bm = ErosionHorz(bm);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "水平腐蚀结果";
            }
        }

        public Bitmap ErosionHorz(Bitmap bm)
        {
            byte[,] srcGray = Image2Array(bm);
            byte[,] dstGray = ErosionHorz(srcGray);
            bm.Dispose();
            return Array2Image(dstGray);

        }
        //边缘增强
        public Bitmap EdgeEnhance(Bitmap b, int threshold)
        {
            int width = b.Width;
            int height = b.Height;

            Bitmap dstImage = (Bitmap)b.Clone();

            BitmapData srcData = b.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // 图像实际处理区域
            // 不考虑最左 1 列和最右 1 列
            // 不考虑最上 1 行和最下 1 行
            int rectTop = 1;
            int rectBottom = height - 1;
            int rectLeft = 1;
            int rectRight = width - 1;

            unsafe
            {
                byte* src = (byte*)srcData.Scan0;
                byte* dst = (byte*)dstData.Scan0;

                int stride = srcData.Stride;
                int offset = stride - width * 4;

                int pixel = 0;
                int maxPixel = 0;


                // 指向第 1 行
                src += stride;
                dst += stride;
                for (int y = rectTop; y < rectBottom; y++)
                {
                    // 指向每行第 1 列像素
                    src += 4;
                    dst += 4;

                    for (int x = rectLeft; x < rectRight; x++)
                    {
                        // Alpha
                        dst[3] = src[3];

                        // 处理 B, G, R 三分量
                        for (int i = 0; i < 3; i++)
                        {
                            // 右上-左下
                            maxPixel = src[i - stride + 4] - src[i + stride - 4];
                            if (maxPixel < 0) maxPixel = -maxPixel;

                            // 左上-右下
                            pixel = src[i - stride - 4] - src[i + stride + 4];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 上-下
                            pixel = src[i - stride] - src[i + stride];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 左-右
                            pixel = src[i - 4] - src[i + 4];
                            if (pixel < 0) pixel = -pixel;
                            if (pixel > maxPixel) maxPixel = pixel;

                            // 进行阈值判断
                            if (maxPixel < threshold) maxPixel = 0;

                            dst[i] = (byte)maxPixel;
                        }

                        // 向后移一像素
                        src += 4;
                        dst += 4;
                    } // x

                    // 移向下一行
                    // 这里得注意要多移 1 列，因最右边还有 1 列不必处理
                    src += offset + 4;
                    dst += offset + 4;
                } // y
            }

            b.UnlockBits(srcData);
            dstImage.UnlockBits(dstData);

            b.Dispose();

            return dstImage;
        } // end of EdgeEnhance

        private void 边缘增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = "边缘增强";
                Bitmap bm = new Bitmap(pictureBox1.Image);

                bm = EdgeEnhance(bm,10);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "边缘增强结果";
            }
        }
        //消除小区域
        private void 消除小区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                this.Text = "消除小区域";
                Bitmap bm = new Bitmap(pictureBox1.Image);

                bm = ClearSmallArea(bm, 1);
                pictureBox2.Refresh();
                pictureBox2.Image = bm;
                label7.Text = "消除小区域结果";
            }

        }

        public Bitmap ClearSmallArea(Bitmap bm, int percent)
        {
            // 将原始二值图转化为二维数组
            byte[,] srcGray = Image2Array(bm);

            // 进行区域标记
            ushort[,] Sign = ImageSign(srcGray);

            // 区域面积
            int[] Area = ImageArea(Sign);

            int width = bm.Width;
            int height = bm.Height;

            // 面积阈值
            int area = width * height * percent / 800;

            BitmapData data = bm.LockBits(new Rectangle(0, 0, width, height),
              ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * BPP;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        ushort sign = Sign[x, y];

                        // 将原始背景和小区域全部变为背景
                        if (sign == 0 || Area[sign] < area)
                        {
                            p[0] = p[1] = p[2] = 255;
                        }
                        else
                        {
                            p[0] = p[1] = p[2] = 0;
                        }

                        p += BPP;
                    } // x

                    p += offset;
                } // y
            }

            bm.UnlockBits(data);

            return bm;
        } // end of ClearSmallArea

        public ushort[,] ImageSign(byte[,] b)
        {
            int width = b.GetLength(0);
            int height = b.GetLength(1);

            // 标记号，最多可以标记 65536 个不同的连通区域
            // 注意标记号从 1 开始依次递增，标记号 0 代表背景
            ushort signNo = 1;

            // 用堆栈记录所有空标记
            Stack Seat = new Stack();

            // 二值图像连通区域标识，存储的是区域标识，而非图像数据
            ushort[,] Sign = new ushort[width, height];


            // 初始化最顶行标记
            for (int x = 0; x < width; x++)
            {
                if (b[x, 0] != 0) continue;

                // 处理所有连续的黑点
                while (x < width && b[x, 0] == 0)
                {
                    Sign[x, 0] = signNo;
                    x++;
                } // while

                signNo++;
            } // x


            // 处理最左列及最右列标记
            for (int y = 1; y < height; y++)
            {
                // 第左列
                if (b[0, y] == 0)
                {
                    if (b[0, y - 1] == 0)
                        Sign[0, y] = Sign[0, y - 1];
                    else
                        Sign[0, y] = signNo++;
                }

                // 最右列
                if (b[width - 1, y] == 0)
                {
                    if (b[width - 1, y - 1] == 0)
                        Sign[width - 1, y] = Sign[width - 1, y - 1];
                    else
                        Sign[width - 1, y] = signNo++;
                }
            } // y


            // 上面已经处理了图像最顶行、最左列、最右列，
            // 故下面只处理排除这三行后的主图像区
            int topRect = 1;
            int bottomRect = height;
            int leftRect = 1;
            int rightRect = width - 1;

            // 从左到右开始标记
            for (int y = topRect; y < bottomRect; y++)
            {
                for (int x = leftRect; x < rightRect; x++)
                {
                    // 如果当前点不为黑点，则跳过不处理
                    if (b[x, y] != 0) continue;

                    // 右上
                    if (b[x + 1, y - 1] == 0)
                    {
                        // 将当前点置为与右上点相同的标记
                        ushort sign = Sign[x, y] = Sign[x + 1, y - 1];

                        // 当左前点为黑点，且左前点的标记与右上点的标记不同时
                        if (b[x - 1, y] == 0 && Sign[x - 1, y] != sign)
                        {
                            // 进栈：记录左前点标记，因为该标记将被替换掉
                            Seat.Push(Sign[x - 1, y]);

                            // 用右上点的标记号替换掉所有与左前点标记号相同的点
                            ReplaceSign(ref Sign, Sign[x - 1, y], sign);
                        }

                        // 当左上点为黑点，且左上点的标记与右上点的标记不同时
                        else if (b[x - 1, y - 1] == 0 && Sign[x - 1, y - 1] != sign)
                        {
                            // 进栈：记录左上点标记，因为该标记将被替换掉
                            Seat.Push(Sign[x - 1, y - 1]);

                            // 用右上点的标记号替换掉所有与左上点标记号相同的点
                            ReplaceSign(ref Sign, Sign[x - 1, y - 1], sign);
                        }
                    } // 右上完

                    // 正上
                    else if (b[x, y - 1] == 0)
                    {
                        // 将当前点置为与正上点相同的标记
                        Sign[x, y] = Sign[x, y - 1];
                    }

                    // 左上
                    else if (b[x - 1, y - 1] == 0)
                    {
                        // 将当前点置为与左上点相同的标记
                        Sign[x, y] = Sign[x - 1, y - 1];
                    }

                    // 左前
                    else if (b[x - 1, y] == 0)
                    {
                        // 将当前点置为与左前点相同的标记
                        Sign[x, y] = Sign[x - 1, y];
                    }

                    // 右上、正上、左上及左前四点均不为黑点，即表示新区域开始
                    else
                    {
                        // 避免区域数超过 0xFFFF
                        if (signNo >= 0xFFFF)
                            return Sign;

                        // 如果堆栈里无空标记，
                        // 则使用新标记，否则使用该空标记
                        if (Seat.Count == 0)
                            Sign[x, y] = signNo++;
                        else
                            Sign[x, y] = (ushort)Seat.Pop(); // 出栈
                    }

                } // x
            } // y


            // 堆栈里存在空标记，则使用完没有空标记
            while (Seat.Count > 0)
            {
                ReplaceSign(ref Sign, (ushort)(--signNo), (ushort)Seat.Pop());
            } // while

            return Sign;
        } // end of ImageSign

        public int[] ImageArea(ushort[,] Sign)
        {
            int width = Sign.GetLength(0);
            int height = Sign.GetLength(1);

            // 找出最大标记号，即找出区域数
            int max = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Sign[x, y] > max)
                        max = Sign[x, y];
                } // x
            } // y

            // 面积统计数组
            int[] Area = new int[max + 1];

            // 计算区域面积
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Area[Sign[x, y]]++;
                } // x
            } // y

            return Area;
        } // end of ImageArea

        private void ReplaceSign(ref ushort[,] Sign, ushort srcSign, ushort dstSign)
        {
            int width = Sign.GetLength(0);
            int height = Sign.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Sign[x, y] == srcSign)
                        Sign[x, y] = dstSign;
                } // x
            } // y
        } // end of ReplaceSign
    }

}

