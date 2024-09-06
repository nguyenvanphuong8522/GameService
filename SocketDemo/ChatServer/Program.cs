using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class Program
    {
        static async void Main(string[] args)
        {
            var endPoint = new IPEndPoint(IPAddress.Loopback, 8899);
            var serverSocket = new Socket(

                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            serverSocket.Bind(endPoint);

            Console.WriteLine($"Listening... {endPoint.Port}");
            serverSocket.Listen();


            var clientSocket = await serverSocket.AcceptAsync();

            while(true)
            {
                await HandleClientSocketAsynce(clientSocket);
            }

        }

        public static async Task HandleClientSocketAsynce(Socket clientSocket)
        {
            
        }
    }
}