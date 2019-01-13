using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Cryptography
{
    public interface IDataHasher
    {
        string Hash(string data);
    }

    public abstract class DataHasher : IDataHasher, IDisposable
    {

        protected SHA256 shaHash;
        public DataHasher()
        {
            shaHash = SHA256.Create();
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

    public class DefaultDataHasher : DataHasher
    {
        public override string DataTransform(string originalData)
        {
            return originalData;
        }
    }
}
