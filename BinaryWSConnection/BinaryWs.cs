using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryWSConnection
{
    public class BinaryWs
    {
        private static ClientWebSocket _ws = new ClientWebSocket();
        private static Uri _uri = new Uri("wss://ws.binaryws.com/websockets/v3?app_id=1089");

        public BinaryWs()
        {
            
        }


        public static void TestConnection()
        {
            ConnectWS().Wait();
            Console.WriteLine("que pashooooo");
        }

        private static async Task ConnectWS()
        {
            ClientWebSocket ws = new ClientWebSocket();
            Uri uri = new Uri("wss://ws.binaryws.com/websockets/v3?app_id=1089");
            Console.WriteLine("Prepare to connect to: " + uri.ToString());
            Console.WriteLine("\r\n");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            await ws.ConnectAsync(uri, CancellationToken.None);


            Console.WriteLine("The connection is established!");
            Console.WriteLine("\r\n");
        }
    }
}