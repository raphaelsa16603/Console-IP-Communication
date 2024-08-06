using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Common.Config
{
    public class Config
    {
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
        public string ClientIp { get; set; }
        public int ClientPort { get; set; }

        public static Config Load(string filePath)
        {
            var configJson = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Config>(configJson);
        }
    }
}

