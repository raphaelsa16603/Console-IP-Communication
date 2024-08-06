using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Common.Config;
using Common.Models;
using Common.Communication;
using Common.Logging;

namespace ServerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = Config.Load("serverConfig.json");
                var errorLogger = new ErrorLogger("Logs/ServerErrors");
                var dataLogger = new DataLogger("Logs/ServerData");

                var server = new Server(config.ServerIp, config.ServerPort, errorLogger, dataLogger);
                server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in server initialization: {ex.Message}");
            }
        }
    }

    public class Server
    {
        private readonly TcpListener _listener;
        private readonly List<ComplexObject> _staticList;
        private List<ICommunication> _clients;
        private readonly ErrorLogger _errorLogger;
        private readonly DataLogger _dataLogger;

        public Server(string ip, int port, ErrorLogger errorLogger, DataLogger dataLogger)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Parse(ip), port);
                _staticList = new List<ComplexObject>
                {
                    new ComplexObject { Id = 1, Name = "Object1", Timestamp = DateTime.Now },
                    new ComplexObject { Id = 2, Name = "Object2", Timestamp = DateTime.Now }
                };
                _clients = new List<ICommunication>();
                _errorLogger = errorLogger;
                _dataLogger = dataLogger;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing server: {ex.Message}");
                _errorLogger.LogError(ex);
                throw;
            }
        }

        public void Start()
        {
            try
            {
                Console.WriteLine("Server started.");
                _listener.Start();

                var acceptThread = new Thread(AcceptClients);
                acceptThread.Start();

                var timer = new Timer(SendData, null, 0, 250);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
                _errorLogger.LogError(ex);
            }
        }

        private void AcceptClients()
        {
            try
            {
                while (true)
                {
                    var client = _listener.AcceptTcpClient();
                    var clientComm = new TcpCommunication(client);
                    _clients.Add(clientComm);
                    Console.WriteLine("Client connected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accepting clients: {ex.Message}");
                _errorLogger.LogError(ex);
            }
        }

        private void SendData(object state)
        {
            try
            {
                var dataToSend = new List<ComplexObject>
                {
                    new ComplexObject { Id = 1, Name = "ServerObject1", Timestamp = DateTime.Now }
                };

                foreach (var client in _clients)
                {
                    client.Send(dataToSend);
                    _dataLogger.LogData($"Sent data to client: {client}");
                }
                Console.WriteLine("Sent data to clients.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
                _errorLogger.LogError(ex);
            }
        }
    }
}
