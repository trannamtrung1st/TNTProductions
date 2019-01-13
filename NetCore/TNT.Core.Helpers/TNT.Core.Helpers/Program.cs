using System;
using TNT.Core.Helpers.Cryptography;

namespace TNT.Core.Helpers
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new AesCryptor();
            var a = c.EncryptToBase64("AAA");
            Console.WriteLine(a);
            Console.WriteLine(c.DecryptFromBase64(a));
        }
    }
}
