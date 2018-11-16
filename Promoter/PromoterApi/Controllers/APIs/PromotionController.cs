using PromoterDataService.APIs.Messages;
using PromoterDataService.APIs.Models;
using PromoterDataService.Models;
using PromoterDataService.Models.Domains;
using PromoterDataService.Utilities;
using PromoterDataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace PromoterApi.Controllers.APIs
{
    [RoutePrefix("api/promotion")]
    public class PromotionController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get([FromUri]PromotionRequest req)
        {
            try
            {
                var iDomain = new InformationDomain();
                var promotion = iDomain.GetPromotion(req);
                var promotionVM = MapToPromotionViewModel(promotion.ToList());
                return Http.OkBase(promotionVM, Message.Success);
            }
            catch (ErrorMessage e)
            {
                return Http.ErrorBase(null, Message.GetError(e));
            }
            catch (Exception e)
            {
                return Http.ErrorBase(null, Message.GetError(e));
            }
        }

        #region Mapping
        private IEnumerable<PromotionViewModel> MapToPromotionViewModel(IEnumerable<Promotion> entityList)
        {
            if (entityList == null)
                return null;
            var vmList = new List<PromotionViewModel>();
            foreach (var e in entityList)
            {
                var promotionVM = e.To<PromotionViewModel>();
                promotionVM.PromotionDetailVM = MapToPromotionDetailViewModel(e.PromotionDetail);
                promotionVM.ValidationRuleVM = e.ValidationRule != null ? e.ValidationRule.To<ValidationRuleViewModel>() : null;
                promotionVM.PromotionAppliedDetailsVM = e.PromotionAppliedDetails.ToListVM<PromotionAppliedDetail, PromotionAppliedDetailViewModel>();
                vmList.Add(promotionVM);
            }
            return vmList;
        }

        private PromotionDetailViewModel MapToPromotionDetailViewModel(PromotionDetail entity)
        {
            if (entity == null)
                return null;
            var pDetailVM = entity.To<PromotionDetailViewModel>();
            var listGiftDetailVM = new List<GiftDetailViewModel>();
            foreach (var gD in entity.GiftDetails)
            {
                var gDetailVM = gD.To<GiftDetailViewModel>();
                GiftDetailViewModel tmpGDVM = gD.GiftDetail1 != null ? gD.GiftDetail1.To<GiftDetailViewModel>() : null;
                gDetailVM.AndDetailVM = tmpGDVM;
                var tmpGD = gD.GiftDetail1;
                while (tmpGD.GiftDetail1 != null)
                {
                    tmpGDVM.AndDetailVM = tmpGD.GiftDetail1.To<GiftDetailViewModel>();
                    tmpGDVM = tmpGDVM.AndDetailVM;
                    tmpGD = tmpGD.GiftDetail1;
                }
                listGiftDetailVM.Add(gDetailVM);
            }
            pDetailVM.GiftDetailsVM = listGiftDetailVM;

            var situationList = new List<int>();
            foreach (var s in entity.PromotionApplySituations)
            {
                situationList.Add(s.ApplySituation);
            }
            pDetailVM.ApplySituations = situationList;

            var typeList = new List<int>();
            foreach (var t in entity.PromotionTypes)
            {
                typeList.Add(t.Type);
            }
            pDetailVM.PromotionTypes = typeList;

            pDetailVM.CustomerCashbackDetailsVM = entity.CustomerCashbackDetails.ToListVM<CustomerCashbackDetail, CustomerCashbackDetailViewModel>();
            pDetailVM.AffliatorCashbackDetailsVM = entity.AffliatorCashbackDetails.ToListVM<AffliatorCashbackDetail, AffliatorCashbackDetailViewModel>();

            return pDetailVM;
        }
        #endregion
    }
}
