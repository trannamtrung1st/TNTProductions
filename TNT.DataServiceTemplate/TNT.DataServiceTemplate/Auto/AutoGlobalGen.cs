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
    public class AutoGlobalGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoGlobalGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.Global\"");
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
                (Data.ServicePool ? "dt.ServicePool = true;" : ""),
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateGlobal()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var gGen = new GlobalGen(dt);",
                @"manager.StartNewFile(""Global.cs"");")),
                new TemplateTextBlock("<#=gGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
