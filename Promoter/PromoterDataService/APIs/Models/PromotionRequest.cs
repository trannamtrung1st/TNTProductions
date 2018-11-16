using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Models
{
    public class PromotionRequest<T> : GeneralRequest<T>
    {
        public string Code { get; set; }
    }

    public class PromotionRequest : PromotionRequest<dynamic>
    {
    }
}
