using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.Cryptography
{
    public abstract class DataHasher : IDisposable
    {

        protected SHA256Cng shaHash;
        public DataHasher()
        {
            shaHash = new SHA256Cng();
        }

        public void Dispose()
        {
            shaHash.Dispose();
        }

        public string Hash(string data)
        {
            return Convert.ToBase64String(shaHash.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }

        public string Hash(string data, bool transform)
        {
            if (transform)
                data = DataTransform(data);
            return Convert.ToBase64String(shaHash.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }

        public abstract string DataTransform(string originalData);


    }
}
