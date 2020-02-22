using System;
using System.IO;
using TNT.Core.Helpers.Cryptography;

namespace SimpleAesTool
{
    class Program
    {

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("key.txt");
            string key, iv;
            AesCryptor aes;
            if (lines.Length >= 2)
            {
                key = lines[0];
                iv = lines[1];
                aes = CryptoFactory.GetDefaultAesCryptor(key, iv);
            }
            else aes = CryptoFactory.GetDefaultAesCryptor();
            using (aes)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Current key~iv: {aes.Base64Key}~{aes.Base64IV}");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("1. Encrypt");
                    Console.WriteLine("2. Decrypt");
                    Console.WriteLine("3. Generate key");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose: ");
                    int result;
                    var choice = Console.ReadLine();
                    Console.Clear();
                    if (!int.TryParse(choice, out result))
                        continue;
                    switch (result)
                    {
                        case 1:
                            {
                                Console.WriteLine("1. Encrypt");
                                Console.Write("Input: ");
                                var inp = Console.ReadLine();
                                var outp = aes.EncryptToBase64(inp);
                                Console.WriteLine($"Output: {outp}");
                                Console.WriteLine();
                                Console.WriteLine("Enter to continue");
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("2. Decrypt");
                                Console.Write("Input: ");
                                var inp = Console.ReadLine();
                                var outp = aes.DecryptFromBase64(inp);
                                Console.WriteLine($"Output: {outp}");
                                Console.WriteLine();
                                Console.WriteLine("Enter to continue");
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("3. Generate key");
                                var newkey = CryptoFactory.GetAesKeyProvider();
                                Console.WriteLine($"Key: {newkey.GetBase64Key()}");
                                Console.WriteLine($"IV: {newkey.GetBase64IV()}");
                                Console.WriteLine();
                                Console.WriteLine("Enter to continute");
                            }
                            break;
                        default:
                            return;
                    }

                    Console.ReadLine();
                }
            }

        }
    }
}
