using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class CouponProviderViewModel: BaseViewModel<CouponProvider>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("provider_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProviderName { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; set; }
		[JsonProperty("coupon_campaigns", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CouponCampaignViewModel> CouponCampaignsVM { get; set; }
		
		public CouponProviderViewModel(CouponProvider entity) : this()
		{
			FromEntity(entity);
		}
		
		public CouponProviderViewModel()
		{
			this.CouponCampaignsVM = new HashSet<CouponCampaignViewModel>();
		}
		
	}
}
