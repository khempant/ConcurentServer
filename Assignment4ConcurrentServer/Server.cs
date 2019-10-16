using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment4ConcurrentServer
{
    class Server
    {
        static List<Book> books = new List<Book>()
        {
            new Book("FreedomFighter","Popular",68,"1234567896543"),
            new Book("CountryLove","Khem",123,"1239567896542"),
            new Book("HealthInstructor","Ganga",98,"1234767896943"),
            new Book("ViceCity","Boris",58,"1234562965743"),
            new Book("Algebra","Michel",698,"1234568896513"),
            new Book("Lyrics","William",65,"1234567896842"),
        };
        public void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener
                Int32 port = 4646;
                IPAddress localAddr = IPAddress.Loopback;

                int clientNumber = 0;

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Task.Run(() => HandleStream(client, ref clientNumber));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        private void HandleStream(TcpClient client, ref int clientNumber)
        {
            throw new NotImplementedException();
        }
    }
}
