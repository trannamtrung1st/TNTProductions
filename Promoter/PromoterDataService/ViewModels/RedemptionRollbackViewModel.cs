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
	public partial class RedemptionRollbackViewModel: BaseViewModel<RedemptionRollback>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("customer_iid")]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("customer_sid")]
		public string CustomerSID { get; set; }
		[JsonProperty("redemption_id")]
		public Nullable<int> RedemptionID { get; set; }
		[JsonProperty("reason")]
		public string Reason { get; set; }
		[JsonProperty("status")]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("failure_code")]
		public Nullable<int> FailureCode { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("redemption")]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public RedemptionRollbackViewModel(RedemptionRollback entity) : this()
		{
			FromEntity(entity);
		}
		
		public RedemptionRollbackViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
