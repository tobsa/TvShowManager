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

        public static int IndexOfNth(this string input, string value, int nth)
        {
            var startIndex = 0;
            while (true)
            {
                if (nth < 1)
                    throw new NotSupportedException("Param 'nth' must be greater than 0!");

                var index = input.IndexOf(value, startIndex, StringComparison.Ordinal);

                if (nth == 1)
                    return index;
                if (index == -1)
                    return -1;

                startIndex = index + 1;
                nth = --nth;
            }
        }

        public static string Slice(this string str, int start, int end)
        {
            if (end < 0)
                end = str.Length + end;

            return str.Substring(start, end - start);
        }

        public static string SliceIndexOfNth(this string str, string startValue, int startIndex, string endValue, int endIndex)
        {
            return str.Slice(str.IndexOfNth(startValue, startIndex), str.IndexOfNth(endValue, endIndex));
        }

        public static string SliceIndexOfNth(this string str, string value, int startIndex, int endIndex)
        {
            return str.SliceIndexOfNth(value, startIndex, value, endIndex);
        }
    }
}
