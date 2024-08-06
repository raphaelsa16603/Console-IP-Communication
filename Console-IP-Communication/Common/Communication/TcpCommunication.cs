using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json;


namespace Common.Communication
{
    public class TcpCommunication : ICommunication
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        public TcpCommunication(string ip, int port)
        {
            try
            {
                _client = new TcpClient(ip, port);
                _stream = _client.GetStream();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
                throw;
            }
        }

        public TcpCommunication(TcpClient client)
        {
            try
            {
                _client = client;
                _stream = client.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing communication: {ex.Message}");
                throw;
            }
        }

        public void Start()
        {
            // No implementation needed for this demo
        }

        public void Send<T>(T data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var bytes = Encoding.UTF8.GetBytes(json);
                _stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
            }
        }

        public T Receive<T>()
        {
            try
            {
                var buffer = new byte[1024];
                var bytesRead = _stream.Read(buffer, 0, buffer.Length);
                var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data: {ex.Message}");
                return default;
            }
        }
    }
}



