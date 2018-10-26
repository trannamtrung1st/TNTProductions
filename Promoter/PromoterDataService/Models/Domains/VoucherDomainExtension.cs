using PromoterDataService.APIs.Enums;
using PromoterDataService.APIs.Messages;
using PromoterDataService.Models.Services;
using PromoterDataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.General;

namespace PromoterDataService.Models.Domains
{
    public partial class VoucherDomain
    {

        public Voucher Add(VoucherViewModel model)
        {
            var trans = UoW.BeginTransaction();
            var vRuleService = UoW.Service<IValidationRuleService>();
            var pDetailService = UoW.Service<IPromotionDetailService>();

            var voucher = model.ToEntity();
            if (voucher.Code == null)
                voucher.Code = GenerateCode(model.Config, new Random());
            if (voucher.ValidationRuleId == null)
            {
                var vRule = vRuleService.Add(model.ValidationRuleVM.ToEntity());
                voucher.ValidationRuleId = vRule.Id;
            }
            if (voucher.PromotionDetailId == null)
            {
                var pDetail = pDetailService.Add(model.PromotionDetailVM.ToEntity());
                voucher.PromotionDetailId = pDetail.Id;
            }
            voucher = BaseService.Add(voucher);
            trans.Commit();
            return voucher;
        }

        public int Add(VoucherViewModel model, int quantity)
        {
            var trans = UoW.BeginTransaction();
            var vRuleService = UoW.Service<IValidationRuleService>();
            var pDetailService = UoW.Service<IPromotionDetailService>();

            if (model.ValidationRuleId == null)
            {
                var vRule = vRuleService.Add(model.ValidationRuleVM.ToEntity());
                model.ValidationRuleId = vRule.Id;
            }
            if (model.PromotionDetailId == null)
            {
                var pDetail = pDetailService.Add(model.PromotionDetailVM.ToEntity());
                model.PromotionDetailId = pDetail.Id;
            }
            var added = 0;
            var notOk = 0;
            var rand = new Random();
            for (int i = 0; i < quantity; i++)
            {
                notOk = 0;
                while (notOk > -1 && notOk < 5)
                {
                    try
                    {
                        var voucher = model.ToEntity();
                        voucher.Code = GenerateCode(model.Config, rand);
                        BaseService.Add(voucher);
                        notOk = -1;
                        added++;
                    }
                    catch (Exception)
                    {
                        notOk++;
                    }
                }
                if (notOk != -1)
                    throw new ErrorMessage(MessageCode.Voucher_TooManyDuplication);
            }
            trans.Commit();
            return added;
        }

        private const char R_UPPER_DIGIT = '*';
        private const char R_DIGIT = '#';
        private const char R_UPPER = '$';
        /// <summary>
        /// *: số hoặc chữ cái in hoa ngẫu nhiên
        /// #: số ngẫu nhiên
        /// $: chữ cái in hoa ngẫu nhiên
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns
        protected string GenerateCode(VoucherConfig config, Random rand)
        {
            var code = "";
            var pattern = config.Pattern;
            if (pattern != null)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    switch (pattern[i])
                    {
                        case R_UPPER_DIGIT:
                            code += rand.NextUpperOrDigit();
                            break;
                        case R_DIGIT:
                            code += rand.NextDigit();
                            break;
                        case R_UPPER:
                            code += rand.NextUpperLetter();
                            break;
                        default:
                            code += pattern[i];
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < config.Length; i++)
                    code += rand.NextUpperOrDigit();
            }
            if (config.Prefix != null)
                code = config.Prefix + code;
            if (config.Postfix != null)
                code += config.Postfix;
            return code;
        }

    }
}
