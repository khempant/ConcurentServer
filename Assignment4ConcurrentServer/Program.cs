using ClassLibrary1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Assignment4ConcurrentServer
{
    class Program
    {
        static List<Book> BookList = new List<Book>()
        {
            new Book("FreedomFighter","Popular",68,"1234567896543"),
            new Book("CountryLove","Khem",123,"1239567896542"),
            new Book("HealthInstructor","Ganga",98,"1234767896943"),
            new Book("ViceCity","Boris",58,"1234562965743"),
            new Book("Algebra","Michel",698,"1234568896513"),
            new Book("Lyrics","William",65,"1234567896842"),
        };
        static void Main(string[] args)
        {
            try
            {
                // set the TcpListener on port 4646
                int port = 4646;
                TcpListener server = new TcpListener(IPAddress.Any, port);
                TcpClient client;
                // Start listening for client requests
                server.Start();

                int clientNumber = 0;

                //Enter the listening loop
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    client = server.AcceptTcpClient();
                    ThreadProc(client, ref clientNumber);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }

            Console.Read();
        }
        static void ThreadProc(object obj, ref int clientNumber)
        {
            byte[] bytes = new byte[1024];
            string data;
            clientNumber = 1;
            var client = (TcpClient)obj;
            Console.WriteLine("Connected!");

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            int i;

            // Loop to receive all the data sent by the client.
            i = stream.Read(bytes, 0, bytes.Length);
            string message = "";
            while (i != 0)
            {
                // Translate data bytes to a ASCII string.
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine(string.Format("Received: {0}", data));
                string mess = "not valid command";
                string[] words = data.ToLower().Split(' ');
                if (words[0].Trim() == "GetAll")
                {
                    mess = JsonConvert.SerializeObject(BookList);
                }
                if (words[0].Trim() == "get")
                {
                    mess = JsonConvert.SerializeObject(BookList.Find(e => e.Isbn13 == words[1]));
                }
                if (words[0].Trim() == "save")
                {
                    BookList.Add(JsonConvert.DeserializeObject<Book>(words[1]));
                    mess = "";
                }

                client.Close();
                Console.WriteLine("Client Disconnected");

                byte[] msg = Encoding.ASCII.GetBytes(message);

                stream.Write(msg, 0, msg.Length);
                Console.WriteLine(string.Format("Sent: {0}", message));

                Thread.Sleep(1000);

                Console.WriteLine("Sent: {0}", mess);
            }
            client.Close();
            clientNumber--;


        }


    }
    }


        
    
    

