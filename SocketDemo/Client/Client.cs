using ChatServer;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public class Client
    {
        static async Task Main(string[] args)
        {
            var endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.25"), Infor.port);

            var clientSocket = new Socket(
                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            await clientSocket.ConnectAsync(endPoint);
            var buffer = new byte[1024];
            var r = await clientSocket.ReceiveAsync(buffer);
            var welcome = Encoding.UTF8.GetString(buffer, 0, r);
            Console.WriteLine(welcome);
            Task.Run(() => ListenSeverSay(clientSocket));
            

            while (true)
            {
                Thread.Sleep(500);
                    Console.Write("Enter: ");

                    var myMessage = Console.ReadLine();

                    if(myMessage == "close")
                    {
                        await HelloServerSocketAsynce(clientSocket, "Disconnected");
                        clientSocket.Close();
                        return;
                    }
                    if (myMessage != null)
                    {
                        await HelloServerSocketAsynce(clientSocket, myMessage);
                    }
                
                
            }
        }

        public static async Task ListenSeverSay(Socket clientSocket)
        {
            while (true)
            {
                var buffer = new byte[1024];
                var r = await clientSocket.ReceiveAsync(buffer);
                var welcome = Encoding.UTF8.GetString(buffer, 0, r);
                Console.WriteLine(welcome);
            }
        }

        public static async Task HelloServerSocketAsynce(Socket clientSocket, string message)
        {
            await clientSocket.SendAsync(Encoding.UTF8.GetBytes(message));
        }

    }
}
