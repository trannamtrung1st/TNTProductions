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
	public partial class PromotionViewModel: BaseViewModel<Promotion>
	{
		[JsonProperty("promotion_id")]
		public int PromotionID { get; set; }
		[JsonProperty("promotion_code")]
		public string PromotionCode { get; set; }
		[JsonProperty("promotion_name")]
		public string PromotionName { get; set; }
		[JsonProperty("promotion_class_name")]
		public string PromotionClassName { get; set; }
		[JsonProperty("short_description")]
		public string ShortDescription { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("image_css")]
		public string ImageCss { get; set; }
		[JsonProperty("apply_level")]
		public int ApplyLevel { get; set; }
		[JsonProperty("gift_type")]
		public int GiftType { get; set; }
		[JsonProperty("is_for_member")]
		public bool IsForMember { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("from_date")]
		public DateTime FromDate { get; set; }
		[JsonProperty("to_date")]
		public DateTime ToDate { get; set; }
		[JsonProperty("apply_from_time")]
		public Nullable<int> ApplyFromTime { get; set; }
		[JsonProperty("apply_to_time")]
		public Nullable<int> ApplyToTime { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("is_voucher")]
		public Nullable<bool> IsVoucher { get; set; }
		[JsonProperty("is_apply_once")]
		public Nullable<bool> IsApplyOnce { get; set; }
		[JsonProperty("voucher_quantity")]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucher_used_quantity")]
		public Nullable<int> VoucherUsedQuantity { get; set; }
		[JsonProperty("promotion_type")]
		public int PromotionType { get; set; }
		[JsonProperty("from_happy_day")]
		public Nullable<int> FromHappyDay { get; set; }
		[JsonProperty("to_happy_day")]
		public Nullable<int> ToHappyDay { get; set; }
		[JsonProperty("from_hours_happy")]
		public Nullable<int> FromHoursHappy { get; set; }
		[JsonProperty("to_hours_happy")]
		public Nullable<int> ToHoursHappy { get; set; }
		[JsonProperty("using_point")]
		public Nullable<bool> UsingPoint { get; set; }
		[JsonProperty("apply_to_partner")]
		public Nullable<int> ApplyToPartner { get; set; }
		//[JsonProperty("order_detail_promotion_mappings")]
		//public IEnumerable<OrderDetailPromotionMappingViewModel> OrderDetailPromotionMappingsVM { get; set; }
		//[JsonProperty("order_promotion_mappings")]
		//public IEnumerable<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		//[JsonProperty("promotion_store_mappings")]
		//public IEnumerable<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		//[JsonProperty("vouchers")]
		//public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
		public PromotionViewModel(Promotion entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionViewModel()
		{
			//this.OrderDetailPromotionMappingsVM = new HashSet<OrderDetailPromotionMappingViewModel>();
			//this.OrderPromotionMappingsVM = new HashSet<OrderPromotionMappingViewModel>();
			//this.PromotionStoreMappingsVM = new HashSet<PromotionStoreMappingViewModel>();
			//this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
