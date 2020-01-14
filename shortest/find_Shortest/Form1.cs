using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace find_Shortest
{
    public partial class Form1 : Form
    {
        public const int N = 8; //N是總頂點數
        const int NC = 100000;
        //路網圖，　NC表示沒有直接連接
        public static int[,] Cost = new int[,]  {{ 0,  3,  5,  4, NC, NC, NC, NC},
                                                 { 3,  0, NC,  4, NC, NC, NC, NC},
                                                 { 5, NC,  0,  3, NC,  2, NC, NC},
                                                 { 4,  4,  3,  0,  7,  3, NC, NC},
                                                 {NC, NC, NC,  7,  0, NC,  6,  1},
                                                 {NC, NC,  2,  3, NC,  0,  4,  2},
                                                 {NC, NC, NC, NC,  6,  4,  0,  3},
                                                 {NC, NC, NC, NC,  1,  2,  3,  0}};
        public static int[] Dist = new int[N];
        public static int[] Decided = new int[N];
        public static int[] PreNode = new int[N];
        public static int Start, Destination;
        string routeStr;

        public Form1()
        {
            InitializeComponent();
            Start = 0; Destination = 0;
            comboBox1.Text = "0"; comboBox2.Text = "0";
            textBoxDistance.Text = "";
            textBoxRoute.Text = "";
            pictureBox1.Image = Image.FromFile("Route.jpg");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Start = Convert.ToInt16(comboBox1.Text);
            Dijstra(Start);
            textBoxDistance.Text = Dist[Destination].ToString();

            routeStr = PrintPath(Start, Destination);
            textBoxRoute.Text = routeStr;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Destination = Convert.ToInt16(comboBox2.Text);
            Dijstra(Start);
            textBoxDistance.Text = Dist[Destination].ToString();
            routeStr = PrintPath(Start, Destination);
            textBoxRoute.Text = routeStr;
        }

        unsafe public static void Dijstra(int Start)
        {
            int Nd, i, w;
            for (i = 0; i < N; i++)
            {
                Dist[i] = Cost[Start, i];   //初設為Cost[]陣列的第Start列
                PreNode[i] = Start;          //由Start開始走到任意一點
                Decided[i] = 0;
            }

            Decided[Start] = 1;

            for (i = 0; i < N; i++)
            {
                find_Shortest(&Nd);
                Decided[Nd] = 1;
                for (w = 0; w < N; w++)
                {
                    if(Decided[w]==0 && Dist[w] > Dist[Nd] + Cost[Nd, w])
                    {
                        Dist[w] = Dist[Nd] + Cost[Nd, w];
                        PreNode[w] = Nd;
                    }
                }
            }
        }

        unsafe static void find_Shortest(int* Nd) //找出連接目前節點的所有點中距離最短的節點Nd
        {
            int low = 0, lowest = 32767, i = 0;
            for (i=0; i < N; i++)
            {
                if(Decided[i]==0 && Dist[i] < lowest)
                {
                    lowest = Dist[i];
                    low = i;
                }
            }
            *Nd = low;
        }

        public static string PrintPath(int Start,int Nd) // Start: 起始點, Nd終點
        {
            int i;
            Stack<int> stack = new Stack<int>();
            string node;
            stack.Push(Nd);
            i = PreNode[Nd];
            while (i != Start)
            {
                stack.Push(i);
                i = PreNode[i];
            }
            stack.Push(i);
            string routeStr = "";
            while (stack.Count > 0)
            {
                node = stack.Pop().ToString();
                routeStr = routeStr + " " + node;
            }
            return routeStr;
        }

    }
}
