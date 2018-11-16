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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("segment_rule_op")]
		public Nullable<int> SegmentRuleOp { get; set; }
		[JsonProperty("in_segment_iid")]
		public Nullable<int> InSegmentIID { get; set; }
		[JsonProperty("not_in_segment_iid")]
		public Nullable<int> NotInSegmentIID { get; set; }
		[JsonProperty("product_rule_op")]
		public Nullable<int> ProductRuleOp { get; set; }
		[JsonProperty("product_code_pattern")]
		public string ProductCodePattern { get; set; }
		[JsonProperty("min_product_price")]
		public Nullable<double> MinProductPrice { get; set; }
		[JsonProperty("max_product_price")]
		public Nullable<double> MaxProductPrice { get; set; }
		[JsonProperty("min_product_quantity")]
		public Nullable<int> MinProductQuantity { get; set; }
		[JsonProperty("max_product_quantity")]
		public Nullable<int> MaxProductQuantity { get; set; }
		[JsonProperty("order_rule_op")]
		public Nullable<int> OrderRuleOp { get; set; }
		[JsonProperty("min_order_amount")]
		public Nullable<double> MinOrderAmount { get; set; }
		[JsonProperty("max_order_amount")]
		public Nullable<double> MaxOrderAmount { get; set; }
		[JsonProperty("min_order_product_quantity")]
		public Nullable<int> MinOrderProductQuantity { get; set; }
		[JsonProperty("max_order_product_quantity")]
		public Nullable<int> MaxOrderProductQuantity { get; set; }
		[JsonProperty("redemption_rule_op")]
		public Nullable<int> RedemptionRuleOp { get; set; }
		[JsonProperty("min_redeem_times")]
		public Nullable<int> MinRedeemTimes { get; set; }
		[JsonProperty("max_redeem_times")]
		public Nullable<int> MaxRedeemTimes { get; set; }
		[JsonProperty("general_rule_op")]
		public Nullable<int> GeneralRuleOp { get; set; }
		[JsonProperty("start_date")]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("expiration_date")]
		public Nullable<DateTime> ExpirationDate { get; set; }
		[JsonProperty("list_apply_hours")]
		public string ListApplyHours { get; set; }
		[JsonProperty("except_dates")]
		public string ExceptDates { get; set; }
		[JsonProperty("except_dows")]
		public string ExceptDOWs { get; set; }
		[JsonProperty("membership_rule_op")]
		public Nullable<int> MembershipRuleOp { get; set; }
		[JsonProperty("min_point")]
		public Nullable<double> MinPoint { get; set; }
		[JsonProperty("max_point")]
		public Nullable<double> MaxPoint { get; set; }
		[JsonProperty("membership_code")]
		public string MembershipCode { get; set; }
		[JsonProperty("membership_regex_code")]
		public string MembershipRegexCode { get; set; }
		[JsonProperty("another_rule_op")]
		public Nullable<int> AnotherRuleOp { get; set; }
		[JsonProperty("another_rule_id")]
		public Nullable<int> AnotherRuleID { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("segment")]
		public SegmentViewModel SegmentVM { get; set; }
		[JsonProperty("segment1")]
		public SegmentViewModel Segment1VM { get; set; }
		[JsonProperty("validation_rule2")]
		public ValidationRuleViewModel ValidationRule2VM { get; set; }
		[JsonProperty("campaigns")]
		public IEnumerable<CampaignViewModel> CampaignsVM { get; set; }
		[JsonProperty("promotions")]
		public IEnumerable<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("promotion_store_rules")]
		public IEnumerable<PromotionStoreRuleViewModel> PromotionStoreRulesVM { get; set; }
		[JsonProperty("validation_rule1")]
		public IEnumerable<ValidationRuleViewModel> ValidationRule1VM { get; set; }
		[JsonProperty("vouchers")]
		public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
		public ValidationRuleViewModel(ValidationRule entity) : this()
		{
			FromEntity(entity);
		}
		
		public ValidationRuleViewModel()
		{
			this.CampaignsVM = new HashSet<CampaignViewModel>();
			this.PromotionsVM = new HashSet<PromotionViewModel>();
			this.PromotionStoreRulesVM = new HashSet<PromotionStoreRuleViewModel>();
			this.ValidationRule1VM = new HashSet<ValidationRuleViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
