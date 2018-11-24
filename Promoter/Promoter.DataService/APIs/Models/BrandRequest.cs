using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.APIs.Models
{
    public class BrandRequest<T> : BaseRequest<T>
    {
        public int? brand_id;
    }

    public class BrandRequest : BrandRequest<dynamic>
    {
    }
}
