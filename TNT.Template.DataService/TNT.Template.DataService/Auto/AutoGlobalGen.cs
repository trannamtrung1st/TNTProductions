using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoGlobalGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoGlobalGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Global\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateGlobal();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
                (Data.ServicePool ? "dt.ServicePool = true;" : null),
                (Data.RequestScope ? "dt.RequestScope = true;" : null),
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateGlobal()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var gGen = new GlobalGen(dt);",
                @"manager.StartNewFile(""GlobalGen.cs"");")),
                new TemplateTextBlock("<#=gGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
