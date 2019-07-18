using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace SocketTest2
{
    class TCPIPServer
    {

        TcpListener serverObject = default(TcpListener);
        TcpClient clientObject = default(TcpClient);

        public Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();

        bool connectFlag = true;

        /// <summary>
        /// 생성자 생략 가능?
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        //public TCPIPServer()
        //{

        //}

        public void ServerStart(string ip, int port)
        {
            try
            {

                string IP = ip;
                int PORT = port;

                //  서버가 제대로 열렸는지 확인?! 어떻게?!
                serverObject = new TcpListener(IPAddress.Parse(IP), PORT);
                serverObject.Start();
                Console.WriteLine(">>   Start Server.");

                while (connectFlag)
                {
                    Console.WriteLine(">>   Wating For Client.");
                    clientObject = serverObject.AcceptTcpClient();
                    Console.WriteLine(">>   Client Connect.");
                    ///
                    /// 
                    ///  클라이언트 객체 어떻게 동적으로 생성할 것인지?
                    ///
                    ///
                    string clientIP = clientObject.Client.RemoteEndPoint.ToString();
                    Trace.WriteLine(clientIP);
                    clientList.Add(clientIP.Split(':')[0], clientObject);
                    TCPIPClientHandler cHandler = new TCPIPClientHandler(clientObject);
                    cHandler.receiveEvent += Server_ReceiveEvent;

                    Task client = Task.Run(() => cHandler.AcceptClient());

                }

            }

            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void Server_ReceiveEvent(string msg)
        {
            Console.WriteLine(msg);

            TcpClient tmpClient;

            if (clientList.TryGetValue("127.0.0.1", out tmpClient))
            {
                Console.WriteLine(tmpClient);
            }

        }





    }
}
