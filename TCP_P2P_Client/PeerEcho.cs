using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_P2P_Client
{
    class PeerEcho
    {
        private TcpClient connectionseet;

        public PeerEcho(TcpClient connectionseet)
        {
            this.connectionseet = connectionseet;
        }

        internal void DoIt()
        {

            Stream connectionStream = connectionseet.GetStream();

            StreamReader sReader = new StreamReader(connectionStream);
            StreamWriter sWriter = new StreamWriter(connectionStream);
            sWriter.AutoFlush = true;

            while (true)
            {
                string message = "";
                sWriter.WriteLine(message);
                Console.WriteLine($"Server: {sReader.ReadLine()}");
            }
        }
    }
}
