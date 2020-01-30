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

namespace Drives
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Label lbl;
            int i = 0;
            foreach(DriveInfo d in allDrives)
            {
                lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = "Drive:" + d.Name.Substring(0, 1) + "\n";
                lbl.Text = lbl.Text + "FileType:" + d.DriveType + "\n";

                if (d.IsReady)
                {
                    lbl.Text = lbl.Text + "Volume label:" + d.VolumeLabel + "\n";
                    lbl.Text = lbl.Text + "File system:" + d.DriveFormat + "\n";
                    lbl.Text = lbl.Text + "Available space to current user:" + d.AvailableFreeSpace + "bytes\n";
                    lbl.Text = lbl.Text + "Total available space:" + d.TotalFreeSpace + "\n";
                    lbl.Text = lbl.Text + "Total size of drive:" + d.TotalSize + "\n";
                }

                lbl.Top = i;
                this.Controls.Add(lbl);
                i = i + 110;

            }
            this.Height = i;
        }
    }
}
