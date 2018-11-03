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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("customer_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("customer_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerSID { get; set; }
		[JsonProperty("redemption_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionID { get; set; }
		[JsonProperty("reason", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Reason { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("failure_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FailureCode { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("redemption", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("promotion_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
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
