using System;
using System.Collections.Generic;
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
        private JsonPropertyFormatEnum Style { get; set; }
        private DataInfo Data { get; set; }
        private List<string> ExtraDirectives { get; set; }
        private string[] VMJsonIgnoreProps { get; set; } = new string[] { };
        private string[] VMExceptProps { get; set; } = new string[] { };

        //all relative to project: (projectPath/[continue])
        public AutoDataServiceGen(
            string projectPath,
            string projectName,
            string templateApiLib,
            string dataServiceTemplateLib,
            string edmxFile,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool servicePool = false,
            bool requestScope = false
            )
        {
            ProjectPath = projectPath;
            if (ProjectPath[ProjectPath.Length - 1] == '\\' || ProjectPath[ProjectPath.Length - 1] == '/')
                ProjectPath = ProjectPath.Remove(ProjectPath.Length - 1);
            ProjectPath += "/";
            this.Style = vmPropStyle;
            ProjectName = projectName;

            TemplateAPILib = "$(ProjectDir)" + templateApiLib;
            DataServiceLib = "$(ProjectDir)" + dataServiceTemplateLib;
            var includeFile = "$(ProjectDir)" + "Templates/TTManager.ttinclude";
            ExtraDirectives = new List<string>()
            {
                "assembly name=\""+TemplateAPILib+"\"",
                "assembly name=\""+DataServiceLib+"\"",
                "include file=\""+includeFile+"\""
            };

            EdmxFile = ProjectPath + edmxFile;
            Data = new EdmxParser(EdmxFile, projectName).Data;
            Data.EdmxPath = edmxFile;
            Data.ServicePool = servicePool;
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
            GenerateService();
            GenerateManager();
            GenerateDomain();
            GenerateUtility();
            GenerateReadmeText();
        }

        private void GenerateUtility()
        {
            var uGen = new AutoUtilityGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Utilities", "UtilityTemplate.tt", uGen.Generate());
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

        private void GenerateService()
        {
            var sGen = new AutoServiceGen(Data, ExtraDirectives.ToArray());
            FileHelper.Write(ProjectPath + "Models/Services", "ServiceTemplate.tt", sGen.Generate());
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
                "- UnitOfWork will manage the DbContext, Scope IoContainer, and Transaction for you \r\n" +
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
