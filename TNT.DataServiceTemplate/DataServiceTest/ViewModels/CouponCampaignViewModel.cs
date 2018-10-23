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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("startDate")]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("endDate")]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("price")]
		public decimal Price { get; set; }
		[JsonProperty("value")]
		public decimal Value { get; set; }
		[JsonProperty("providerId")]
		public Nullable<int> ProviderId { get; set; }
		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("couponProvider")]
		public CouponProviderViewModel CouponProviderVM { get; set; }
		[JsonProperty("coupons")]
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
