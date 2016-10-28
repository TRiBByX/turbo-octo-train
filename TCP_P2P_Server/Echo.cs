using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_P2P_Server
{
    class Echo
    {
        private TcpClient _connectionset;

        public Echo(TcpClient connectionset)
        {
            this._connectionset = connectionset;
        }

        internal void DoIt()
        {

            Stream connectionStream = _connectionset.GetStream();

            StreamReader sReader = new StreamReader(connectionStream);
            StreamWriter sWriter = new StreamWriter(connectionStream);
            sWriter.AutoFlush = true;
            string message = "";

            char[] sepChars = {' '};

            string[] splitMessage = message.Split(sepChars);
            while (!string.IsNullOrEmpty(message))
            {
                switch (splitMessage[0])
                {
                    case "GET":
                        //byte[] newMessage = File.ReadAllBytes($@"{Environment.SpecialFolder.MyDocuments}\{splitMessage[1]}");
                        message =
                            Convert.ToBase64String(
                                File.ReadAllBytes($@"{Environment.SpecialFolder.MyDocuments}\{splitMessage[1]}"));
                        sWriter.Write(message);
                        break;
                    case "SEND":

                        break;
                    default:
                        break;
                }
            }
            connectionStream.Close();

        }
    }
}
