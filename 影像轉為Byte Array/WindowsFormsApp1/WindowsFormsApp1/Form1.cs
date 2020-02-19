using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap myBitmap = null;

        private void button1_Click(object sender, EventArgs e)   //載入圖檔
        {
            this.openFileDialog1.Filter = "所有檔案|*.*|BMP File|*.bmp|JPEG File|*.jpg| GIF File|*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = myBitmap;
            }

            pictureBox2.Image = null;

        }

        private void button2_Click(object sender, EventArgs e)   //灰階影像處理
        {
            int[,,] ImgData = GetImgData(myBitmap);
            GrayProcess(ImgData);
            Bitmap processedBitmap = CreateBitmap(ImgData);
            pictureBox2.Image = processedBitmap;
            
        }

        private int[,,] GetImgData(Bitmap myBitmap)
        {
            int[,,] ImgData = new int[myBitmap.Width, myBitmap.Height, 3];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                                                                   ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int ByteOfSkip = byteArray.Stride - byteArray.Width * 3;
            unsafe
            {
                byte* imgPtr=(byte*)(byteArray.Scan0);
                for(int y = 0; y < byteArray.Height; y++)
                {
                    for(int x = 0; x < byteArray.Width; x++)
                    {
                        ImgData[x, y, 2] = (int) *(imgPtr);      //B
                        ImgData[x, y, 1] = (int) *(imgPtr + 1);  //G
                        ImgData[x, y, 0] = (int) *(imgPtr + 2);  //R
                        imgPtr += 3;
                    }
                    imgPtr += ByteOfSkip;
                }
            }
            myBitmap.UnlockBits(byteArray);
            return ImgData;
        }

        public static Bitmap CreateBitmap(int[,,] ImgData)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);
            Bitmap myBitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, Width, Height),
                                           ImageLockMode.WriteOnly,
                                           PixelFormat.Format24bppRgb);

            //Padding bytes的長度
            int ByteOfSkip = byteArray.Stride - myBitmap.Width * 3;

            unsafe
            {
                byte* imgPtr = (byte*)byteArray.Scan0;
                for (int y = 0; y < Height; y++)
                {
                    for(int x = 0; x < Width; x++)
                    {
                        *imgPtr = (byte)ImgData[x, y, 2];       //B

                        *(imgPtr + 1) = (byte)ImgData[x, y, 1];   //G

                        *(imgPtr + 2) = (byte)ImgData[x, y, 0];   //R 
                       
                        imgPtr += 3;
                    }
                    imgPtr += ByteOfSkip; // 跳過Padding bytes
                }
            }

            myBitmap.UnlockBits(byteArray);
            return myBitmap;

        }

        private void GrayProcess(int[,,] ImgData)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int gray = (int)((double)ImgData[x, y, 0] * 0.299 + (double)ImgData[x, y, 1] * 0.587 + (double)ImgData[x, y, 2] * 0.114);
                    
                    ImgData[x, y, 0] = gray;
                    ImgData[x, y, 1] = gray;
                    ImgData[x, y, 2] = gray;

                }
            }
        }

    }
}
