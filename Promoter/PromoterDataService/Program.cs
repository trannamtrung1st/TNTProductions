using Newtonsoft.Json;
using PromoterDataService.Global;
using PromoterDataService.Managers;
using PromoterDataService.Models;
using PromoterDataService.Models.Domains;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Utilities;
using PromoterDataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Auto;
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
            //    JsonPropertyFormatEnum.JsonStyle, true, false, false);
            //autoGen.Generate();
            G.DefaultConfigure();

            using (var u = new PromoterEntities())
            {
                var qew = u.Promotions
                    .SelectOnly(false, "ID", "Code", "Campaign.ID", "PromotionDetail");
            }
        }

        private static void WriteObj<T>(T obj)
        {
            File.WriteAllText(@"T:\TNT\Workspace\TNTProductions\Promoter\PromoterDataService\result.json", JsonConvert.SerializeObject(obj));
        }

    }
}
