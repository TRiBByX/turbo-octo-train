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
        private TcpClient connectionseet;

        public Echo(TcpClient connectionseet)
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
                while (message.ToLower() != "stop")
                {
                    message = sReader.ReadLine();

                    Console.WriteLine(message);

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        var BatFile = System.IO.File.ReadAllText(@"C:\Users\allan\Documents\Den\t.txt");
                        var JokFile = System.IO.File.ReadAllText(@"C:\Users\allan\Documents\Den\t.txt");

                        string[] messages = new string[2];
                        messages = message.Split(' ');

                        var command = messages[0];
                        var fileSelect = messages[1];

                        if (command.ToString().ToUpper() == "c")
                        {
                            if (fileSelect.ToString().ToUpper() == "batman")
                                sWriter.WriteLine(BatFile);
                            else if (fileSelect.ToString().ToUpper() == "joker")
                                sWriter.WriteLine(JokFile);
                        }
                        else
                        {
                            sWriter.WriteLine("You messed up...");
                        }



                        sWriter.Close();
                        //}
                        //catch (ArgumentException e)
                        //{

                        //    throw e;
                        //}

                        //string response = Console.ReadLine();

                        sWriter.WriteLine(message.ToUpper());
                    }
                    else
                    {
                        sWriter.WriteLine(message.ToUpper());
                    }


                }
            }
            catch (Exception)
            {

                sWriter.Close();
                sReader.Close();
            }

        }
    }
}
