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



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> FileItems = new List<string>();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {    //folderBrowserDialog選取目錄
                foreach(string File in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    FileItems.Add(File);
                }
                
            }
            ListBox.DataSource = FileItems;
        }
    }
}
