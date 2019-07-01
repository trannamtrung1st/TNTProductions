using System;
using System.Linq;
using System.Reflection;
using TNT.Core.Template.DataService.MongoDB;

namespace GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var eNamespace = "GeneratorTest.Models";
            var eTempFolder = "../../../Models";
            var outputPath = "../../../../TestDataService";
            var projectName = "TestDataService";
            var jType = TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper.JsonPropertyFormatEnum.JsonStyle;

            SimpleGenerator.Generate(eTempFolder, eNamespace, outputPath, projectName, jType);
        }
    }
}
