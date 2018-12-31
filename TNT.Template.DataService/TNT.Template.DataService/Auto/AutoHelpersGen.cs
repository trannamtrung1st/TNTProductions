﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Auto
{
    public class AutoHelpersGen : TemplateGen
    {
        private DataInfo Data { get; set; }
        public AutoHelpersGen(DataInfo dt, params string[] addedDirectives) : base(addedDirectives)
        {
            Data = dt;
            AddDirectives(
                "import namespace=\"TNT.Template.DataService.Data\"",
                "import namespace=\"TNT.Template.DataService.Helpers\"");
            ResolveMapping.Add("project", dt.ProjectName);
            ResolveMapping.Add("context", dt.ContextName);

            GenerateInitManager();
            GenerateDefaultHelpers();
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

        private void GenerateDefaultHelpers()
        {
            Add(new TemplateCodeBlock(new StatementGen(
                "var uGen = new HelpersGen(dt);",
                @"manager.StartNewFile(""GeneralHelpersGen.cs"");")),
                new TemplateTextBlock("<#=uGen.Generate()#>"),
                new TemplateCodeBlock(new StatementGen("manager.Process();")));
        }

    }
}
