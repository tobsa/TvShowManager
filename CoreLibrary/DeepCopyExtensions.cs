using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public static class DeepCopyExtensions
    {
        public static T DeepClone<T>(this T source)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
