using PromoterDataService.APIs.Models;
using PromoterDataService.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.Models.Domains
{
    public interface IInformationDomain
    {
        IEnumerable<Campaign> GetCampaign();
        IEnumerable<Promotion> GetPromotion(PromotionRequest req);
        IEnumerable<ValidationRule> GetValidationRule(ValidationRequest req);

    }

    public class InformationDomain : BaseDomain, IInformationDomain
    {
        public IEnumerable<Campaign> GetCampaign()
        {
            var cService = UoW.Service<ICampaignService>();
            return cService.GetActive();
        }

        public IEnumerable<Promotion> GetPromotion(PromotionRequest req)
        {
            var pService = UoW.Service<IPromotionService>();
            var promotions = pService.GetActive();
            if (req.Code != null)
                promotions = promotions.Where(p => p.Code == req.Code);
            return promotions;
        }

        public IEnumerable<ValidationRule> GetValidationRule(ValidationRequest req)
        {
            var vService = UoW.Service<IValidationRuleService>();
            var vRule = vService.GetActive();
            if (req.ID != null)
                vRule = vRule.Where(v => v.ID == req.ID);
            return vRule;
        }
    }
}
