using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoUtilityGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoUtilityGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Utilities\"");
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
                @"manager.StartNewFile(""GeneralUtilsGen.cs"");")),
                new TemplateTextBlock("<#=uGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
