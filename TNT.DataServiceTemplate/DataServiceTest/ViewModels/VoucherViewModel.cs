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
		[JsonProperty("voucherID")]
		public int VoucherID { get; set; }
		[JsonProperty("voucherCode")]
		public string VoucherCode { get; set; }
		[JsonProperty("promotionDetailID")]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("promotionID")]
		public int PromotionID { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("usedQuantity")]
		public int UsedQuantity { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("isGetted")]
		public Nullable<bool> IsGetted { get; set; }
		[JsonProperty("isUsed")]
		public Nullable<bool> isUsed { get; set; }
		[JsonProperty("membershipCardId")]
		public Nullable<int> MembershipCardId { get; set; }
		[JsonProperty("membershipCard")]
		public MembershipCardViewModel MembershipCardVM { get; set; }
		[JsonProperty("promotion")]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("promotionDetail")]
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
