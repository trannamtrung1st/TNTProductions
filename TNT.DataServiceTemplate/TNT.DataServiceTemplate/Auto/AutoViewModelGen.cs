using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.DataServiceTemplate.TTGen;
using TNT.TemplateAPI.Generators;
using static TNT.DataServiceTemplate.Helpers.GeneralHelper;

namespace TNT.DataServiceTemplate.Auto
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
                "import namespace=\"TNT.DataServiceTemplate.Data\"",
                "import namespace=\"TNT.DataServiceTemplate.ViewModels\"",
                "import namespace=\"static TNT.DataServiceTemplate.Helpers.GeneralHelper\"");
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
                @"var dt = new EdmxParser(projectPath+@""" + Data.EdmxPath + @""",""`project`"").Data;",
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
                    "manager.StartNewFile(e.EntityName+\"ViewModel.txt\");")),
                new TemplateTextBlock("<#=vmGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen(
                    "}",
                    "manager.Process();")));
        }

    }
}
