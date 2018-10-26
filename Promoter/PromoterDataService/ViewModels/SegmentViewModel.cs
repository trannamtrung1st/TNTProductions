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
	public partial class SegmentViewModel: BaseViewModel<Segment>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("customerSegments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		
		public SegmentViewModel(Segment entity) : this()
		{
			FromEntity(entity);
		}
		
		public SegmentViewModel()
		{
			this.CustomerSegmentsVM = new HashSet<CustomerSegmentViewModel>();
		}
		
	}
}
