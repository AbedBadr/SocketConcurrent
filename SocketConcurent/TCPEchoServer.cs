using System;
using System.Net.Sockets;
using System.IO;

namespace SocketConcurent
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

                echoService.DoIt();
            }
        }
    }
}
