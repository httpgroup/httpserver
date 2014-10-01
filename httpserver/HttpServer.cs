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
           
           TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), DefaultPort);
           server.Start();
           Console.WriteLine("*** Server running.");

           Socket connectionSocket = server.AcceptSocket();
            

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                
                Console.WriteLine("*** A client is connecting.");

                Stream servstream = client.GetStream();

                StreamReader sr = new StreamReader(servstream);
                StreamWriter sw = new StreamWriter(servstream);
                string request =  sr.ReadLine();

                sw.Write("Http/ 1/0 200 ok\r\n");
                sw.Write("\r\n");
                sw.Write("This is a test message.");
                sw.AutoFlush = true;
                client.Close();

                


                }
        }

   


     

    

       
       
        
        
        }

        
    }



