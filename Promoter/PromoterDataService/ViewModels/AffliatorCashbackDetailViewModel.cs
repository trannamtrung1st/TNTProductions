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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("cashback_account_type")]
		public Nullable<int> CashbackAccountType { get; set; }
		[JsonProperty("cashback_type")]
		public Nullable<int> CashbackType { get; set; }
		[JsonProperty("cashback_per1000_vnd")]
		public Nullable<double> CashbackPer1000VND { get; set; }
		[JsonProperty("cashback_percent_of_order")]
		public Nullable<double> CashbackPercentOfOrder { get; set; }
		[JsonProperty("cashback_by_rank_amount")]
		public Nullable<double> CashbackByRankAmount { get; set; }
		[JsonProperty("rank_sid")]
		public string RankSID { get; set; }
		[JsonProperty("cashback_by_card_recharge_rate")]
		public Nullable<double> CashbackByCardRechargeRate { get; set; }
		[JsonProperty("card_recharge_rate")]
		public Nullable<double> CardRechargeRate { get; set; }
		[JsonProperty("cashback_percent_of_card_recharge")]
		public Nullable<double> CashbackPercentOfCardRecharge { get; set; }
		[JsonProperty("cashback_by_segment")]
		public Nullable<double> CashbackBySegment { get; set; }
		[JsonProperty("segment_iid")]
		public Nullable<int> SegmentIID { get; set; }
		[JsonProperty("segment_sid")]
		public string SegmentSID { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
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
