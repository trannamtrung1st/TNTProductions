using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
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
                "Template", "sa", "123456",
                "Models", "TemplateContext",
                "../../../../TestDataService");
            gen.Regen(args);
        }
    }
}
