using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Models
{
    public class ValidationRequest<T> : GeneralRequest<T>
    {
        public int? ID { get; set; }
    }

    public class ValidationRequest : ValidationRequest<dynamic>
    {
    }
}
