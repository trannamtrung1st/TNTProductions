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
		public int Id { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("customerId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("redemptionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionId { get; set; }
		[JsonProperty("reason", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Reason { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("failureCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FailureCode { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("redemption", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("promotionAppliedDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
