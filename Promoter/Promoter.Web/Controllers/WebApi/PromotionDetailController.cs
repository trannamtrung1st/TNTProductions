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
    [RoutePrefix("api/promotion/detail")]
    public class PromotionDetailController : ApiController
    {

        [Route("")]
        [HttpPost]
        public HttpResponseMessage CreatePromotionDetail(PromotionDetailViewModel pDetailVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.PromotionDetail(pDetailVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var pDetail = creator.CreatePromotionDetail(pDetailVM.ToPromotionDetail());
                return Http.OkBase(pDetail.ToPromotionDetailViewModel(), AppMessage.From(MessageCode.General_Success));
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
        public static PromotionDetail ToPromotionDetail(this PromotionDetailViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionDetailViewModel ToPromotionDetailViewModel(this PromotionDetail entity)
        {
            return entity.To<PromotionDetailViewModel>();
        }
    }
}
