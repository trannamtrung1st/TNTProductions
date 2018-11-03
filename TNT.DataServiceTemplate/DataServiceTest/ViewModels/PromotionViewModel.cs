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
		[JsonProperty("promotion_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionID { get; set; }
		[JsonProperty("promotion_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionCode { get; set; }
		[JsonProperty("promotion_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionName { get; set; }
		[JsonProperty("promotion_class_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionClassName { get; set; }
		[JsonProperty("short_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ShortDescription { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("image_css", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageCss { get; set; }
		[JsonProperty("apply_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ApplyLevel { get; set; }
		[JsonProperty("gift_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int GiftType { get; set; }
		[JsonProperty("is_for_member", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsForMember { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime FromDate { get; set; }
		[JsonProperty("to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ToDate { get; set; }
		[JsonProperty("apply_from_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ApplyFromTime { get; set; }
		[JsonProperty("apply_to_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ApplyToTime { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("is_voucher", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsVoucher { get; set; }
		[JsonProperty("is_apply_once", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsApplyOnce { get; set; }
		[JsonProperty("voucher_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucher_used_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherUsedQuantity { get; set; }
		[JsonProperty("promotion_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionType { get; set; }
		[JsonProperty("from_happy_day", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FromHappyDay { get; set; }
		[JsonProperty("to_happy_day", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ToHappyDay { get; set; }
		[JsonProperty("from_hours_happy", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FromHoursHappy { get; set; }
		[JsonProperty("to_hours_happy", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ToHoursHappy { get; set; }
		[JsonProperty("using_point", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> UsingPoint { get; set; }
		[JsonProperty("apply_to_partner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ApplyToPartner { get; set; }
		[JsonProperty("order_detail_promotion_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailPromotionMappingViewModel> OrderDetailPromotionMappingsVM { get; set; }
		[JsonProperty("order_promotion_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		[JsonProperty("promotion_store_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public PromotionViewModel(Promotion entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionViewModel()
		{
			this.OrderDetailPromotionMappingsVM = new HashSet<OrderDetailPromotionMappingViewModel>();
			this.OrderPromotionMappingsVM = new HashSet<OrderPromotionMappingViewModel>();
			this.PromotionStoreMappingsVM = new HashSet<PromotionStoreMappingViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
