using Newtonsoft.Json;
using PromoterDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.ViewModels
{
    public partial class VoucherViewModel
    {
        [JsonProperty("config", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public VoucherConfig Config { get; set; }
    }
}
