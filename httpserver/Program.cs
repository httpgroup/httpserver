using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace httpserver
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*** Server Log *** \n");

            
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();

            Console.WriteLine("*** Server running.");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Socket connectionSocket = server.AcceptSocket();
                Console.WriteLine("*** A client is connecting.");

                Stream ns = new NetworkStream(connectionSocket);

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                
                

                    


                }

                
            }
            
           


              
        }
    }

