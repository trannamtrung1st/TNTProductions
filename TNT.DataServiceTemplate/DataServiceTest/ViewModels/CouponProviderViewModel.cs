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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("providerName")]
		public string ProviderName { get; set; }
		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
		[JsonProperty("couponCampaigns")]
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
