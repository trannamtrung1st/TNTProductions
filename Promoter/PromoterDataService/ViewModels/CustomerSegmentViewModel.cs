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
		[JsonProperty("customer_iid")]
		public int CustomerIID { get; set; }
		[JsonProperty("segment_iid")]
		public int SegmentIID { get; set; }
		[JsonProperty("customer_sid")]
		public string CustomerSID { get; set; }
		[JsonProperty("segment_sid")]
		public string SegmentSID { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("segment")]
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
