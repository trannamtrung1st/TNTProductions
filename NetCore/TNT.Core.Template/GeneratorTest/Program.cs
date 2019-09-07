using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TNT.Core.Template.DataService.MongoDB;

namespace GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleGenerator.Generate(
                "../../../Models",
                "GeneratorTest.Models",
                "../../../../TestDataService",
                "TestDataService",
                TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper.JsonPropertyFormatEnum.JsonStyle);
        }
    }
}
