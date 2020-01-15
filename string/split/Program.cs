using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = "tree.jpg";
            string[] words = FileName.Split('.');
            
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }
    }
}
