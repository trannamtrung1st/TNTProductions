using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Enums
{
    public enum MessageCode
    {
        General_UnknownError = 0,
        General_Success = 1,
    }

    public enum DiscountUnit
    {
        VND = 0,
        Percent = 1,
    }

    public enum PromotionApplyLevel
    {
        Order = 0,
        Product = 0,
    }

    public enum PromotionApplySituation
    {

    }

    public enum PromotionType
    {
        Discount = 0,
        Gift = 1,
        Cashback = 2
    }

}
