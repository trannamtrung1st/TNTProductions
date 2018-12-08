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
    [RoutePrefix("api/promotion/award")]
    public class PromotionAwardController : ApiController
    {
        [Route("discount")]
        public HttpResponseMessage CreateDiscountAward(PromotionAwardDiscountViewModel pDiscountVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.PromotionAwardDiscount(pDiscountVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var pDetail = creator.CreatePromotionAwardDiscount(pDiscountVM.ToPromotionAwardDiscount());
                return Http.OkBase(pDetail.ToPromotionAwardDiscountViewModel(), AppMessage.From(MessageCode.General_Success));
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

        [Route("gift")]
        public HttpResponseMessage CreateGiftAward(PromotionAwardGiftViewModel pGiftVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.PromotionAwardGift(pGiftVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var pDetail = creator.CreatePromotionAwardGift(pGiftVM.ToPromotionAwardGift());
                return Http.OkBase(pDetail.ToPromotionAwardGiftViewModel(), AppMessage.From(MessageCode.General_Success));
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

        [Route("cashback")]
        public HttpResponseMessage CreateCashbackAward(PromotionAwardCashbackViewModel pCashbackVM)
        {
            try
            {
                var validator = new Validator();
                var validateResult = validator.PromotionAwardCashback(pCashbackVM);
                if (!validateResult.IsValid)
                    return Http.BadRequestBase(
                        AppMessage.From(MessageCode.Validation_NotValid, validateResult));

                var creator = new Creator();
                var pDetail = creator.CreatePromotionAwardCashback(pCashbackVM.ToPromotionAwardCashback());
                return Http.OkBase(pDetail.ToPromotionAwardCashbackViewModel(), AppMessage.From(MessageCode.General_Success));
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
        public static PromotionAwardDiscount ToPromotionAwardDiscount(this PromotionAwardDiscountViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionAwardDiscountViewModel ToPromotionAwardDiscountViewModel(this PromotionAwardDiscount entity)
        {
            return entity.To<PromotionAwardDiscountViewModel>();
        }

        public static PromotionAwardGift ToPromotionAwardGift(this PromotionAwardGiftViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionAwardGiftViewModel ToPromotionAwardGiftViewModel(this PromotionAwardGift entity)
        {
            return entity.To<PromotionAwardGiftViewModel>();
        }

        public static PromotionAwardCashback ToPromotionAwardCashback(this PromotionAwardCashbackViewModel vm)
        {
            return vm.ToEntity();
        }

        public static PromotionAwardCashbackViewModel ToPromotionAwardCashbackViewModel(this PromotionAwardCashback entity)
        {
            return entity.To<PromotionAwardCashbackViewModel>();
        }
    }
}
