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
	public partial class VoucherViewModel: BaseViewModel<Voucher>
	{
		[JsonProperty("voucher_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int VoucherID { get; set; }
		[JsonProperty("voucher_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VoucherCode { get; set; }
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("promotion_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Quantity { get; set; }
		[JsonProperty("used_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int UsedQuantity { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("is_getted", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsGetted { get; set; }
		[JsonProperty("is_used", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> isUsed { get; set; }
		[JsonProperty("membership_card_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MembershipCardId { get; set; }
		[JsonProperty("membership_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public MembershipCardViewModel MembershipCardVM { get; set; }
		[JsonProperty("promotion", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("promotion_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public VoucherViewModel(Voucher entity) : this()
		{
			FromEntity(entity);
		}
		
		public VoucherViewModel()
		{
		}
		
	}
}
