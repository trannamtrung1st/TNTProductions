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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("campaginId")]
		public Nullable<int> CampaginId { get; set; }
		[JsonProperty("serialNumber")]
		public string SerialNumber { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("dateUse")]
		public Nullable<DateTime> DateUse { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("couponCampaign")]
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
