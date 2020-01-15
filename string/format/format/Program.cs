using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace format
{
    class Program
    {
        static void Main(string[] args)
        {
            double v = 17688.65849;
            double v2 = 0.15;
            int x = 21;

            //數字部分為小數點後幾位，四捨五入，多的補零

            string str = String.Format("{0:F2}", v); //F浮點數 
            Console.WriteLine(str);

            str = String.Format("{0:N5}", v); //N數字 ，會打逗號
            Console.WriteLine(str);

            str = String.Format("{0:e}", v);    //科學記號    　　　  
            Console.WriteLine(str);

            str = String.Format("{0:r}", v); //Round-trip：只支援Double、Single
            Console.WriteLine(str);

            str = String.Format("{0:p}", v2);    //百分比     
            Console.WriteLine(str);

            str = String.Format("{0:X}", x);       //十六進位      
            Console.WriteLine(str);

            str = String.Format("{0:D5}", x);    //十進位
            Console.WriteLine(str);

            str = String.Format("{0:C}", 189.99);  //貨幣  
            Console.WriteLine(str);

            Console.ReadLine();

        }
    }
}
