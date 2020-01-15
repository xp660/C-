using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryRW
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;
           

            byte[] BData;
            BData = Encoding.UTF8.GetBytes("Kelp-Space");
            //FileStream BFile = new FileStream("FileName.txt", FileMode.Create);
            //BFile.Write(BData, 0, BData.GetUpperBound(0) + 1);
            //BFile.Flush();
            //BFile.Close();

            //create the file
            try
            {
                bw = new BinaryWriter(new FileStream("FileName.txt", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //writing into the file
            try
            {
                bw.Write(BData);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();





            //reading from the file
            try
            {
               FileStream fs = new FileStream("FileName.txt", FileMode.Open,FileAccess.Read);
               br = new BinaryReader(fs);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }


            try
            {
                FileInfo fi = new FileInfo("FileName.txt");
                Console.WriteLine(fi.Length);
                

                for (int i = 0; i < fi.Length; i++)
                {
                    Console.WriteLine(br.ReadString());
                    
                }



            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
            

            Console.ReadLine();
        }
    }
}
