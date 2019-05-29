using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TNT.Core.Template.DataService;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.DataService.Helpers;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileHelper.ChangeTextToCsFile(
            //    @"t:\workspace\tntproductions\netcore\tnt.core.template\testdataservice\viewmodels\text",
            //    @"t:\workspace\tntproductions\netCore\TNT.Core.Template\TestDataService\ViewModels\", ".Gen");
            //FileHelper.DeleteDataServiceStructure(@"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService");
            //GeneralHelper.ExecuteScaffoldFromCmd(
            //    @"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService",
            //    "localhost", "FlashCardDev", "sa", "123456", "Models/Entities", "DataContext");
            //using (var dbContext = new DataContext())
            //{
            //    var generator = dbContext.GetDataServiceGenerator(
            //        @"T:\Workspace\TNTProductions\NetCore\TNT.Core.Template\TestDataService",
            //        "TestDataService",
            //        GeneralHelper.JsonPropertyFormatEnum.CamelCase,
            //        DIContainer.TContainer, true, true);
            //    generator.Generate();
            //}
        }

    }
}
