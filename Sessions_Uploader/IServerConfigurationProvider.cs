using System.Collections.Generic;

namespace ExaminationCreator
{
    public interface IServerConfigurationProvider
    {
        Dictionary<string, string> GetServerConfiguration();
    }
}
