using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empth
{
    class Program
    {
         static void Main(string[] args)
        {
            string name = "Chris Huang";
            Console.WriteLine("Name = {0}", name);

            name = String.Empty;

            Console.WriteLine("Name = {0}", name);
            Console.Read();
        }
    }
}
