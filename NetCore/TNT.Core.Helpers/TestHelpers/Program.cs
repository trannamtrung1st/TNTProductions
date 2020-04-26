using System;
using TNT.Core.Helpers.Data;

namespace TestHelpers
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new string[] { "1", "ABC" }.GetDataParameters("str");
        }
    }
}
