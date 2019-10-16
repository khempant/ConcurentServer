using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace Assignment4ConcurrentServer
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();

            Console.WriteLine("server started witing for connection!");

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
        public List<Book> books = new List<Book>()
        {
            new Book("FreedomFighter","Popular",68,"1234567896543"),
            new Book("CountryLove","Khem",123,"1239567896542"),
            new Book("HealthInstructor","Ganga",98,"1234767896943"),
            new Book("ViceCity","Boris",58,"1234562965743"),
            new Book("Algebra","Michel",698,"1234568896513"),
            new Book("Lyrics","William",65,"1234567896842"),
        };
    }
}

        
    
    

