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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("metadata_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("created_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreatedTime { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("customer_segments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		[JsonProperty("events", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EventViewModel> EventsVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("redemptions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RedemptionViewModel> RedemptionsVM { get; set; }
		[JsonProperty("redemption_rollbacks", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RedemptionRollbackViewModel> RedemptionRollbacksVM { get; set; }
		
		public CustomerViewModel(Customer entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerViewModel()
		{
			this.CustomerSegmentsVM = new HashSet<CustomerSegmentViewModel>();
			this.EventsVM = new HashSet<EventViewModel>();
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.RedemptionsVM = new HashSet<RedemptionViewModel>();
			this.RedemptionRollbacksVM = new HashSet<RedemptionRollbackViewModel>();
		}
		
	}
}
