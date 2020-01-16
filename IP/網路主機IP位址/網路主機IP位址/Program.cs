using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace 網路主機IP位址
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please type the name of the host: ");
            string host = Console.ReadLine();

            try
            {
                // Get the DNS information
                IPHostEntry ipHost = Dns.GetHostByName(host);

                // Display the host name
                Console.WriteLine("Host Name:{0}", ipHost.HostName);

                // Store the list of IP adresses
                IPAddress[] ipAddr = ipHost.AddressList;

                Console.WriteLine("IP number:{0}",ipAddr.Length);

                // Loop to actually display the IP
                for(int x = 0; x < ipAddr.Length; x++)
                {
                    Console.WriteLine("IP adress:{0}", ipAddr[x].ToString());
                }



            }
            catch(System.Net.Sockets.SocketException)  // Catch the exception (if host was not found)
            {
                Console.WriteLine("Host not found.");
            }


            Console.WriteLine("Press Enter to Exit!!");
            Console.ReadLine();

        }
    }
}
