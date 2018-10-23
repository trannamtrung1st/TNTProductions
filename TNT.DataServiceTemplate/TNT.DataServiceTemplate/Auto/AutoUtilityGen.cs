using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.DataServiceTemplate.TTGen;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Auto
{
    public class AutoUtilityGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoUtilityGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.Utilities\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateDefaultUtilities();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateDefaultUtilities()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var uGen = new UtilitiesGen(dt);",
                @"manager.StartNewFile(""DefaultUtilities.cs"");")),
                new TemplateTextBlock("<#=uGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
