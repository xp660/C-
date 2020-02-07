using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;




namespace Image
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.openFileDialog1.Filter = "所有檔案|*.*|BMP File| *.bmp|JPEG File|*.jpg| GIF File|*.gif";  //所有檔案(*.*)|*.*|BMP File(*.bmp)| *.bmp
            this.openFileDialog1.Title = "Select Image";
            this.openFileDialog1.FileName = "***.*";
            this.openFileDialog1.InitialDirectory = "C:\\";

            //選取圖檔類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //由對話框選取圖檔
                Bitmap myBmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = (System.Drawing.Image)myBmp;

                pictureBox1.Height = myBmp.Height;
                pictureBox1.Width = myBmp.Width;
                

                //將影像像素顏色資訊轉為陣列:
                int Height = myBmp.Height;
                int Width = myBmp.Width;
                int[,,] rgbData = new int[Width, Height, 3];

                for(int y = 0; y < Height; y++)
                {
                    for(int x = 0; x < Width; x++)
                    {
                        Color color = myBmp.GetPixel(x, y);
                        rgbData[x, y, 0] = color.R;
                        rgbData[x, y, 1] = color.G;
                        rgbData[x, y, 2] = color.B;
                    }
                }

            }

            

        }
    }
}
