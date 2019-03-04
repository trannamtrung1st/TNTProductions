using DataService.Models;
using System;
using TNT.Core.Template.DataService;
using TNT.Core.Template.DataService.Helpers;

namespace DataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeneralHelper.ExecuteScaffoldFromCmd(
            //    @"T:\Workspace\TNTProductions\NetCore\TestCore\DataService",
            //    "localhost", "FushariEx", "sa", "123456", "Models", "FushariContext");

            using (var context = new FushariContext())
            {
                var gen = context.GetDataServiceGenerator(
                    @"T:\Workspace\TNTProductions\NetCore\TestCore\DataService",
                    "DataService", GeneralHelper.JsonPropertyFormatEnum.JsonStyle,
                    TNT.Core.Template.DataService.Data.DIContainer.ServiceProvider, true, true);
                gen.Generate();
            }
        }
    }
}
