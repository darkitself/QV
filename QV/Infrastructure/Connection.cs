using QV.RequestsAndAnswers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace QV.Infrastructure
{
    public static class Connection
    {
        private static TcpClient tcpClient;
        private static string hostname = "192.168.1.72";
        private static int port = 5555;

        public static void Initialize(string hostname, int port)
        {
            Connection.port = port;
            Connection.hostname = hostname;
        }

        private static void Open() => tcpClient = new TcpClient(hostname, port);
        private static void Close() => tcpClient.Close();

        private static List<byte> IntToBytes(int i)
        {
            return new List<byte> {
                (byte) (i & 0xFF),
                (byte)((i >> 8) & 0xFF),
                (byte)((i >> 16) & 0xFF),
                (byte)((i >> 24) & 0xFF),
            };
        }
        public static Answer RequestToServer<Requst, Answer>(Requst requst, RequestsTypes type)
        {
            Open();
            if (!tcpClient.Connected)
                throw new Exception("Your TCP Client is not connected Register");
            var stream = tcpClient.GetStream();
            WriteData(JsonSerializer.Serialize(requst), stream, type);
            Thread.Sleep(200);
            var answer = ReadData<Answer>(stream);
            Close();
            return answer;
        }

        private static void WriteData(string data, Stream stream, RequestsTypes type)
        {
            if (!tcpClient.Connected)
                throw new Exception("Your TCP Client is not connected Write");
            var buffer = Encoding.UTF8.GetBytes(data);
            var serviceData = IntToBytes(buffer.Length + 1);
            serviceData.Add((byte)type);
            stream.Write(serviceData.Concat(buffer).ToArray(), 0, buffer.Length + 5);
        }

        private static T ReadData<T>(NetworkStream stream)
        {
            if (!tcpClient.Connected)
                throw new Exception("Your TCP Client is not connected Read");
            Thread.Sleep(200);
            var size = new byte[4];
            stream.Read(size, 0, 4);
            var data = new byte[BitConverter.ToInt32(size, 0)];
            for (int i = 0; i < data.Length;)
                if (stream.DataAvailable)
                {
                    stream.Read(data, i, 1);
                    i++;
                }
            var a = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(a);
        }
    }
}
