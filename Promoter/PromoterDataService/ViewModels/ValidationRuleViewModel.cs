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
	public partial class ValidationRuleViewModel: BaseViewModel<ValidationRule>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("segmentRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SegmentRuleOp { get; set; }
		[JsonProperty("inSegmentId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string InSegmentId { get; set; }
		[JsonProperty("notInSegmentId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NotInSegmentId { get; set; }
		[JsonProperty("productRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductRuleOp { get; set; }
		[JsonProperty("productCodePattern", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductCodePattern { get; set; }
		[JsonProperty("minProductPrice", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MinProductPrice { get; set; }
		[JsonProperty("maxProductPrice", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MaxProductPrice { get; set; }
		[JsonProperty("minProductQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MinProductQuantity { get; set; }
		[JsonProperty("maxProductQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxProductQuantity { get; set; }
		[JsonProperty("orderRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderRuleOp { get; set; }
		[JsonProperty("minOrderAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MinOrderAmount { get; set; }
		[JsonProperty("maxOrderAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MaxOrderAmount { get; set; }
		[JsonProperty("minOrderProductQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MinOrderProductQuantity { get; set; }
		[JsonProperty("maxOrderProductQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxOrderProductQuantity { get; set; }
		[JsonProperty("redemptionRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionRuleOp { get; set; }
		[JsonProperty("minRedeemTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MinRedeemTimes { get; set; }
		[JsonProperty("maxRedeemTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxRedeemTimes { get; set; }
		[JsonProperty("generalRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GeneralRuleOp { get; set; }
		[JsonProperty("startDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("expirationDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ExpirationDate { get; set; }
		[JsonProperty("listApplyHours", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ListApplyHours { get; set; }
		[JsonProperty("applyStoresId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApplyStoresId { get; set; }
		[JsonProperty("exceptDates", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExceptDates { get; set; }
		[JsonProperty("exceptDOWs", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExceptDOWs { get; set; }
		[JsonProperty("anotherRuleOp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AnotherRuleOp { get; set; }
		[JsonProperty("anotherRuleId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AnotherRuleId { get; set; }
		[JsonProperty("validationRule2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRule2VM { get; set; }
		[JsonProperty("campaigns", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CampaignViewModel> CampaignsVM { get; set; }
		[JsonProperty("promotions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("validationRule1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ValidationRuleViewModel> ValidationRule1VM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public ValidationRuleViewModel(ValidationRule entity) : this()
		{
			FromEntity(entity);
		}
		
		public ValidationRuleViewModel()
		{
			this.CampaignsVM = new HashSet<CampaignViewModel>();
			this.PromotionsVM = new HashSet<PromotionViewModel>();
			this.ValidationRule1VM = new HashSet<ValidationRuleViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
