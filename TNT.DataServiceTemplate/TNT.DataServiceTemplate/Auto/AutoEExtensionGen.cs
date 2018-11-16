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
    public class AutoEExtensionGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoEExtensionGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.Models.Extensions\"");
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
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
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
                new TemplateTextBlock("<#=eeGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
