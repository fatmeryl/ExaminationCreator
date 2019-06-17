using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            try
            {
                var json = File.ReadAllText(this.configPath);

                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                return values;
            }
            catch (Exception e)
            {
                MessageBox.Show("Configuration file does not exist." +
                                "\nPlease provide valid configuration file.", 
                    "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
