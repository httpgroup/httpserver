﻿using System;
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

            new HttpServer();

            Console.ReadKey();

        }

                
            }
            
           


              
        }
    

