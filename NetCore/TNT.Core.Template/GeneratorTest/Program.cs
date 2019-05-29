using System;
using TNT.Core.Template.DataService;

namespace GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new SimpleGenerator(
                @"TestDataService",
                @"localhost",
                @"EzReq",
                @"sa",
                @"123456",
                @"Models/Entities",
                @"DataContext",
                @"../../../../TestDataService");
            gen.Regen(args);
        }
    }
}
