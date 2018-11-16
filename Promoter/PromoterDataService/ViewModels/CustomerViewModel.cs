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
	public partial class CustomerViewModel: BaseViewModel<Customer>
	{
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("metadata_object")]
		public string MetadataObject { get; set; }
		[JsonProperty("created_time")]
		public Nullable<DateTime> CreatedTime { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("app_actions")]
		public IEnumerable<AppActionViewModel> AppActionsVM { get; set; }
		[JsonProperty("customer_segments")]
		public IEnumerable<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		[JsonProperty("orders")]
		public IEnumerable<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("redemptions")]
		public IEnumerable<RedemptionViewModel> RedemptionsVM { get; set; }
		[JsonProperty("redemption_rollbacks")]
		public IEnumerable<RedemptionRollbackViewModel> RedemptionRollbacksVM { get; set; }
		
		public CustomerViewModel(Customer entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerViewModel()
		{
			this.AppActionsVM = new HashSet<AppActionViewModel>();
			this.CustomerSegmentsVM = new HashSet<CustomerSegmentViewModel>();
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.RedemptionsVM = new HashSet<RedemptionViewModel>();
			this.RedemptionRollbacksVM = new HashSet<RedemptionRollbackViewModel>();
		}
		
	}
}
