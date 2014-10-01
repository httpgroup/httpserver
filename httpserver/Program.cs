using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace httpserver
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*** Server Log *** \n");


            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();
            Console.WriteLine("***Server running.");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Socket connectionSocket = server.AcceptSocket();
                Console.WriteLine("***A client is connecting.");

                NetworkStream ns = client.GetStream();
                byte[] hello = new byte[100];
                hello = Encoding.UTF8.GetBytes("hello world");

                ns.Write(hello, 0, hello.Length);
            }
            
           


              Console.ReadKey();
        }
    }
}
