using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.DataService.MongoDB.Helpers;
using TNT.Core.Template.DataService.MongoDB.Models;
using TNT.Core.Template.DataService.MongoDB.Models.Domains;
using TNT.Core.Template.Generators;
using static TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper;
using TNT.Core.Template.DataService.MongoDB.ViewModels;
using TNT.Core.Template.DataService.MongoDB.Models.Extensions;
using TNT.Core.Template.DataService.MongoDB.Models.Repositories;
using TNT.Core.Template.DataService.MongoDB.Global;

namespace TNT.Core.Template.DataService.MongoDB.Auto
{
    public class DataServiceGen
    {

        private string ProjectName { get; set; }
        private string ProjectPath { get; set; }
        private string OutputPath { get; set; }
        private string TempEFolder { get; set; }

        private JsonPropertyFormatEnum Style { get; set; }
        private Info Info { get; set; }
        private string[] VMJsonIgnoreProps { get; set; } = new string[] { };
        private string[] VMExceptProps { get; set; } = new string[] { };

        public DataServiceGen(
            IEnumerable<Type> entities,
            string tempEntitiesFolder,
            string projectPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle)
        {
            TempEFolder = tempEntitiesFolder;
            ProjectPath = projectPath;
            if (ProjectPath[ProjectPath.Length - 1] == '\\' || ProjectPath[ProjectPath.Length - 1] == '/')
                ProjectPath = ProjectPath.Remove(ProjectPath.Length - 1);
            ProjectPath += "/";
            OutputPath = ProjectPath;
            var curDir = Directory.GetCurrentDirectory() + '/';
            this.Style = vmPropStyle;
            ProjectName = projectName;
            Info = new InfoParser(entities, projectName).Info;
        }

        public DataServiceGen(
            IEnumerable<Type> entities,
            string tempEntitiesFolder,
            string projectPath,
            string outputPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle
            )
        {
            TempEFolder = tempEntitiesFolder;
            ProjectPath = projectPath;
            if (ProjectPath[ProjectPath.Length - 1] == '\\' || ProjectPath[ProjectPath.Length - 1] == '/')
                ProjectPath = ProjectPath.Remove(ProjectPath.Length - 1);
            ProjectPath += "/";
            OutputPath = outputPath;
            if (OutputPath[OutputPath.Length - 1] == '\\' || OutputPath[OutputPath.Length - 1] == '/')
                OutputPath = OutputPath.Remove(OutputPath.Length - 1);
            OutputPath += "/";
            var curDir = Directory.GetCurrentDirectory() + '/';
            this.Style = vmPropStyle;
            ProjectName = projectName;
            Info = new InfoParser(entities, projectName).Info;
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
            EntitiesGen.CopyEntities(TempEFolder, OutputPath + "Models", Info);
            DeleteOldGeneratedFiles();
            GenerateViewModel();
            GenerateGlobal();
            GenerateEntityExtension();
            GenerateRepository();
            GenerateConfigs();
            GenerateDomain();
        }

        private void DeleteOldGeneratedFiles()
        {
            if (!ProjectPath.Equals(OutputPath))
                FileHelper.DeleteDataServiceStructure(ProjectPath);
            FileHelper.DeleteDataServiceStructure(OutputPath);
        }

        private void GenerateViewModel()
        {
            var baseVMGen = new BaseVMGen(Info);
            FileHelper.Write(OutputPath + "ViewModels/Gen", "BaseViewModel.Gen.cs", baseVMGen.Generate());

            foreach (var e in Info.Entities)
            {
                var vmGen = new VMGen(e, VMJsonIgnoreProps,
                    VMExceptProps, Style);
                FileHelper.Write(OutputPath + "ViewModels/Gen", e.EntityName + "ViewModel.Gen.txt", vmGen.Generate());
            }
        }

        private void GenerateConfigs()
        {
            var cGen = new MongoDbSettingsGen(Info);
            FileHelper.Write(OutputPath + "Models/Configs/Gen", "MongoDbSettings.Gen.cs", cGen.Generate());
        }

        private void GenerateGlobal()
        {
            var gGen = new GlobalGen(Info);
            FileHelper.Write(OutputPath + "Global/Gen", "Global.Gen.cs", gGen.Generate());
        }

        private void GenerateEntityExtension()
        {
            var baseEGen = new BaseEntityGen(Info);
            FileHelper.Write(OutputPath + "Models/Gen", "BaseEntity.Gen.cs", baseEGen.Generate());
            foreach (var e in Info.Entities)
            {
                var eGen = new EntityExtensionGen(e);
                FileHelper.Write(OutputPath + "Models/Extensions/Gen", e.EntityName + "Extensions.Gen.cs",
                    eGen.Generate() + "\r\n\r\n" + eGen.ENamespace.Generate());
            }
        }

        private void GenerateRepository()
        {
            var rGen = new RepositoryGen(Info);
            FileHelper.Write(OutputPath + "Models/Repositories/Gen", "BaseRepository.Gen.cs", rGen.Generate());
            foreach (var e in Info.Entities)
            {
                var eRGen = new EntityRepositoryGen(e);
                FileHelper.Write(OutputPath + "Models/Repositories/Gen", e.EntityName + "Repository.Gen.cs", eRGen.Generate());
            }
        }

        private void GenerateDomain()
        {
            var dGen = new BaseDomainGen(Info);
            FileHelper.Write(OutputPath + "Models/Domains/Gen", "BaseDomain.Gen.cs", dGen.Generate());
        }

    }
}
