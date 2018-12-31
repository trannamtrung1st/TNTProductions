using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoEExtensionGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoEExtensionGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Models.Extensions\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateIEntity();
            GenerateEExtension();
        }

        private void GenerateInitManager()
        {
            var init = new TemplateCodeBlock(new StatementGen(
                @"var projectPath = Host.ResolveAssemblyReference(""$(ProjectDir)"");",
                @"var solutionPath = Host.ResolveAssemblyReference(""$(SolutionDir)"");",
                @"var dt = new EdmxParser(@""" + Data.EdmxPath + @""".Replace(""{project}"", projectPath).Replace(""{solution}"", solutionPath) ,""`project`"").Data;",
                "var manager = TemplateFileManager.Create(this);"
                ));
            Add(init);
        }

        private void GenerateIEntity()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var eGen = new EntityGen(dt);",
                @"manager.StartNewFile(""EntityGen.cs"");")),
                new TemplateTextBlock("<#=eGen.Generate()#>"));
        }

        private void GenerateEExtension()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "foreach (var e in dt.Entities)", "{"),
                new StatementGen(true,
                    "var eeGen = new EntityExtensionGen(e);",
                    "manager.StartNewFile(e.EntityName+\"ExtensionGen.cs\");")),
                new TemplateTextBlock("<#=eeGen.Generate()\r\n#>"),
                new TemplateTextBlock("<#=eeGen.ENamespace.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
