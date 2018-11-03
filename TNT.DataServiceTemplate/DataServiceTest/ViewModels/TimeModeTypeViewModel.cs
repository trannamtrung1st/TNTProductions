using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class TimeModeTypeViewModel: BaseViewModel<TimeModeType>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("time_mode_rules", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TimeModeRuleViewModel> TimeModeRulesVM { get; set; }
		
		public TimeModeTypeViewModel(TimeModeType entity) : this()
		{
			FromEntity(entity);
		}
		
		public TimeModeTypeViewModel()
		{
			this.TimeModeRulesVM = new HashSet<TimeModeRuleViewModel>();
		}
		
	}
}
