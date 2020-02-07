using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.Write("Please input number => ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());   // 讀入數字
            }
            catch (Exception ex) // Argument is optional, no "When" keyword
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }


            if (n > 15)
            {
                Console.WriteLine("The calucation time will be too long to wait.....");
                Console.WriteLine("Press Enter key to Exit");
                Console.Read();

            }
            else if(n<0)
            {
                Console.WriteLine("input error, number must > 0");  ///小於零之數不合法
                Console.WriteLine("Press Enter key to Exit");
                Console.Read();
            }
            else
                Hanoi(n, "A", "B", "C");

            Console.WriteLine("Press Enter key to Exit");
            Console.Read();

        }

        //  把 n 個盤子,從 form 柱,經由 by 柱,搬往 to 柱
        public static void Hanoi(int n,string from,string by,string to)
        {
            if (n > 0)
            {
                Hanoi(n - 1, from, to, by);
                Console.WriteLine("move no. {0} disk from {1} to {2}", n, from, to);
                Hanoi(n - 1, by, from, to);
            }
        }


    }
}
