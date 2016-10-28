using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 

namespace TCP_P2P_Server
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
                Echo service = new Echo(myServerTcpconnection);
                Thread myThread = new Thread(service.DoIt);
                myThread.Start();
            }
        }
    }
}
