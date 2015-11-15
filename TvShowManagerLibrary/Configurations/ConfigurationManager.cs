using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TvShowManagerLibrary.Serialization;

namespace TvShowManagerLibrary.Configurations
{
    public static class ConfigurationManager
    {
        private static Configuration configuration = new Configuration();

        public static string ApiKey { get; set; }

        public static void Load(string filepath)
        {
            configuration = XmlSerializerHelper.Deserialize<Configuration>(filepath);

            var properties1 = configuration.GetType().GetProperties();
            var properties2 = typeof (ConfigurationManager).GetProperties();

            foreach (var property1 in properties1)
            {
                foreach (var property2 in properties2.Where(property2 => property1.Name == property2.Name))
                {
                    property2.SetValue(null, property1.GetValue(configuration));
                }
            }
        }
    }
}
