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
	public partial class DayModeViewModel: BaseViewModel<DayMode>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("day_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DayFilter { get; set; }
		[JsonProperty("is_special_day", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> IsSpecialDay { get; set; }
		[JsonProperty("priority", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Priority { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("time_mode_rules", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TimeModeRuleViewModel> TimeModeRulesVM { get; set; }
		
		public DayModeViewModel(DayMode entity) : this()
		{
			FromEntity(entity);
		}
		
		public DayModeViewModel()
		{
			this.TimeModeRulesVM = new HashSet<TimeModeRuleViewModel>();
		}
		
	}
}
