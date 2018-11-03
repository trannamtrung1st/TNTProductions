using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class VoucherConfigViewModel: BaseViewModel<VoucherConfig>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("length", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Length { get; set; }
		[JsonProperty("prefix", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Prefix { get; set; }
		[JsonProperty("postfix", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Postfix { get; set; }
		[JsonProperty("pattern", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Pattern { get; set; }
		[JsonProperty("campaigns", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CampaignViewModel> CampaignsVM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public VoucherConfigViewModel(VoucherConfig entity) : this()
		{
			FromEntity(entity);
		}
		
		public VoucherConfigViewModel()
		{
			this.CampaignsVM = new HashSet<CampaignViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
