using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] color = new string[2] { "Black", "White" };
            foreach(string c in color)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();


            //語法:string string.Substring(int StartIndex, int Length
            string str = "Collections";
            Console.WriteLine("string length:{0}", str.Length);
            string substr = str.Substring(str.Length - 6, 6);
            Console.WriteLine(substr);

            Console.ReadKey();
        }
    }
}
