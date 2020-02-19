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
using System.Runtime.InteropServices;




namespace CursorPosition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {////Timer, 每10ms讀取滑鼠座標值及像素顏色並顯示於 PictureBox背景
            Color color = GetPixelColor(Cursor.Position);
            lblCoordX.Text = "X = " + Cursor.Position.X.ToString();
            lblCoordY.Text = "Y = " + Cursor.Position.Y.ToString();
            lblA.Text = " A = " + color.A;
            lblR.Text = " R = " + color.R;
            lblG.Text = " G = " + color.G;
            lblB.Text = " B = " + color.B;
            pictureBox1.BackColor = color;

        }

        static Color GetPixelColor(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using(var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }

                return bitmap.GetPixel(0, 0);
            }


        }


    }
}
