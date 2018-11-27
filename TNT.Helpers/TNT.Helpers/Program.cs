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
            using (var kp = RsaFactory.CreateKeyProvider(1024))
            using (var rsa = RsaFactory.CreateCryptor(kp.GetPublicBase64Key(), kp.GetPrivateBase64Key(), false))
            {
                var test = rsa.EncryptToBase64(password);
                Console.WriteLine(test);
                Console.WriteLine(rsa.DecryptFromBase64(test));

                test = rsa.EncryptToBase64(password + "123123");
                Console.WriteLine(test);
                Console.WriteLine(rsa.DecryptFromBase64(test));
                test = rsa.EncryptToBase64(password + "vn82123");
                Console.WriteLine(test);
                Console.WriteLine(rsa.DecryptFromBase64(test));
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
