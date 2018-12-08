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
    [RoutePrefix("api/promotion/constraint")]
    public class PromotionConstraintController : ApiController
    {

        [Route("")]
        [HttpPost]
        public HttpResponseMessage CreatePromotionConstraint(PromotionConstraintViewModel pConstraintVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.PromotionConstraint(pConstraintVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var pDetail = creator.CreatePromotionConstraint(pConstraintVM.ToPromotionConstraint());
                return Http.OkBase(pDetail.ToPromotionConstraintViewModel(), AppMessage.From(MessageCode.General_Success));
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
        public static PromotionConstraint ToPromotionConstraint(this PromotionConstraintViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionConstraintViewModel ToPromotionConstraintViewModel(this PromotionConstraint entity)
        {
            return entity.To<PromotionConstraintViewModel>();
        }
    }
}
