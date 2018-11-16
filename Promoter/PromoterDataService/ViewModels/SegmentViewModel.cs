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
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("customer_segments")]
		public IEnumerable<CustomerSegmentViewModel> CustomerSegmentsVM { get; set; }
		[JsonProperty("validation_rules")]
		public IEnumerable<ValidationRuleViewModel> ValidationRulesVM { get; set; }
		[JsonProperty("validation_rules1")]
		public IEnumerable<ValidationRuleViewModel> ValidationRules1VM { get; set; }
		
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
