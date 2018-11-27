using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.Cryptography
{
    public static class AesFactory
    {

        public static AesCryptor CreateCryptor()
        {
            return new AesCryptor();
        }

        public static AesCryptor CreateCryptor(string base64key, string base64iv)
        {
            return new AesCryptor(base64key, base64iv);

        }

    }

    public class AesCryptor : IDisposable
    {
        protected AesCryptoServiceProvider aesAlg;

        public string Base64Key { get { return Convert.ToBase64String(aesAlg.Key); } }
        public string Base64IV { get { return Convert.ToBase64String(aesAlg.IV); } }

        public AesCryptor()
        {
            aesAlg = new AesCryptoServiceProvider();
            aesAlg.GenerateIV();
            aesAlg.GenerateKey();
        }

        public AesCryptor(string base64key, string base64iv)
        {
            aesAlg = new AesCryptoServiceProvider();
            aesAlg.Key = Convert.FromBase64String(base64key);
            aesAlg.IV = Convert.FromBase64String(base64iv);
        }

        public string EncryptToBase64(string data)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor();

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(data);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string DecryptFromBase64(string base64)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor();

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(base64)))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                var plaintext = srDecrypt.ReadToEnd();
                return plaintext;
            }
        }

        public void Dispose()
        {
            aesAlg.Dispose();
        }
    }


}
