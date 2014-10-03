using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace httpserver
{
    public class HttpServer
    {

        public const string Source = "Http Server";
        public const string sLog = "Application";
        public const string Message = "Sample Event blah";
        public const string machineName = ".";
        private static EventLog log = new EventLog(sLog, machineName, Source);


        public static readonly int DefaultPort = 8888;

        /// <summary>
        /// The method running the server starts here.
        /// </summary>






        public void HttpServ()
        {
            //Server start-up.
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), DefaultPort);
            server.Start();
            Console.WriteLine("*** Server running.");
            log.WriteEntry("Server is now running.");

            string rootCatalog = "c:/temp";


            while (true)
            {
                TcpClient client = server.AcceptTcpClient();



                Task.Run(() => DoIt(client, rootCatalog));
                log.WriteEntry("Threading method in use.");


            }
        }



        //This is the method in charge of handling client requests.
        private static void DoIt(TcpClient client, string rootCatalog)
        {
            Console.WriteLine("*** A client is connecting.");

            Stream servstream = client.GetStream();
            StreamReader sr = new StreamReader(servstream);
            StreamWriter sw = new StreamWriter(servstream);


            string request = sr.ReadLine();
            string[] words = request.Split(' ');


           /* if (words.Length == 0)
            {
                throw new Exception("Bad Request.");
            } */

            Console.WriteLine("Requested " + words[1]);
            //  sw.Write(words[1]);   *previous iteration

            string filename = words[1];
            string fullfilename = rootCatalog + filename;


            //   sw.Write(fs);   *previous iteration

            try
            {
                try
                {
                    FileStream fs = new FileStream(fullfilename, FileMode.Open, FileAccess.Read);

                    sw.Write("HTTP/1.0 200 OK\r\n");
                    sw.Write("\r\n");
                    log.WriteEntry("Browser reply");
                    sw.Flush();
                    fs.CopyTo(sw.BaseStream);
                    fs.Close();
                }


                catch (FileNotFoundException)
                {
                    sw.Write("HTTP/1.0 404 Not Found\n\r");
                    sw.Write("\r\n");
                    log.WriteEntry("404");
                    sw.Flush();
                }
            }

            catch (Exception)
            {
                sw.Write("HTTP/1.0 400 Illegal request");
                sw.Write("\r\n");
                log.WriteEntry("400 Illegal Request");
                sw.Flush();
            }


            //   sw.Write("This is a test message.");   *previous iteration
            sw.AutoFlush = true;

            servstream.Close();
            client.Close();
            log.WriteEntry("client closed");
        }
    }


}



