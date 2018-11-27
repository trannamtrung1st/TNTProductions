using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoServiceGen : TemplateGen
    {

        private DataInfo Data { get; set; }
        public AutoServiceGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Models.Services\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateBaseViewModel();
            GenerateEntityViewModel();
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

        private void GenerateBaseViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var baseSVGen = new ServiceGen(dt);",
                @"manager.StartNewFile(""BaseServiceGen.cs"");")),
                new TemplateTextBlock("<#=baseSVGen.Generate()#>"));
        }

        private void GenerateEntityViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "foreach (var e in dt.Entities)", "{"),
                new StatementGen(true,
                    "var sGen = new EntityServiceGen(e);",
                    "manager.StartNewFile(e.EntityName+\"ServiceGen.cs\");")),
                new TemplateTextBlock("<#=sGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
