using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerForm
{
    public class Server
    {
        private Socket _socket;
        public void Start()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var endPoint = new IPEndPoint(IPAddress.Any, 50000);
                _socket.Bind(endPoint);

                ThreadStart ts = Listen;
                var thread = new Thread(ts);
                thread.Start();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Listen()
        {
            try
            {
                _socket.Listen(1);
                while (true)
                {
                    var client = _socket.Accept();
                    var networkStream = new NetworkStream(client);
                    var obrada = new Worker(networkStream);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}