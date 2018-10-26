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
	public partial class CustomerSegmentViewModel: BaseViewModel<CustomerSegment>
	{
		[JsonProperty("customerId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CustomerId { get; set; }
		[JsonProperty("segmentId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int SegmentId { get; set; }
		[JsonProperty("deactive", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Deactive { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("segment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public SegmentViewModel SegmentVM { get; set; }
		
		public CustomerSegmentViewModel(CustomerSegment entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerSegmentViewModel()
		{
		}
		
	}
}
