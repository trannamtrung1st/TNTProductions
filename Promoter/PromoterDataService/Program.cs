using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Auto;
using TNT.DataServiceTemplate.Helpers;
using TNT.Helpers.Data;
using static TNT.DataServiceTemplate.Helpers.GeneralHelper;

namespace PromoterDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //var autoGen = new AutoDataServiceGen(
            //    @"T:\TNT\Workspace\TNTProductions\Promoter\PromoterDataService",
            //    "PromoterDataService",
            //    "bin/Debug/TNT.TemplateAPI.dll",
            //    "bin/Debug/TNT.DataServiceTemplate.dll",
            //    "Models/PromoterDB.edmx",
            //    JsonPropertyFormatEnum.JsonStyle, true, false, true);
            //autoGen.Generate();

            FileHelper.ChangeTextToCsFile(@"T:\TNT\Workspace\TNTProductions\Promoter\PromoterDataService\ViewModels",
                @"T:\TNT\Workspace\TNTProductions\Promoter\PromoterDataService\ViewModels");

        }

        private static void WriteObj<T>(T obj)
        {
            File.WriteAllText(@"T:\TNT\Workspace\TNTProductions\Promoter\PromoterDataService\result.json", JsonConvert.SerializeObject(obj));
        }

    }
}
