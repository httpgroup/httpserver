using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace httpserver
{
    public class HttpServer
    {
        public static readonly int DefaultPort = 8888;

        public HttpServer()
        {
           TcpListener server = new TcpListener(IPAddress.Any, DefaultPort);
            server.Start();
         //   Thread th = new Thread();
          //  th.Start();

            Console.WriteLine("*** Server running.");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Socket connectionSocket = server.AcceptSocket();
                Console.WriteLine("*** A client is connecting.");

                Stream ns = new NetworkStream(connectionSocket);

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);

                byte[] hello = new byte[100];
                hello = Encoding.UTF8.GetBytes("this is a test message.");
                sw.Write(hello);

                


                }
        }

   


     

    

       
       
        
        
        }

        
    }



