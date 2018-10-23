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
    public class AutoRepositoryGen : TemplateGen
    {

        private DataInfo Data { get; set; }
        public AutoRepositoryGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.Models.Repositories\"");
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
                "var activeCol = " + (Data.ActiveCol ? "true" : "false") + ";",
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"", activeCol).Data;",
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateBaseViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var baseRepo = new RepositoryGen(dt);",
                @"manager.StartNewFile(""BaseRepository.cs"");")),
                new TemplateTextBlock("<#=baseRepo.Generate()#>"));
        }

        private void GenerateEntityViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "foreach (var e in dt.Entities)", "{"),
                new StatementGen(true,
                    "var rGen = new EntityRepositoryGen(e);",
                    "manager.StartNewFile(e.EntityName+\"Repository.cs\");")),
                new TemplateTextBlock("<#=rGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
