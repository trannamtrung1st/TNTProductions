using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Auto;
using static TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper;

namespace TNT.Core.Template.DataService.MongoDB
{
    public static class SimpleGenerator
    {

        public static void Generate(string eTempFolder, string eNamespace, string outputProjectPath,
            string outputProjectName, JsonPropertyFormatEnum jType)
        {
            var entities = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Namespace == eNamespace);
            var gen = new DataServiceGen(entities, eTempFolder, "../../../", outputProjectPath, outputProjectName,
                jType);
            gen.Generate();
        }

    }
}
