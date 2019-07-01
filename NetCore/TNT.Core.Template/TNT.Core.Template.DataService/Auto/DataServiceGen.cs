using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.DataService.Helpers;
using TNT.Core.Template.DataService.Models;
using TNT.Core.Template.DataService.Models.Domains;
using TNT.Core.Template.Generators;
using static TNT.Core.Template.DataService.Helpers.GeneralHelper;
using Microsoft.EntityFrameworkCore;
using TNT.Core.Template.DataService.ViewModels;
using TNT.Core.Template.DataService.Global;
using TNT.Core.Template.DataService.Models.Extensions;
using TNT.Core.Template.DataService.Models.Repositories;

namespace TNT.Core.Template.DataService.Auto
{
    public class DataServiceGen
    {

        private string ProjectName { get; set; }
        private string ProjectPath { get; set; }
        private string OutputPath { get; set; }

        private JsonPropertyFormatEnum Style { get; set; }
        private ContextInfo Data { get; set; }
        private string[] VMJsonIgnoreProps { get; set; } = new string[] { };
        private string[] VMExceptProps { get; set; } = new string[] { };

        public DataServiceGen(
            DbContext dbContext,
            string projectPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool requestScope = false
            )
        {
            ProjectPath = projectPath;

            if (ProjectPath[ProjectPath.Length - 1] == '\\' || ProjectPath[ProjectPath.Length - 1] == '/')
                ProjectPath = ProjectPath.Remove(ProjectPath.Length - 1);
            ProjectPath += "/";
            OutputPath = ProjectPath;

            var curDir = Directory.GetCurrentDirectory() + '/';

            this.Style = vmPropStyle;
            ProjectName = projectName;

            Data = new ContextParser(dbContext, projectName).Data;
            Data.RequestScope = requestScope;
            Data.ActiveCol = activeCol;
        }

        public DataServiceGen(
            DbContext dbContext,
            string projectPath,
            string outputPath,
            string projectName,
            JsonPropertyFormatEnum vmPropStyle,
            bool activeCol = true,
            bool requestScope = false
            )
        {
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

            Data = new ContextParser(dbContext, projectName).Data;
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
            DeleteOldGeneratedFiles();
            GenerateViewModel();
            GenerateGlobal();
            GenerateEntityExtension();
            GenerateRepository();
            GenerateManager();
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
            var baseVMGen = new BaseVMGen(Data);
            FileHelper.Write(OutputPath + "ViewModels/Gen", "BaseViewModel.Gen.cs", baseVMGen.Generate());

            var wrapperGen = new WrapperGen(Data);
            FileHelper.Write(OutputPath + "ViewModels/Gen", "Wrapper.Gen.cs", wrapperGen.Generate());

            foreach (var e in Data.Entities)
            {
                var vmGen = new VMGen(e, VMJsonIgnoreProps,
                    VMExceptProps, Style);
                FileHelper.Write(OutputPath + "ViewModels/Gen", e.EntityName + "ViewModel.Gen.txt", vmGen.Generate());
            }
        }

        private void GenerateGlobal()
        {
            var gGen = new GlobalGen(Data);
            FileHelper.Write(OutputPath + "Global/Gen", "Global.Gen.cs", gGen.Generate());
        }

        private void GenerateEntityExtension()
        {
            var baseEGen = new EntityGen(Data);
            FileHelper.Write(OutputPath + "Models/Extensions/Gen", "BaseEntity.Gen.cs", baseEGen.Generate());
            foreach (var e in Data.Entities)
            {
                var eGen = new EntityExtensionGen(e);
                FileHelper.Write(OutputPath + "Models/Extensions/Gen", e.EntityName + "Extensions.Gen.cs",
                    eGen.Generate() + "\r\n\r\n" + eGen.ENamespace.Generate());
            }
        }

        private void GenerateRepository()
        {
            var rGen = new RepositoryGen(Data);
            FileHelper.Write(OutputPath + "Models/Repositories/Gen", "BaseRepository.Gen.cs", rGen.Generate());
            foreach (var e in Data.Entities)
            {
                var eRGen = new EntityRepositoryGen(e);
                FileHelper.Write(OutputPath + "Models/Repositories/Gen", e.EntityName + "Repository.Gen.cs", eRGen.Generate());
            }
        }

        private void GenerateManager()
        {
            var uow = new UnitOfWorkGen(Data);
            FileHelper.Write(OutputPath + "Models/Gen", "UnitOfWork.Gen.cs", uow.Generate());
        }

        private void GenerateDomain()
        {
            var dGen = new BaseDomainGen(Data);
            FileHelper.Write(OutputPath + "Models/Domains/Gen", "BaseDomain.Gen.cs", dGen.Generate());
        }

    }
}
