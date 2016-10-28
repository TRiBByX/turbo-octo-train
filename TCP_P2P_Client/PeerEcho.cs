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

        internal void Message()
        {

            Stream connectionStream = connectionseet.GetStream();

            StreamReader sReader = new StreamReader(connectionStream);
            StreamWriter sWriter = new StreamWriter(connectionStream);
            sWriter.AutoFlush = true;
            string message = "";
            try
            {
                while (true)
                {
                    message = sReader.ReadLine();

                    Console.WriteLine(message);

                    var file1 = System.IO.File.ReadAllText(@"C:\Users\allan\Documents\Den\t.txt");
                    var file2 = System.IO.File.ReadAllText(@"C:\Users\allan\Documents\Den\t.txt");

                    sWriter.WriteLine(message.ToUpper());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sWriter.Close();
                sReader.Close();
            }
        }
    }
}
