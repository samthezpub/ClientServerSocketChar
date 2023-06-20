using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerSocketChar.Client
{
    public interface IClient
    {
        public Task<TcpClient> ConnectServer();
        public void StopConnection();
        public TcpClient GetSocket();
        public void SendMessage(string Message);
        public Task<string> ReceiveMessage();
    }
}
