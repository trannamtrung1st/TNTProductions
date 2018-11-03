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
	public partial class CouponViewModel: BaseViewModel<Coupon>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("campagin_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CampaginId { get; set; }
		[JsonProperty("serial_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SerialNumber { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("date_use", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateUse { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("coupon_campaign", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CouponCampaignViewModel CouponCampaignVM { get; set; }
		
		public CouponViewModel(Coupon entity) : this()
		{
			FromEntity(entity);
		}
		
		public CouponViewModel()
		{
		}
		
	}
}
