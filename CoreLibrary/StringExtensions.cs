using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool HasValue(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsEmpty(this string str)
        {
            return str == "";
        }

        public static bool IsNull(this string str)
        {
            return str == null;
        }

        /// <summary>
        /// Finds and extracts the string between two tags
        /// </summary>
        /// <param name="str">The string to apply this method to</param>
        /// <param name="beginTag">The begin tag</param>
        /// <param name="endTag">The end tag</param>
        /// <returns>The extracted string between two tags</returns>
        public static string FindSubstring(this string str, string beginTag, string endTag)
        {
            var beginIndex = str.IndexOf(beginTag, StringComparison.Ordinal) + beginTag.Length;
            var endIndex = str.IndexOf(endTag, beginIndex, StringComparison.Ordinal);

            return str.Substring(beginIndex, endIndex - beginIndex);
        }
    }
}
