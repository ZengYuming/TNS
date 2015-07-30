using System;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Core.Extensions
{
    public static class ConvertionExtension
    {
        public static int ConvertToInteger(this string source)
        {
            return source.ConvertToInteger(0);
        }
        public static int ConvertToInteger(this string source, int defaultValue)
        {
            int result;
            if (!int.TryParse(source, out result))
            {
                return defaultValue;
            }
            return result;
        }
        public static bool ConvertToBool(this string source)
        {
            bool result;
            bool.TryParse(source, out result);
            return result;
        }
        public static DateTime ConvertToDateTime(this string source)
        {
            DateTime result;
            DateTime.TryParse(source, out result);
            return result;
        }

        public static string ConvertToFormatString(this string source)
        {
            return string.Format("{0:yyyy-MM-dd}", source.ConvertToDateTime());
        }
        public static string ConvertToFormatString(this DateTime source) {
            return string.Format("{0:yyyy-MM-dd}", source);
        }
        public static string MD5(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }
            string empty = string.Empty;
            MD5 mD = System.Security.Cryptography.MD5.Create();
            byte[] value = mD.ComputeHash(Encoding.UTF8.GetBytes(val));
            return BitConverter.ToString(value).Replace("-", string.Empty);
        }
    }
}
