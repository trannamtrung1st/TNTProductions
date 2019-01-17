using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.IoC.Wrapper;
using TNT.Template.DataService.Auto;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoGen = new AutoDataServiceGen(
                @"T:\Workspace\TNTProductions\NetFramework\TNT.Template.DataService",
                @"T:\Workspace\TNTProductions\NetFramework\TNT.Template.DataService\TestDataService",
                "TestDataService", "{project}bin/Debug/TNT.TemplateAPI.dll", "{project}bin/Debug/TNT.Template.DataService.dll",
                "{project}Models/AppEntity.edmx", TNT.Template.DataService.Helpers.GeneralHelper.JsonPropertyFormatEnum.CamelCase,
                false, true);
            autoGen.Generate();

        }
    }
}
