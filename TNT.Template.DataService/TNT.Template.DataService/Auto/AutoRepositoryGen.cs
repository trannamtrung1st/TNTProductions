using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoRepositoryGen : TemplateGen
    {

        private DataInfo Data { get; set; }
        public AutoRepositoryGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Models.Repositories\"");
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
                @"var solutionPath = Host.ResolveAssemblyReference(""$(SolutionDir)"");",
                "var activeCol = " + (Data.ActiveCol ? "true" : "false") + ";",
                @"var dt = new EdmxParser(@""" + Data.EdmxPath + @""".Replace(""{project}"", projectPath).Replace(""{solution}"", solutionPath) ,""`project`"", activeCol).Data;",
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateBaseViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var baseRepo = new RepositoryGen(dt);",
                @"manager.StartNewFile(""BaseRepositoryGen.cs"");")),
                new TemplateTextBlock("<#=baseRepo.Generate()#>"));
        }

        private void GenerateEntityViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "foreach (var e in dt.Entities)", "{"),
                new StatementGen(true,
                    "var rGen = new EntityRepositoryGen(e);",
                    "manager.StartNewFile(e.EntityName+\"RepositoryGen.cs\");")),
                new TemplateTextBlock("<#=rGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
