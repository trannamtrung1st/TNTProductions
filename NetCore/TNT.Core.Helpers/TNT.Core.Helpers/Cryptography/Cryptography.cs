using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Cryptography
{
    public interface ICryptor
    {
        string EncryptToBase64(string data);
        string DecryptFromBase64(string data);
    }

    public abstract class BaseCryptoProvider : IDisposable
    {
        public ICryptor Aes { get; set; }
        public IDataHasher Hasher { get; set; }
        public ICryptor Rsa { get; set; }
        public ITokenGenerator Generator { get; set; }

        public abstract void Dispose();
    }

    public class CryptoProvider : IDisposable
    {
        public AesCryptor Aes { get; set; }
        public DataHasher Hasher { get; set; }
        public RsaCryptor Rsa { get; set; }
        public TokenGenerator Generator { get; set; }

        public static CryptoProvider DefaultImplementation
        {
            get
            {
                return new CryptoProvider()
                {
                    Aes = new AesCryptor(),
                    Generator = new TokenGenerator(256),
                    Hasher = new DefaultDataHasher(),
                    Rsa = new RsaCryptor(false),
                };
            }
        }

        public void Dispose()
        {
            if (Aes != null)
                Aes.Dispose();
            if (Rsa != null)
                Rsa.Dispose();
            if (Hasher != null)
                Hasher.Dispose();
            if (Generator != null)
                Generator.Dispose();
        }
    }

    public static class CryptoFactory
    {
        public static CryptoProvider DefaultCryptoProvider { get; } = CryptoProvider.DefaultImplementation;

        public static AesKeyProvider GetAesKeyProvider()
        {
            return new AesKeyProvider();
        }

        public static RsaKeyProvider GetRsaKeyProvider(int size)
        {
            return new RsaKeyProvider(size);
        }

        public static DataHasher GetDefaultDataHasher()
        {
            return new DefaultDataHasher();
        }

        public static TokenGenerator GetDefaultTokenGenerator(int tokenSize)
        {
            return new TokenGenerator(tokenSize);
        }

        public static AesCryptor GetDefaultAesCryptor()
        {
            return new AesCryptor();
        }

        public static AesCryptor GetDefaultAesCryptor(string base64key, string base64IV)
        {
            return new AesCryptor(base64key, base64IV);
        }

        public static RsaCryptor GetDefaultRsaCryptor()
        {
            return new RsaCryptor(false);
        }

        public static RsaCryptor GetDefaultRsaCryptor(string publicBase64key, string privateBase64Key, bool fOEAP)
        {
            return new RsaCryptor(publicBase64key, privateBase64Key, fOEAP);
        }

    }
}
