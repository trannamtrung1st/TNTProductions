using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.APIs.Models
{
    public abstract class GeneralRequest<T>
    {
        T Data { get; set; }
    }
}
