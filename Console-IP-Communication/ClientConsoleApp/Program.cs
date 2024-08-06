using System;
using System.Collections.Generic;
using System.Threading;
using Common.Config;
using Common.Models;
using Common.Communication;
using Common.Logging;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = Config.Load("clientConfig.json");
                var errorLogger = new ErrorLogger("Logs/ClientErrors");
                var dataLogger = new DataLogger("Logs/ClientData");

                var client = new Client(config.ClientIp, config.ClientPort, config.ServerIp, config.ServerPort, errorLogger, dataLogger);
                client.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in client initialization: {ex.Message}");
            }
        }
    }

    public class Client
    {
        private readonly ICommunication _communication;
        private readonly ErrorLogger _errorLogger;
        private readonly DataLogger _dataLogger;

        public Client(string clientIp, int clientPort, string serverIp, int serverPort, ErrorLogger errorLogger, DataLogger dataLogger)
        {
            try
            {
                _communication = new TcpCommunication(serverIp, serverPort);
                _errorLogger = errorLogger;
                _dataLogger = dataLogger;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing client communication: {ex.Message}");
                _errorLogger.LogError(ex);
                throw;
            }
        }

        public void Start()
        {
            try
            {
                Console.WriteLine("Client started.");
                var timer = new Timer(SendData, null, 0, 3000);

                while (true)
                {
                    var staticList = _communication.Receive<List<ComplexObject>>();
                    if (staticList != null)
                    {
                        Console.WriteLine("Received static list from server.");
                        _dataLogger.LogData("Received static list from server.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting client: {ex.Message}");
                _errorLogger.LogError(ex);
            }
        }

        private void SendData(object state)
        {
            try
            {
                var dataToSend = new List<ComplexObject>
                {
                    new ComplexObject { Id = 1, Name = "ClientObject1", Timestamp = DateTime.Now }
                };

                _communication.Send(dataToSend);
                _dataLogger.LogData("Sent data to server.");
                Console.WriteLine("Sent data to server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
                _errorLogger.LogError(ex);
            }
        }
    }
}
