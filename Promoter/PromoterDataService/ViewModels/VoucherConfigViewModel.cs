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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("length")]
		public Nullable<int> Length { get; set; }
		[JsonProperty("prefix")]
		public string Prefix { get; set; }
		[JsonProperty("postfix")]
		public string Postfix { get; set; }
		[JsonProperty("pattern")]
		public string Pattern { get; set; }
		[JsonProperty("campaigns")]
		public IEnumerable<CampaignViewModel> CampaignsVM { get; set; }
		[JsonProperty("vouchers")]
		public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
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
