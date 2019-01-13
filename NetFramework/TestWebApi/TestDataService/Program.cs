using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Global;
using TestDataService.Managers;
using TestDataService.Models;
using TestDataService.Models.Services;
using TNT.DataServiceTemplate.Auto;
using TNT.DataServiceTemplate.Helpers;
using TNT.Helpers.Data;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //var autoGen = new AutoDataServiceGen(
            //    @"T:\TNT\Workspace\TNTProductions\TestWebApi\TestDataService",
            //    "TestDataService",
            //    "bin/Debug/TNT.TemplateApi.dll",
            //    "bin/Debug/TNT.DataServiceTemplate.dll",
            //    "Models/TestEntities.edmx",
            //    TNT.DataServiceTemplate.Helpers.GeneralHelper.JsonPropertyFormatEnum.JsonStyle,
            //    false, false, false);
            //autoGen.Generate();

            //FileHelper.ChangeTextToCsFile(
            //    @"T:\TNT\Workspace\TNTProductions\TestWebApi\TestDataService\ViewModels",
            //    @"T:\TNT\Workspace\TNTProductions\TestWebApi\TestDataService\ViewModels");
            G.Configure();
            using (var scope = G.TContainer.CreateScope())
            {
                var db = scope.Resolve<EmployeeManagerEntities>();
                var eService = scope.Resolve<IEmployeeService>(db);
                var test = eService.GetActive().ToList();
            }

        }
    }
}
