using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketTest2
{

    class TCPIPClientHandler
    {

        public delegate void ReceiveEvent(string msg);
        public event ReceiveEvent receiveEvent;

        public TcpClient tcpClient;

        byte[] sendBuffer = new byte[512];

        public TCPIPClientHandler(TcpClient client)
        {
            tcpClient = client;
        }

        public void AcceptClient()
        {
            try
            {

                NetworkStream tcpStream = tcpClient.GetStream();
                byte[] receiveBuffer = new byte[1024];
                int dataBytes;

                while ((dataBytes = tcpStream.Read(receiveBuffer, 0, receiveBuffer.Length)) != 0)
                {
                    string data = System.Text.Encoding.ASCII.GetString(receiveBuffer, 0, dataBytes);
                    //Console.WriteLine(data);

                    receiveEvent(data);
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



    }
}
