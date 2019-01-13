using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Cryptography
{
    public class CryptoRandom
    {
        protected RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public string RandomStringFrom(int length, string srcStr)
        {
            var bytes = new byte[length];
            var srcLength = srcStr.Length;
            rng.GetBytes(bytes);
            var str = "";
            foreach (var b in bytes)
                str += srcStr[b % srcLength];
            return str;
        }
    }
}
