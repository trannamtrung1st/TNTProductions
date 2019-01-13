using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using TNT.Helpers.Cryptography;
using TNT.Helpers.General;
using System.Collections.Generic;
using System.Diagnostics;

namespace abc
{

    public class Program
    {
        public static string key = "4vXrlSEk5sSP2T2RIwNlxxMsWGutjF9dhuC4WfM7Do0=";
        public static string iv = "/7wqw5UN3WA0LhSBtJtSgw==";

        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static void Main(string[] args)
        {
            var rand2 = new Random();
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 5000; i++)
            {
                var code = rand2.RandomStringFrom(chars, 10);
                Console.WriteLine(code);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
          
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
