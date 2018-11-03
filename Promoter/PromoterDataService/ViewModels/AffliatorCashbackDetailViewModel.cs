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
	public partial class AffliatorCashbackDetailViewModel: BaseViewModel<AffliatorCashbackDetail>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("cashback_account_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CashbackAccountType { get; set; }
		[JsonProperty("cashback_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CashbackType { get; set; }
		[JsonProperty("cashback_per1000_vnd", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackPer1000VND { get; set; }
		[JsonProperty("cashback_percent_of_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackPercentOfOrder { get; set; }
		[JsonProperty("cashback_by_rank_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackByRankAmount { get; set; }
		[JsonProperty("rank_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RankSID { get; set; }
		[JsonProperty("cashback_by_card_recharge_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackByCardRechargeRate { get; set; }
		[JsonProperty("card_recharge_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CardRechargeRate { get; set; }
		[JsonProperty("cashback_percent_of_card_recharge", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackPercentOfCardRecharge { get; set; }
		[JsonProperty("cashback_by_segment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CashbackBySegment { get; set; }
		[JsonProperty("segment_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SegmentID { get; set; }
		[JsonProperty("segment_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SegmentSID { get; set; }
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("promotion_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("promotion_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public AffliatorCashbackDetailViewModel(AffliatorCashbackDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public AffliatorCashbackDetailViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
