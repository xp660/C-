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


namespace Image_Histogram
{
    unsafe public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            
            
        }

        Bitmap myBitmap = null;

        private void button1_Click(object sender, EventArgs e) ////載入圖檔
        {
            this.openFileDialog1.Filter = "所有檔案|*.*|BMP File| *.bmp|JPEG File|*.jpg| GIF File|*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = myBitmap;
                SwitchChannel(0);
                comboBox1.Text = "Y";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchChannel(comboBox1.SelectedIndex);
        }

        public void SwitchChannel(int channel)
        {
            int[,,] ImgData = GetImgData(myBitmap);
            long[] Values = new long[256];

            ChannelProcess(ImgData, channel);
            Bitmap processedBitmap = CreateBitmap(ImgData);
            Values = GetHistogram(ImgData, channel);
            DrawHistogram(Values);
            lblHistogram.ForeColor = myColor;

            pictureBox2.Image = processedBitmap;
        }

        private int[,,] GetImgData(Bitmap myBitmap)
        {
            int[,,] ImgData = new int[myBitmap.Width, myBitmap.Height, 3];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int ByteOfSkip = byteArray.Stride - 3 * myBitmap.Width;
            byte* imgPtr = (byte*)(byteArray.Scan0);

            for (int y = 0; y < byteArray.Height; y++)
            {
                for (int x = 0; x < byteArray.Width; x++)
                {
                    ImgData[x, y, 2] = (int)*(imgPtr);      //B
                    ImgData[x, y, 1] = (int)*(imgPtr + 1);  //G
                    ImgData[x, y, 0] = (int)*(imgPtr + 2);  //R
                    imgPtr += 3;

                }

                imgPtr += ByteOfSkip;
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

            byte* imgPtr = (byte*)byteArray.Scan0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    *imgPtr = (byte)ImgData[x, y, 2];       //B

                    *(imgPtr + 1) = (byte)ImgData[x, y, 1];   //G

                    *(imgPtr + 2) = (byte)ImgData[x, y, 0];   //R 
                    
                    imgPtr += 3;
                }

                imgPtr += ByteOfSkip; // 跳過Padding bytes
            }

            myBitmap.UnlockBits(byteArray);
            return myBitmap;
        }

        long myMaxValue;
        private long[] myValues;
        private bool myIsDrawing;

        private float myYUnit; //this gives the vertical unit used to scale our values
        private float myXUnit; //this gives the horizontal unit used to scale our values

        private int myOffset = 20; //the offset, in pixels, from the control margins.

        private Color myColor = Color.Black;
        private Font myFont = new Font("Tahoma", 10);

        public long[] GetHistogram(int[,,] ImgData, int channel)
        {
            long[] myHistogram = new long[256];
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    switch (channel)
                    {

                        case 0: //Gray
                            int gray = ImgData[x, y, 1];
                            myHistogram[gray]++;
                            myColor = Color.Black;
                            break;

                        case 1:  //Red
                            int Red = ImgData[x, y, 0];
                            myHistogram[Red]++;
                            myColor = Color.Red;
                            break;
                        case 2:  //Green
                            int Green = ImgData[x, y, 1];
                            myHistogram[Green]++;
                            myColor = Color.Green;
                            break;
                        case 3:     //Blue
                            int Blue = ImgData[x, y, 2];
                            myHistogram[Blue]++;
                            myColor = Color.Blue;
                            break;
                    }
                }


            return myHistogram;
        }

        private void ChannelProcess(int[,,] ImgData, int channel)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (channel)
                    {

                        case 0: //Gray
                            int gray = (int)((double)ImgData[x, y, 0] * 0.299 + (double)ImgData[x, y, 1] * 0.587 + (double)ImgData[x, y, 2] * 0.114);
                            ImgData[x, y, 0] = gray;
                            ImgData[x, y, 1] = gray;
                            ImgData[x, y, 2] = gray;
                            break;

                        case 1:  //Red
                            ImgData[x, y, 1] = 0;
                            ImgData[x, y, 2] = 0;
                            break;
                        case 2:  //Green
                            ImgData[x, y, 0] = 0;
                            ImgData[x, y, 2] = 0;
                            break;
                        case 3:     //Blue
                            ImgData[x, y, 0] = 0;
                            ImgData[x, y, 1] = 0;
                            break;
                    }
                }
            }
        }
        public void DrawHistogram(long[] Values)
        {
            myValues=new long[Values.Length];
            Values.CopyTo(myValues, 0);
            myIsDrawing = true;
            myMaxValue = getMaxim(myValues);
            
            ComputeXYUnitValues();

            //   this.pictureBox3.Invalidate();
            this.Refresh();
        }

        private void ComputeXYUnitValues()
        {
            myYUnit = (float)(this.pictureBox3.Height - 2 * myOffset) / myMaxValue;
            myXUnit = (float)(this.pictureBox3.Width - 2 * myOffset) / (myValues.Length - 1);
        }

        private long getMaxim(long[] Vals)
        {
            if (myIsDrawing)
            {
                long max = 0;
                for (int i = 0; i < Vals.Length; i++)
                {
                    if (Vals[i] > max)
                    {
                        max = Vals[i];
                    }
                }
                return max;
            }

            return 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (myIsDrawing)
            {
                Graphics g = this.pictureBox3.CreateGraphics();
                Pen myPen = new Pen(myColor, 2);
                int xPos, yPos;

                for (int i = 0; i < myValues.Length; i++)
                {
                    xPos = myOffset + (int)(i * myXUnit);
                    yPos = this.pictureBox3.Height - myOffset;
                    g.DrawLine(myPen,
                        new PointF(xPos, yPos),
                        new PointF(xPos, yPos - (int)(myValues[i] * myYUnit)));

                    //We plot the coresponding index for the maximum value.
                    if (myValues[i] == getMaxim(myValues))
                    {
                        SizeF mySize = g.MeasureString(i.ToString(), myFont);
                        g.DrawString(i.ToString(), myFont,
                           new SolidBrush(myColor),
                           new PointF(myOffset + (i * myXUnit) - (mySize.Width / 2),
                           this.pictureBox3.Height - myFont.Height),
                           System.Drawing.StringFormat.GenericDefault);

                        

                    }

                }
                    g.DrawString("0", myFont, new SolidBrush(myColor), new PointF(myOffset, this.pictureBox3.Height - myFont.Height), System.Drawing.StringFormat.GenericDefault);
                    g.DrawString((myValues.Length - 1).ToString(), myFont,new SolidBrush(myColor),
                                    new PointF(myOffset + (myValues.Length * myXUnit) - g.MeasureString((myValues.Length - 1).ToString(), myFont).Width,
                                                this.pictureBox3.Height - myFont.Height),
                                   System.Drawing.StringFormat.GenericDefault);

                    //Histogram周圍畫一個方型
                    g.DrawRectangle(new System.Drawing.Pen(new SolidBrush(myColor), 2)
                                    , myOffset, myOffset,
                                    this.pictureBox3.Width - myOffset * 2, this.pictureBox3.Height - myOffset * 2);
            }

        }



    }

}

