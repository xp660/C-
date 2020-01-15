using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamRW
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "Zara Ali", "Nuha Ali" };

            using (StreamWriter sw = new StreamWriter("FileName.txt"))  //StreamWriter sw = File.AppendText()
            {
               
                foreach (string s in names)
                {
                    sw.WriteLine(s);
                    sw.Flush();
                    
                }
                sw.Close();
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader("FileName.txt")) //StreamReader sr= File.OpenText()
            {
                while( (line = sr.ReadLine()) != null){
                    Console.WriteLine(line);
                }
            }
            

            Console.ReadKey();
        }
    }
}
