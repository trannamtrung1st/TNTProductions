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
    public class AutoManagerGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoManagerGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.Managers\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            //GenrateContextManager();
            GenerateUnitOfWork();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
                (Data.ServicePool ? "dt.ServicePool = true;" : "") + (Data.RequestScope ? "dt.RequestScope = true;" : ""),
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        //private void GenrateContextManager()
        //{
        //    Add(new TemplateCodeBlock(new StatementGen(
        //        "var cGen = new ContextManagerGen(dt);",
        //        @"manager.StartNewFile(""ContextManagerGen.cs"");")),
        //        new TemplateTextBlock("<#=cGen.Generate()#>"));
        //}

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
