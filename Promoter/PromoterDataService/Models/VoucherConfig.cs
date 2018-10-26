using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.Models
{
    public class VoucherConfig
    {
        [JsonProperty("length")]
        public int? Length { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
        [JsonProperty("postfix")]
        public string Postfix { get; set; }
        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }
}
