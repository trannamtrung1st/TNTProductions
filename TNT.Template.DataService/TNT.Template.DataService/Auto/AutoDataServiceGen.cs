using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.Template.DataService.Helpers;
using TNT.TemplateAPI.Generators;
using static TNT.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Template.DataService.Auto
{
    public class AutoDataServiceGen
    {

        private string TemplateAPILib { get; set; }
        private string DataServiceLib { get; set; }
        private string EdmxFile { get; set; }
        private string ProjectName { get; set; }
        private string ProjectPath { get; set; }
        private string SolutionPath { get; set; }
        private JsonPropertyFormatEnum Style { get; set; }
        private DataInfo Data { get; set; }
        private List<string> ExtraDirectives { get; set; }
        private string[] VMJsonIgnoreProps { get; set; } = new string[] { };
        private string[] VMExceptProps { get; set; } = new string[] { };

        //all relative to project: (projectPath/[continue])
        public AutoDataServiceGen(
            string solutionPath,
            string projectPath,
            string projectName,
            string templateApiLib,
            string dataServiceTemplateLib,
            string edmxFile,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool requestScope = false
            )
        {

            SolutionPath = solutionPath;
            if (SolutionPath[SolutionPath.Length - 1] == '\\' || SolutionPath[SolutionPath.Length - 1] == '/')
                SolutionPath = SolutionPath.Remove(SolutionPath.Length - 1);
            SolutionPath += "/";

            ProjectPath = projectPath;
            if (ProjectPath[ProjectPath.Length - 1] == '\\' || ProjectPath[ProjectPath.Length - 1] == '/')
                ProjectPath = ProjectPath.Remove(ProjectPath.Length - 1);
            ProjectPath += "/";

            var curDir = Directory.GetCurrentDirectory() + '/';

            this.Style = vmPropStyle;
            ProjectName = projectName;

            TemplateAPILib = templateApiLib.Replace("{project}", "$(ProjectDir)")
                .Replace("{current}", curDir)
                .Replace("{solution}", "$(SolutionDir)");
            DataServiceLib = dataServiceTemplateLib.Replace("{project}", "$(ProjectDir)")
                .Replace("{current}", curDir)
                .Replace("{solution}", "$(SolutionDir)");
            var includeFile = "$(ProjectDir)Templates/TTManager.ttinclude";
            ExtraDirectives = new List<string>()
            {
                "assembly name=\""+TemplateAPILib+"\"",
                "assembly name=\""+DataServiceLib+"\"",
                "include file=\""+includeFile+"\""
            };

            EdmxFile = edmxFile.Replace("{project}", ProjectPath).Replace("{current}", curDir)
                .Replace("{solution}", SolutionPath);

            Data = new EdmxParser(EdmxFile, projectName).Data;
            Data.EdmxPath = edmxFile;
            Data.RequestScope = requestScope;
            Data.ActiveCol = activeCol;
        }

        public void AddVMExceptProps(params string[] props)
        {
            if (props != null)
                VMExceptProps = props;
        }

        public void AddVMIgnoreProps(params string[] props)
        {
            if (props != null)
                VMJsonIgnoreProps = props;
        }

        public void Generate()
        {
            GenerateTemplateManager();
            GenerateViewModel();
            GenerateGlobal();
            GenerateEntityExtension();
            GenerateRepository();
            GenerateManager();
            GenerateDomain();
            GenerateHelpers();
            GenerateReadmeText();
        }

        private void GenerateHelpers()
        {
            var uGen = new AutoHelpersGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Helpers", "HelpersTemplate.tt", uGen.Generate());
        }

        private void GenerateTemplateManager()
        {
            FileHelper.Write(ProjectPath + "Templates", "TTManager.ttinclude", TemplateManagerGen.Text);
        }

        private void GenerateViewModel()
        {
            var vmGen = new AutoViewModelGen(Data, VMJsonIgnoreProps, Style,
                VMExceptProps, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "ViewModels", "ViewModelTemplate.tt", vmGen.Generate());
        }

        private void GenerateGlobal()
        {
            var gGen = new AutoGlobalGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Global", "GlobalTemplate.tt", gGen.Generate());
        }

        private void GenerateEntityExtension()
        {
            var eGen = new AutoEExtensionGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Models/Extensions", "ExtensionTemplate.tt", eGen.Generate());
        }

        private void GenerateRepository()
        {
            var rGen = new AutoRepositoryGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Models/Repositories", "RepositoryTemplate.tt", rGen.Generate());
        }

        private void GenerateManager()
        {
            var mGen = new AutoManagerGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Managers", "ManagerTemplate.tt", mGen.Generate());
        }

        private void GenerateDomain()
        {
            var dGen = new AutoDomainGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Models/Domains", "DomainTemplate.tt", dGen.Generate());
        }

        private void GenerateReadmeText()
        {
            FileHelper.Write(ProjectPath, "README.txt",
                "NOTES:\r\n" +
                "- Add a config class that will use config methods of G class\r\n" +
                "- Add PreStartApplicationMethod attribute on the class (type: [configClass], method: [configMethod])\r\n" +
                "- UnitOfWork will manage the DbContext, Scope IoC, and Transaction for you \r\n" +
                "  so you don't need to explicit dispose them\r\n" +
                "- To use Request scope (app server required) UnitOfWork: \r\n" +
                "\t+ DO: var uow = G.TContainer.ResolveRequestScope<IUnitOfWork>(); for each work\r\n" +
                "(The uow will dispose in the end of a request)\r\n" +
                "\t+ (Each domain will auto resolve one when initialized)\r\n" +
                "- Normal use of UnitOfWork:\r\n" +
                "\t+ using (var u = G.TContainer.Resolve<IUnitOfWork>([scope]))\r\n" +
                "\t+ using (var u = new UnitOfWork([scope]))\r\n" +
                "- Don't remove the Templates folder (or you won't be able to regenerate files)\r\n" +
                "- Almost classes are partial by default. Extend them if you want\r\n" +
                "HAVE A GOOD PROGRAMMING LIFE <3"
                );
        }

    }
}
