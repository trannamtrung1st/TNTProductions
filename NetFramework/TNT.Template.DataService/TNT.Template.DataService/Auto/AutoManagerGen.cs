using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoManagerGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoManagerGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Models\"");
            ResolveMapping["project"] = dt.ProjectName;
            ResolveMapping["context"] = dt.ContextName;

            GenerateInitManager();
            //GenrateContextManager();
            GenerateUnitOfWork();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var solutionPath = Host.ResolveAssemblyReference(""$(SolutionDir)"");",
                @"var dt = new EdmxParser(@""" + Data.EdmxPath + @""".Replace(""{project}"", projectPath).Replace(""{solution}"", solutionPath) ,""`project`"").Data;",
                (Data.RequestScope ? "dt.RequestScope = true;" : ""),
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateUnitOfWork()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var uowGen = new UnitOfWorkGen(dt);",
                @"manager.StartNewFile(""UnitOfWorkGen.cs"");")),
                new TemplateTextBlock("<#=uowGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
