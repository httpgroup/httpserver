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
using System.Diagnostics;


namespace httpserver
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (!EventLog.SourceExists(HttpServer.Source))
            {
                EventLog.CreateEventSource(HttpServer.Source, HttpServer.sLog);
            }
            //  Console.WriteLine("*** Server Log *** \n"); //This is a log message.

            //Running the server.
            var newserv = new HttpServer();
            newserv.HttpServ();
        }
    }
}









