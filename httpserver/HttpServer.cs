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


namespace httpserver
{
    public class HttpServer
    {
        const string Source = "Csharp HTTP Server";
        const string SLog = "Application.";
        const string Message = "Event log occurence.";

        public static readonly int DefaultPort = 8888;

        /// <summary>
        /// The method running the server starts here.
        /// </summary>

        if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, SLog);
            }

        public static void WriteToLogUsingObjectMethods()
        {
            string machineName = "."; // this computer
            using (EventLog log = new EventLog(SLog, machineName, Source))
            {
                log.WriteEntry("Hello");
                log.WriteEntry("Hello again", EventLogEntryType.Information);
                log.WriteEntry("Hello again again", EventLogEntryType.Information, 14593);
            }
      
            
        public void HttpServ()    
        {
            //Server start-up.
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), DefaultPort);
            server.Start();
            Console.WriteLine("*** Server running.");
            

            string rootCatalog = "c:/temp";


            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
            
               

                 Task.Run(() => DoIt(client, rootCatalog));
                    
                    

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


            if (words.Length == 0)
            {
                throw new Exception("Bad Request.");
            }

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
                    sw.Flush();
                    fs.CopyTo(sw.BaseStream);
                    fs.Close();
                }


                catch (FileNotFoundException)
                {
                    sw.Write("HTTP/1.0 404 Not Found\n\r");
                    sw.Write("\r\n");
                    sw.Flush();
                }
            }

                catch (Exception)
            {
                sw.Write("HTTP/1.0 400 Illegal request");
                sw.Write("\r\n");
                sw.Flush();
            }


          //   sw.Write("This is a test message.");   *previous iteration
            sw.AutoFlush = true;

            servstream.Close();
            client.Close();
        }
    }


}



