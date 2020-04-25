using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestCodeFirst.Models;
using TNT.Core.Template.DataService;

namespace GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFirstGen();
        }

        static void DbFirstGen(string[] args)
        {
            var gen = new DbFirstGenerator(
                "TestDataService",
                "localhost",
                "Template", "sa", "123456",
                "Models", "TemplateContext",
                "../../../../TestDataService");
            gen.Regen(args);
        }

        static void CodeFirstGen()
        {
            var gen = new CodeFirstGenerator();
            using (var context = new TemplateContext())
            {
                gen.Generate(context,
                    "../../../../TestCodeFirst",
                    "TestCodeFirst");
            }
        }
    }
}
