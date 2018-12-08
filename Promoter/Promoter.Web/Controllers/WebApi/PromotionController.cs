using Promoter.DataService.Enums;
using Promoter.DataService.Models;
using Promoter.DataService.Models.Domains;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace Promoter.Web.Controllers.WebApi
{
    [RoutePrefix("api/promotion")]
    public class PromotionController : ApiController
    {

        [Route("")]
        [HttpPost]
        public HttpResponseMessage CreatePromotion(PromotionViewModel promotionVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.Promotion(promotionVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var promo = creator.CreatePromotion(promotionVM.ToPromotion());
                return Http.OkBase(promo.ToPromotionViewModel(), AppMessage.From(MessageCode.General_Success));
            }
            catch (AppErrorMessage mess)
            {
                return Http.ErrorBase(AppMessage.From(mess));
            }
            catch (Exception e)
            {
                return Http.ErrorBase(AppMessage.From(e));
            }
        }

    }

    public static partial class Mapping
    {
        public static Promotion ToPromotion(this PromotionViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionViewModel ToPromotionViewModel(this Promotion entity)
        {
            return entity.To<PromotionViewModel>();
        }
    }
}
