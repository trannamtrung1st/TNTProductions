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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
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
		[JsonProperty("metadataObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("createdTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreatedTime { get; set; }
		[JsonProperty("customerSegments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		[JsonProperty("events", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EventViewModel> EventsVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("redemptions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RedemptionViewModel> RedemptionsVM { get; set; }
		[JsonProperty("redemptionRollbacks", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
