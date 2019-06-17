using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Sessions_Uploader
{
    public class ServerConfigurationFromConfigProvider : IServerConfigurationProvider
    {
        private readonly string configPath;

        public ServerConfigurationFromConfigProvider(string configPath)
        {
            this.configPath = configPath;
        }

        public Dictionary<string, string> GetServerConfiguration()
        {
            var json = File.ReadAllText(this.configPath);

            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return values;
        }
    }
}
