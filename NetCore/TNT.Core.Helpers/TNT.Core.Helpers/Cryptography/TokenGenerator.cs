using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Cryptography
{
    public interface ITokenGenerator
    {
        string Generate();
        string Generate(int newSize);
    }

    public class TokenGenerator : ITokenGenerator, IDisposable
    {
        protected int size;
        protected RNGCryptoServiceProvider rng;
        public TokenGenerator(int size)
        {
            this.size = size;
            rng = new RNGCryptoServiceProvider();
        }

        public string Generate()
        {
            var bytes = new byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public string Generate(int newSize)
        {
            var bytes = new byte[newSize];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public void Dispose()
        {
            rng.Dispose();
        }
    }
}
