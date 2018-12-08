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
	public partial class VoucherViewModel: BaseViewModel<Voucher>
	{
		[JsonProperty("voucher_id")]
		public int VoucherId { get; set; }
		[JsonProperty("voucher_code")]
		public string VoucherCode { get; set; }
		[JsonProperty("generated_date")]
		public Nullable<DateTime> GeneratedDate { get; set; }
		[JsonProperty("expired_date")]
		public Nullable<DateTime> ExpiredDate { get; set; }
		[JsonProperty("apply_quantity")]
		public int ApplyQuantity { get; set; }
		[JsonProperty("applied_quantity")]
		public int AppliedQuantity { get; set; }
		[JsonProperty("is_getted")]
		public bool IsGetted { get; set; }
		[JsonProperty("membership_code")]
		public string MembershipCode { get; set; }
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_detail")]
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
