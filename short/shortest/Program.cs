using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortest
{
    class Program
    {
        public const int N = 8;              //N是總頂點數
        const int NC = 100000;               //表二節點間沒有直接連結

        //路網圖，　NC表示沒有直接連接
        public static int[,] Cost = new int[,] {{ 0,  3,  5,  4, NC, NC, NC, NC},
                                                 { 3,  0, NC,  4, NC, NC, NC, NC},
                                                 { 5, NC,  0,  3, NC,  2, NC, NC},
                                                 { 4,  4,  3,  0,  7,  3, NC, NC},
                                                 {NC, NC, NC,  7,  0, NC,  6,  1},
                                                 {NC, NC,  2,  3, NC,  0,  4,  2},
                                                 {NC, NC, NC, NC,  6,  4,  0,  3},
                                                 {NC, NC, NC, NC,  1,  2,  3,  0}};

        public static int[] Dist = new int[N];
        public static int[] PreNode = new int[N];
        public static int[] Decided = new int[N];
        public static int Start;

        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("求某一節點到其他節點間的距離.");
            Console.Write("請輸入起點(0-7): ");
            try
            {
                Start = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Wrong Input!  Press any key to Exit");
                Console.Read();
                System.Environment.Exit(1);

            }

            if (Start > 7 || Start < 0)
            {
                Console.WriteLine("Wrong Input!  Press any key to Exit");
                Console.Read();
                System.Environment.Exit(1);
            }

            Dijkstra(Start);

            for (i = 0; i < N; i++)
            {
                if (i != Start)
                {
                    Console.WriteLine("V{0} --> V{1} Distance=={2}", Start, i, Dist[i]); //Dist陣列是行進距離
                    PrintPath(Start, i);
                }
            }

            Console.WriteLine("Press Enter key to Exit");
            Console.Read();

        }

            unsafe public static void Dijkstra(int Start)  ///Start是指定的起點, 例如0表示N0 ; 編譯時必須使用Unsafe選項
            {
                int Nd, i, w;
                for(i = 0; i < N; i++)
                {
                    Dist[i] = Cost[Start, i]; //初設為Cost[]陣列的第Start列
                    PreNode[i] = Start;       //由Start開始走到任意一點
                    Decided[i] = 0;
                }

                Decided[Start] = 1;

                for (i = 0; i < N; i++)
                {
                    find_Shortest(&Nd);     //找尚未找過且與V0最近的節點Nd

                    if (PreNode[Nd] == -1)
                        PreNode[Nd] = Start;
                    Decided[Nd] = 1;

                    for (w = 0; w < N; w++)
                    {
                        if(Decided[w]==0 && Dist[w]> (Dist[Nd] + Cost[Nd, w]) )
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
                for (i = 0; i < N; i++)
                {
                    if(Decided[i]==0 && Dist[i] < lowest)
                    {
                        lowest = Dist[i];
                        low = i;
                    }
                }

                *Nd = low;
            }


             static void PrintPath(int Start,int Destination) // Start: 起始點, Nd終點
            {
                int i;
                Stack<int> stack = new Stack<int>();
                stack.Push(Destination);
                i = PreNode[Destination];

                while(i!=Start)
                {
                    stack.Push(i);
                    i = PreNode[i];
                }

                stack.Push(i);
                Console.Write("經過節點 : ");

                while (stack.Count > 0)
                {
                    Console.Write("{0} ", stack.Pop());
                }
                Console.WriteLine();


            }



       
}
}
