using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using CsharpCreateDLL;


namespace RGB2Lab
{
    public partial class Form1 : Form
    {
        int R; int G; int B; int A;
        string HexColor;
        ColorSpace colorSpace = new ColorSpace();


        public Form1()
        {
            InitializeComponent();
            R = (int)numericUpDownR.Value;
            G = (int)numericUpDownG.Value;
            B = (int)numericUpDownB.Value;
            A = 255;
            calculateHexColor();


        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            clrPicker.Color = picColor.BackColor;       //PictureBox背景顏色設為 C olor Dialog預設顏色
            clrPicker.FullOpen = true;                  //開啟Color Dialog

            if (clrPicker.ShowDialog() == DialogResult.OK)
            {
                string HexColor = string.Format("0x{0:X8}", clrPicker.Color.ToArgb());
                txtHex.Text = "#" + HexColor.Substring(HexColor.Length - 6, 6);

                R = clrPicker.Color.R;
                G = clrPicker.Color.G;
                B = clrPicker.Color.B;
                numericUpDownR.Value = clrPicker.Color.R;
                numericUpDownG.Value = clrPicker.Color.G;
                numericUpDownB.Value = clrPicker.Color.B;

                picColor.BackColor = clrPicker.Color;
            }
        }



        private void calculateHexColor()
        {
            double LabL, Laba, Labb;
            picColor.BackColor = Color.FromArgb(A, R, G, B);
            clrPicker.Color = picColor.BackColor;
            string HexColor = string.Format("0x{0:X8}", clrPicker.Color.ToArgb());
            txtHex.Text = "#" + HexColor.Substring(HexColor.Length - 6, 6);
            
            unsafe
            {
                colorSpace.RGB2Lab(R, G, B, &LabL, &Laba, &Labb);
            }

            txtL.Text = String.Format("{0:F2}", LabL);
            txta.Text = String.Format("{0:F2}", Laba);
            txtb.Text = String.Format("{0:F2}", Labb);

        }

        private void numericUpDownR_ValueChanged(object sender, EventArgs e)
        {
            R = (int)numericUpDownR.Value;
            calculateHexColor();
        }

        private void numericUpDownG_ValueChanged(object sender, EventArgs e)
        {
            G = (int)numericUpDownG.Value;
            calculateHexColor();
        }

        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            B = (int)numericUpDownB.Value;
            calculateHexColor();
        }
    }
}
