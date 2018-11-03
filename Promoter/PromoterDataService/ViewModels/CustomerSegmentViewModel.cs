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
		[JsonProperty("customer_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CustomerIID { get; set; }
		[JsonProperty("segment_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int SegmentIID { get; set; }
		[JsonProperty("customer_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerSID { get; set; }
		[JsonProperty("segment_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SegmentSID { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
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
