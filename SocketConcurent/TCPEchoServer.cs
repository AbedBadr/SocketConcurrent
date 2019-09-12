using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SocketConcurrent
{
    class TCPEchoServer
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");

                EchoService echoService = new EchoService(connectionSocket);

                Thread myThread = new Thread(echoService.DoIt);

                myThread.Start();
            }
        }
    }
}
