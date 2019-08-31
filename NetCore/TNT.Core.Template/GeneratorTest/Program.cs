using System;
using System.Linq;
using System.Reflection;
using TNT.Core.Template.DataService;

namespace GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new SimpleGenerator(
                "TestDataService",
                "localhost",
                "TScrumDev",
                "sa", "123456",
                "Models",
                "TScrumContext",
                "../../../../TestDataService");
            gen.Regen(args);
        }
    }
}
