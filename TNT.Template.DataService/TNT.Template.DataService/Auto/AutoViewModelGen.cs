using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;
using static TNT.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Template.DataService.Auto
{
    public class AutoViewModelGen : TemplateGen
    {

        private DataInfo Data { get; set; }
        private string[] JsonIgnoreProps { get; set; }
        private string[] ExceptProps { get; set; }
        private JsonPropertyFormatEnum Style { get; set; }
        public AutoViewModelGen(DataInfo dt, string[] jsonIgnoreProps, JsonPropertyFormatEnum style,
            string[] exceptProps, params string[] addedDirectives) : base(addedDirectives)
        {
            Style = style;
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.ViewModels\"",
                "import namespace=\"static TNT.Template.DataService.Helpers.GeneralHelper\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);
            JsonIgnoreProps = jsonIgnoreProps;
            ExceptProps = exceptProps;

            GenerateInitManager();
            GenerateBaseViewModel();
            GenerateEntityViewModel();
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

        private void GenerateBaseViewModel()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var baseVM = new BaseVMGen(dt);",
                @"manager.StartNewFile(""BaseViewModelGen.cs"");")),
                new TemplateTextBlock("<#=baseVM.Generate()#>"));
        }

        private void GenerateEntityViewModel()
        {
            var jIgnoreArr = new StatementGen();
            jIgnoreArr.Add("var jIgnore = new string[]", "{");
            foreach (var p in JsonIgnoreProps)
            {
                jIgnoreArr.Add("\t\"" + p + "\",");
            }
            jIgnoreArr.Add("};");

            var exceptArr = new StatementGen();
            exceptArr.Add("var except = new string[]", "{");
            foreach (var p in ExceptProps)
            {
                exceptArr.Add("\t\"" + p + "\",");
            }
            exceptArr.Add("};");

            Add(new TemplateCodeBlock(jIgnoreArr, exceptArr, new StatementGen(
                "foreach (var e in dt.Entities)", "{"),
                new StatementGen(true,
                    "var vmGen = new VMGen(e, jIgnore, except, JsonPropertyFormatEnum."
                        + Enum.GetName(typeof(JsonPropertyFormatEnum), Style) + ");",
                    "manager.StartNewFile(e.EntityName+\"ViewModelGen.cs\");")),
                new TemplateTextBlock("<#=vmGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
