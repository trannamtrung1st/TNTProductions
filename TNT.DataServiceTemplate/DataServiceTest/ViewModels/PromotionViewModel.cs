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
		[JsonProperty("promotionID")]
		public int PromotionID { get; set; }
		[JsonProperty("promotionCode")]
		public string PromotionCode { get; set; }
		[JsonProperty("promotionName")]
		public string PromotionName { get; set; }
		[JsonProperty("promotionClassName")]
		public string PromotionClassName { get; set; }
		[JsonProperty("shortDescription")]
		public string ShortDescription { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("imageCss")]
		public string ImageCss { get; set; }
		[JsonProperty("applyLevel")]
		public int ApplyLevel { get; set; }
		[JsonProperty("giftType")]
		public int GiftType { get; set; }
		[JsonProperty("isForMember")]
		public bool IsForMember { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("fromDate")]
		public DateTime FromDate { get; set; }
		[JsonProperty("toDate")]
		public DateTime ToDate { get; set; }
		[JsonProperty("applyFromTime")]
		public Nullable<int> ApplyFromTime { get; set; }
		[JsonProperty("applyToTime")]
		public Nullable<int> ApplyToTime { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("isVoucher")]
		public Nullable<bool> IsVoucher { get; set; }
		[JsonProperty("isApplyOnce")]
		public Nullable<bool> IsApplyOnce { get; set; }
		[JsonProperty("voucherQuantity")]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucherUsedQuantity")]
		public Nullable<int> VoucherUsedQuantity { get; set; }
		[JsonProperty("promotionType")]
		public int PromotionType { get; set; }
		[JsonProperty("fromHappyDay")]
		public Nullable<int> FromHappyDay { get; set; }
		[JsonProperty("toHappyDay")]
		public Nullable<int> ToHappyDay { get; set; }
		[JsonProperty("fromHoursHappy")]
		public Nullable<int> FromHoursHappy { get; set; }
		[JsonProperty("toHoursHappy")]
		public Nullable<int> ToHoursHappy { get; set; }
		[JsonProperty("usingPoint")]
		public Nullable<bool> UsingPoint { get; set; }
		[JsonProperty("applyToPartner")]
		public Nullable<int> ApplyToPartner { get; set; }
		[JsonProperty("orderDetailPromotionMappings")]
		public ICollection<OrderDetailPromotionMappingViewModel> OrderDetailPromotionMappingsVM { get; set; }
		[JsonProperty("orderPromotionMappings")]
		public ICollection<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		[JsonProperty("promotionStoreMappings")]
		public ICollection<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		[JsonProperty("vouchers")]
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
