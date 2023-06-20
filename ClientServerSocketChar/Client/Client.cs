using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientServerSocketChar.Client
{
    public class Client : IClient
    {
        Client _client = new Client();
        
        
        public async Task<TcpClient> ConnectServer()
        {
            using TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", 8888);
            return tcpClient;
        }
        public TcpClient GetSocket()
        {
            return ConnectServer().Result;
        }

        public void SendMessage(string Message)
        {
            var Socket = this.GetSocket();
            byte[] msg = Encoding.UTF8.GetBytes(Message);
            Socket.Client.Send(msg);
        }

        public async Task<string> ReceiveMessage()
        {
            var Socket = this.GetSocket();
            byte[] bytes = new byte[1024];
            int byteCount = Socket.Client.Receive(bytes, 0, bytes.Length, SocketFlags.None);

            if (byteCount > 0)
            {
                return Encoding.UTF8.GetString(bytes, 0, byteCount);
            }
            return "*Пустое сообщение*";
        }


        public void StopConnection()
        {
            var Socket = this.GetSocket();
            Socket.Client.Close();
        }
    }
}
