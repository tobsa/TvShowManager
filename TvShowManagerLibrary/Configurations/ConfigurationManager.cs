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
        public static Configuration Configuration { get; set; } = new Configuration();

        public static void Save(string filename)
        {
            XmlSerializerHelper.Serialize(Configuration, filename);
        }

        public static void Load(string filename)
        {
            Configuration = XmlSerializerHelper.Deserialize<Configuration>(filename) ?? new Configuration();
        }
    }
}
