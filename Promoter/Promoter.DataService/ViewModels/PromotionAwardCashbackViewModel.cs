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
	public partial class PromotionAwardCashbackViewModel: BaseViewModel<PromotionAwardCashback>
	{
		[JsonProperty("promotion_award_id")]
		public int PromotionAwardId { get; set; }
		[JsonProperty("for_product_id")]
		public Nullable<int> ForProductId { get; set; }
		[JsonProperty("customer_cashback_mode")]
		public Nullable<int> CustomerCashbackMode { get; set; }
		[JsonProperty("customer_cashback_account_type")]
		public Nullable<int> CustomerCashbackAccountType { get; set; }
		[JsonProperty("customer_cashback_amount")]
		public Nullable<double> CustomerCashbackAmount { get; set; }
		[JsonProperty("max_customer_cashback_amount")]
		public Nullable<double> MaxCustomerCashbackAmount { get; set; }
		[JsonProperty("affliator_cashback_mode")]
		public Nullable<int> AffliatorCashbackMode { get; set; }
		[JsonProperty("affliator_cashback_account_type")]
		public Nullable<int> AffliatorCashbackAccountType { get; set; }
		[JsonProperty("affliator_cashback_amount")]
		public Nullable<double> AffliatorCashbackAmount { get; set; }
		[JsonProperty("max_affliator_cashback_amount")]
		public Nullable<double> MaxAffliatorCashbackAmount { get; set; }
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public PromotionAwardCashbackViewModel(PromotionAwardCashback entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionAwardCashbackViewModel()
		{
		}
		
	}
}
