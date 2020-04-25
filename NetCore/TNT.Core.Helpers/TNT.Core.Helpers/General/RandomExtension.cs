using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.General
{
    public static class RandomExtension
    {
        public static int NextDigit(this Random rand)
        {
            return rand.Next(0, 10);
        }

        public static char NextUpperLetter(this Random rand)
        {
            return (char)rand.Next(65, 91);
        }

        public static bool NextBool(this Random rand)
        {
            return rand.Next() % 2 == 1;
        }

        public const string Uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Lowers = "abcdefghijklmnopqrstuvwxyz";
        public const string Digits = "0123456789";
        public const string Letters = Uppers + Lowers;
        public const string Letters_Digits = Letters + Digits;
        public const string Uppers_Digits = Uppers + Digits;
        public const string Lowers_Digits = Lowers + Digits;

        public static char NextUpperOrDigit(this Random rand)
        {
            return Uppers_Digits[rand.Next(0, Uppers_Digits.Length)];
        }

        public static char NextCharInString(this Random rand, string str)
        {
            return str[rand.Next(0, str.Length)];
        }

        public static char NextLowerLetter(this Random rand)
        {
            return (char)rand.Next(97, 123);
        }

        public static char NextLetter(this Random rand)
        {
            return Letters[rand.Next(0, Letters.Length)];
        }

        public static string RandomStringFrom(this Random rand, string srcStr, int length)
        {
            var str = new StringBuilder("");
            var srcLen = srcStr.Length;
            for (int i = 0; i < length; i++)
            {
                str.Append(srcStr[rand.Next(srcLen)]);
            }
            return str.ToString();
        }

    }
}
