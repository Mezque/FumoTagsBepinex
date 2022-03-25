using System;
using System.Security.Cryptography;
using System.Text;

namespace FumoTagsBepinex.Modules
{
    public static class UserProtections
    {
        public static string EncodeBase64(this string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }
        public static string DecodeBase64(this string value)
        {
            var valueBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
        public static string SHA256(string value)
        {
            HashAlgorithm hashAlgorithm = new SHA256Managed();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(value)))
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
