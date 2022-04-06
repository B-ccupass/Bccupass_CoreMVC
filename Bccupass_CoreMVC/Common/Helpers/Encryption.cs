using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Common.Helpers
{
    public static class Encryption
    {
        public static string SHA256Encrypt(string strSource)
        {
            byte[] source = Encoding.Default.GetBytes(strSource);
            byte[] crypto = new SHA256CryptoServiceProvider().ComputeHash(source);

            string result = crypto.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));

            return result.ToUpper();
        }
    }
}
