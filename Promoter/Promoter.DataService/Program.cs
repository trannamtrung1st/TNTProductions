using Newtonsoft.Json;
using Promoter.DataService.Global;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Domains;
using Promoter.DataService.Models.Services;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.General;
using TNT.Template.DataService.Auto;
using TNT.Template.DataService.Helpers;

namespace Promoter.DataService
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoGen = new AutoDataServiceGen(
                @"T:\TNT\Workspace\TNTProductions\Promoter\Promoter.DataService",
                "Promoter.DataService",
                "bin/Debug/TNT.TemplateAPI.dll",
                "bin/Debug/TNT.Template.DataService.dll",
                "Models/PromoterEntities.edmx",
                GeneralHelper.JsonPropertyFormatEnum.JsonStyle, true, false, true);
            autoGen.Generate();
            //FileHelper.ChangeTextToCsFile(
            //    @"T:\TNT\Workspace\TNTProductions\Promoter\Promoter.DataService\ViewModels",
            //    @"T:\TNT\Workspace\TNTProductions\Promoter\Promoter.DataService\ViewModels");

            G.Configure();
            var sw = Stopwatch.StartNew();
            using (var scope = G.TContainer.CreateScope())
            {
                var uow = scope.Resolve<IUnitOfWork>(scope);
                var creator = new Creator(uow);
                creator.CreatePromotion(new Models.Promotion()
                {
                    Active = true,
                    PromotionCode = "ASD12512",
                    PromotionName = "TNADS)232"
                });

                var pService = uow.Service<IPromotionService>();
                var test = pService.GetActive().ToList();
                //var pConstraint = new PromotionConstraintViewModel()
                //{
                //    HasCollectionConstraint = true,
                //    HasMembershipConstraint = true,
                //    HasOrderConstraint = true,
                //    HasPaymentConstraint = true,
                //    HasSaleModeConstraint = true,
                //    HasStoreConstraint = true,
                //    HasTimeContraint = true,
                //    MinJoinDate = -1,
                //    PaymentType = 5,
                //    MinPersonCount = 0,
                //};
                //var validator = new Validator(uow);
                //var valid = validator.PromotionConstraint(pConstraint);
                ////File.WriteAllText("T:/test.json", JsonConvert.SerializeObject(valid), Encoding.UTF8);
            }
        }

    }
}
