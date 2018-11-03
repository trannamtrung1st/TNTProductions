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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("customer_segments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		[JsonProperty("validation_rules", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ValidationRuleViewModel> ValidationRulesVM { get; set; }
		[JsonProperty("validation_rules1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ValidationRuleViewModel> ValidationRules1VM { get; set; }
		
		public SegmentViewModel(Segment entity) : this()
		{
			FromEntity(entity);
		}
		
		public SegmentViewModel()
		{
			this.CustomerSegmentsVM = new HashSet<CustomerSegmentViewModel>();
			this.ValidationRulesVM = new HashSet<ValidationRuleViewModel>();
			this.ValidationRules1VM = new HashSet<ValidationRuleViewModel>();
		}
		
	}
}
