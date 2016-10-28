using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCP_P2P_Client;

namespace tcp_p2p_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener myServer = new TcpListener(IPAddress.Any, 9000);
            myServer.Start();

            while (true)
            {
                TcpClient myServerTcpconnection = myServer.AcceptTcpClient();
                Console.WriteLine("Connection Established");
                var pecho = new PeerEcho(myServerTcpconnection);
                Thread myThread = new Thread(pecho.DoIt);
                myThread.Start();
            }
        }
    }
}
