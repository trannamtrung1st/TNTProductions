using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoDomainGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoDomainGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Models.Domains\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateBaseDomain();
            //GenerateEntityDomain();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
                (Data.RequestScope ? "dt.RequestScope = true;" : ""),
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateBaseDomain()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var dGen = new BaseDomainGen(dt);",
                @"manager.StartNewFile(""BaseDomainGen.cs"");")),
                new TemplateTextBlock("<#=dGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "manager.Process();")));
        }

        //private void GenerateEntityDomain()
        //{
        //    Add(new TemplateCodeBlock(new StatementGen(
        //        "foreach (var e in dt.Entities)", "{"),
        //        new StatementGen(true,
        //            "var idGen = new EntityDomainGen(e);",
        //            "manager.StartNewFile(e.EntityName+\"Domain.cs\");")),
        //        new TemplateTextBlock("<#=idGen.Generate()#>"),
        //new TemplateCodeBlock(new StatementGen(
        //            "}",
        //            "manager.Process();")));
        //}

    }
}
