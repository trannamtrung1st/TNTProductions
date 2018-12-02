using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using TNT.Helpers.Cryptography;

namespace abc
{

    public class Program
    {
        public static string key = "4vXrlSEk5sSP2T2RIwNlxxMsWGutjF9dhuC4WfM7Do0=";
        public static string iv = "/7wqw5UN3WA0LhSBtJtSgw==";

        public static void Main(string[] args)
        {
            string password = "muzikmylife4ever";
            var p = CryptoFactory.DefaultCryptoProvider;
            var enc = p.Rsa.EncryptToBase64(password);
            var dec = p.Rsa.DecryptFromBase64(enc);
            Console.WriteLine(enc + "\n" + dec);

            using (p)
            {
                enc = p.Rsa.EncryptToBase64(password);
                dec = p.Rsa.DecryptFromBase64(enc);
                Console.WriteLine(enc + "\n" + dec);
            }
        }
    }

    public class PH : DataHasher
    {
        public override string DataTransform(string originalPassword)
        {
            return originalPassword + "TNT";
        }
    }
}
