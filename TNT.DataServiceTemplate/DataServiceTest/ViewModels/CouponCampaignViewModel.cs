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
	public partial class CouponCampaignViewModel: BaseViewModel<CouponCampaign>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("end_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal Price { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal Value { get; set; }
		[JsonProperty("provider_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProviderId { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("coupon_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CouponProviderViewModel CouponProviderVM { get; set; }
		[JsonProperty("coupons", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CouponViewModel> CouponsVM { get; set; }
		
		public CouponCampaignViewModel(CouponCampaign entity) : this()
		{
			FromEntity(entity);
		}
		
		public CouponCampaignViewModel()
		{
			this.CouponsVM = new HashSet<CouponViewModel>();
		}
		
	}
}
