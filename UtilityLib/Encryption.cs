using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UtilityLib
{
    public static class Encryption
    {
        public static string ToAsciiString(this string data)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(data));
        }
    }
}
