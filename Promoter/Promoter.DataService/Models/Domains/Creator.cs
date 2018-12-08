using Promoter.DataService.Managers;
using Promoter.DataService.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Models.Domains
{
    public class Creator : BaseDomain
    {
        #region Constructor
        public Creator() : base()
        {
        }

        public Creator(IUnitOfWork uow) : base(uow)
        {
        }

        public Creator(PromoterEntities context) : base(context)
        {
        }
        #endregion

        public Promotion CreatePromotion(Promotion promotion)
        {
            var pService = UoW.Service<IPromotionService>();
            promotion = pService.Add(promotion);
            UoW.SaveChanges();
            promotion.PromotionName = null;
            pService.Reload(promotion);
            return promotion;
        }


        public PromotionDetail CreatePromotionDetail(PromotionDetail detail)
        {
            var pDService = UoW.Service<IPromotionDetailService>();
            detail = pDService.Add(detail);
            return detail;
        }

        public PromotionConstraint CreatePromotionConstraint(PromotionConstraint constraint)
        {
            var pCService = UoW.Service<IPromotionConstraintService>();
            constraint = pCService.Add(constraint);
            return constraint;
        }

        public PromotionAwardDiscount CreatePromotionAwardDiscount(PromotionAwardDiscount discount)
        {
            var pADService = UoW.Service<IPromotionAwardDiscountService>();
            discount = pADService.Add(discount);
            return discount;
        }

        public PromotionAwardGift CreatePromotionAwardGift(PromotionAwardGift gift)
        {
            var pAGService = UoW.Service<IPromotionAwardGiftService>();
            gift = pAGService.Add(gift);
            return gift;
        }

        public PromotionAwardCashback CreatePromotionAwardCashback(PromotionAwardCashback cashback)
        {
            var pACService = UoW.Service<IPromotionAwardCashbackService>();
            cashback = pACService.Add(cashback);
            return cashback;
        }

    }
}
