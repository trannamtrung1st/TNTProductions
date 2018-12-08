using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Global;
using Promoter.DataService.Models;
using Newtonsoft.Json;

namespace Promoter.DataService.ViewModels
{
	public partial class PromotionConstraintViewModel: BaseViewModel<PromotionConstraint>
	{
		[JsonProperty("constraint_id")]
		public int ConstraintId { get; set; }
		[JsonProperty("has_time_contraint")]
		public bool HasTimeContraint { get; set; }
		[JsonProperty("promotion_begin_date")]
		public Nullable<DateTime> PromotionBeginDate { get; set; }
		[JsonProperty("promotion_end_date")]
		public Nullable<DateTime> PromotionEndDate { get; set; }
		[JsonProperty("has_order_constraint")]
		public bool HasOrderConstraint { get; set; }
		[JsonProperty("fix_product_filter")]
		public Nullable<bool> FixProductFilter { get; set; }
		[JsonProperty("min_total_products")]
		public Nullable<int> MinTotalProducts { get; set; }
		[JsonProperty("max_total_products")]
		public Nullable<int> MaxTotalProducts { get; set; }
		[JsonProperty("min_total_amount")]
		public Nullable<double> MinTotalAmount { get; set; }
		[JsonProperty("max_total_amount")]
		public Nullable<double> MaxTotalAmount { get; set; }
		[JsonProperty("min_person_count")]
		public Nullable<int> MinPersonCount { get; set; }
		[JsonProperty("max_person_count")]
		public Nullable<int> MaxPersonCount { get; set; }
		[JsonProperty("gender")]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("min_age")]
		public Nullable<int> MinAge { get; set; }
		[JsonProperty("max_age")]
		public Nullable<int> MaxAge { get; set; }
		[JsonProperty("has_payment_constraint")]
		public bool HasPaymentConstraint { get; set; }
		[JsonProperty("payment_type")]
		public Nullable<int> PaymentType { get; set; }
		[JsonProperty("payment_partner_code")]
		public string PaymentPartnerCode { get; set; }
		[JsonProperty("has_store_constraint")]
		public bool HasStoreConstraint { get; set; }
		[JsonProperty("has_membership_constraint")]
		public bool HasMembershipConstraint { get; set; }
		[JsonProperty("membership_code")]
		public string MembershipCode { get; set; }
		[JsonProperty("membership_type_code")]
		public string MembershipTypeCode { get; set; }
		[JsonProperty("membership_code_pattern")]
		public string MembershipCodePattern { get; set; }
		[JsonProperty("membership_min_level")]
		public Nullable<int> MembershipMinLevel { get; set; }
		[JsonProperty("membership_max_level")]
		public Nullable<int> MembershipMaxLevel { get; set; }
		[JsonProperty("min_point")]
		public Nullable<double> MinPoint { get; set; }
		[JsonProperty("max_point")]
		public Nullable<double> MaxPoint { get; set; }
		[JsonProperty("min_join_date")]
		public Nullable<int> MinJoinDate { get; set; }
		[JsonProperty("has_sale_mode_constraint")]
		public bool HasSaleModeConstraint { get; set; }
		[JsonProperty("for_take_away")]
		public Nullable<bool> ForTakeAway { get; set; }
		[JsonProperty("for_delivery")]
		public Nullable<bool> ForDelivery { get; set; }
		[JsonProperty("for_instore")]
		public Nullable<bool> ForInstore { get; set; }
		[JsonProperty("for_instore_preorder")]
		public Nullable<bool> ForInstorePreorder { get; set; }
		[JsonProperty("has_collection_constraint")]
		public bool HasCollectionConstraint { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("pc_date_time_filter")]
		public IEnumerable<PC_DateTimeFilterViewModel> PC_DateTimeFilterVM { get; set; }
		[JsonProperty("pc_product_filter")]
		public IEnumerable<PC_ProductFilterViewModel> PC_ProductFilterVM { get; set; }
		[JsonProperty("pc_store_filter")]
		public IEnumerable<PC_StoreFilterViewModel> PC_StoreFilterVM { get; set; }
		
		public PromotionConstraintViewModel(PromotionConstraint entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionConstraintViewModel()
		{
			this.PC_DateTimeFilterVM = new HashSet<PC_DateTimeFilterViewModel>();
			this.PC_ProductFilterVM = new HashSet<PC_ProductFilterViewModel>();
			this.PC_StoreFilterVM = new HashSet<PC_StoreFilterViewModel>();
		}
		
	}
}
