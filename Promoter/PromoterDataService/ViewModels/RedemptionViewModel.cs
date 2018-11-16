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
	public partial class RedemptionViewModel: BaseViewModel<Redemption>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("date")]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("customer_iid")]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("customer_sid")]
		public string CustomerSID { get; set; }
		[JsonProperty("metadata_object")]
		public string MetadataObject { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("failure_code")]
		public Nullable<int> FailureCode { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		[JsonProperty("redemption_rollbacks")]
		public IEnumerable<RedemptionRollbackViewModel> RedemptionRollbacksVM { get; set; }
		
		public RedemptionViewModel(Redemption entity) : this()
		{
			FromEntity(entity);
		}
		
		public RedemptionViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
			this.RedemptionRollbacksVM = new HashSet<RedemptionRollbackViewModel>();
		}
		
	}
}
