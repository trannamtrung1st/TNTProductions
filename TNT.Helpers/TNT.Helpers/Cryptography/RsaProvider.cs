﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.Cryptography
{
    public static class RsaFactory
    {
        public static RsaKeyProvider CreateKeyProvider(int size)
        {
            return new RsaKeyProvider(size);
        }

        public static RsaCryptor CreateCryptor(string publicBase64Key, string privateBase64Key, bool fOEAP)
        {
            return new RsaCryptor(publicBase64Key, privateBase64Key, fOEAP);
        }
    }

    public class RsaKeyProvider : IDisposable
    {
        protected RSACryptoServiceProvider rsa;
        public RsaKeyProvider(int size)
        {
            rsa = new RSACryptoServiceProvider(size);
        }

        public string GetPublicBase64Key()
        {
            return Convert.ToBase64String(rsa.ExportCspBlob(false));
        }

        public string GetPrivateBase64Key()
        {
            return Convert.ToBase64String(rsa.ExportCspBlob(true));
        }

        public void Dispose()
        {
            rsa.Dispose();
        }
    }

    public class RsaCryptor : IDisposable
    {
        protected RSACryptoServiceProvider rsaEncrypt;
        protected RSACryptoServiceProvider rsaDecrypt;
        protected bool fOEAP;
        public RsaCryptor(string publicBase64Key, string privateBase64Key, bool fOEAP)
        {
            rsaEncrypt = new RSACryptoServiceProvider();
            rsaDecrypt = new RSACryptoServiceProvider();

            rsaEncrypt.ImportCspBlob(Convert.FromBase64String(publicBase64Key));
            rsaDecrypt.ImportCspBlob(Convert.FromBase64String(privateBase64Key));
            this.fOEAP = fOEAP;
        }

        public string EncryptToBase64(string data)
        {
            return Convert.ToBase64String(rsaEncrypt.Encrypt(Encoding.UTF8.GetBytes(data), fOEAP));
        }

        public string DecryptFromBase64(string data)
        {
            return Encoding.UTF8.GetString(rsaDecrypt.Decrypt(Convert.FromBase64String(data), fOEAP));
        }

        public void Dispose()
        {
            rsaEncrypt.Dispose();
            rsaDecrypt.Dispose();
        }
    }

}
