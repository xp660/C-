using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Length
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Chris Huang";
            int stringLen = 0;

            Console.WriteLine("String  = {0}", str);
            
            stringLen = str.Length;
            Console.WriteLine("String Length = {0}", stringLen);

            Console.WriteLine();
            Console.WriteLine("Press Enter key to Exit!!");
            Console.Read();
        }
    }
}
