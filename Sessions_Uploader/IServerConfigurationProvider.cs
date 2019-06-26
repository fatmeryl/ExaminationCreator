using System.Collections.Generic;

namespace Sessions_Uploader
{
    public interface IServerConfigurationProvider
    {
        Dictionary<string, string> GetServerConfiguration();
    }
}
