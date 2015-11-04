using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TvShowManagerLibrary.Serialization;

namespace TvShowManagerLibrary.Configurations
{
    public static class ConfigurationManager
    {
        private const string BaseFilePath = "Configuration.xml";

        public static void Save(Configuration configuration)
        {
            Save(BaseFilePath, configuration);
        }

        public static Configuration Load()
        {
            return Load(BaseFilePath);
        }

        public static void Save(string filepath, Configuration configuration)
        {
            XmlSerializerHelper.Serialize(configuration, filepath);
        }

        public static Configuration Load(string filepath)
        {
            return XmlSerializerHelper.Deserialize<Configuration>(filepath) ?? new Configuration();
        }
    }
}
