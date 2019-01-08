using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace image
{
    class Matrix3x3
    {
        public int topLeft;
        public int topMid;
        public int topRight;
        public int midLeft;
        public int center;
        public int midRight;
        public int bottomLeft;
        public int bottomMid;
        public int bottomRight;
        public int Scale;

        public void Init(int degree)
        {
            topLeft = topMid = topRight =
            midLeft = center = midRight =
            bottomLeft = bottomMid = bottomRight = degree;
        }

        public Bitmap Convolute(Bitmap srcImage)
        {
            if (Scale == 0) Scale = 1;

            int width = srcImage.Width;
            int height = srcImage.Height;

            Bitmap destImage = (Bitmap)srcImage.Clone();
            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height),
                                 ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            BitmapData dstData = destImage.LockBits(new Rectangle(0, 0, width, height),
                                 ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            // 图像实际处理区域
            // 图像最外围一圈不_
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

                src += stride;
                dst += stride;
                for (int y = rectTop; y < rectBottom; y++)
                {
                    src += 4;
                    dst += 4;
                    for (int x = rectLeft; x < rectRight; x++)
                    {
                        // 如果当前像素为透明色， 则跳过不处理
                        if (src[3] > 0)
                        {
                            //处理 B, G, R 三分量
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = src[i - stride - 4] * topLeft +
                                       src[i - stride] * topMid +
                                       src[i - stride + 4] * topRight +
                                       src[i - 4] * midLeft +
                                       src[i] * center +
                                       src[i + 4] * midRight +
                                       src[i + stride - 4] * bottomLeft +
                                       src[i + stride] * bottomMid +
                                       src[i + stride + 4] * bottomRight;
                               

                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                dst[i] = (byte)pixel;
                            }//i

                        }
                        //向后移
                        src += 4;
                        dst += 4;
                    }//x
                    //移向下一行
                    //这里得注意要多移一列， 因最右列不处理
                    src += (offset + 4);
                    dst += (offset + 4);
                }//y
            }

            srcImage.UnlockBits(srcData);
            destImage.UnlockBits(dstData);

            srcImage.Dispose();

            return destImage;
        }
    }
}