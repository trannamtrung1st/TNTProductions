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
	public partial class TimeModeRuleViewModel: BaseViewModel<TimeModeRule>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("start_hour", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> StartHour { get; set; }
		[JsonProperty("end_hour", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> EndHour { get; set; }
		[JsonProperty("min_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MinDuration { get; set; }
		[JsonProperty("max_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MaxDuration { get; set; }
		[JsonProperty("day_mode_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DayModeId { get; set; }
		[JsonProperty("time_mode_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TimeModeTypeId { get; set; }
		[JsonProperty("default_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DefaultRate { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("day_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DayModeViewModel DayModeVM { get; set; }
		[JsonProperty("time_mode_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public TimeModeTypeViewModel TimeModeTypeVM { get; set; }
		[JsonProperty("salary_rules", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<SalaryRuleViewModel> SalaryRulesVM { get; set; }
		
		public TimeModeRuleViewModel(TimeModeRule entity) : this()
		{
			FromEntity(entity);
		}
		
		public TimeModeRuleViewModel()
		{
			this.SalaryRulesVM = new HashSet<SalaryRuleViewModel>();
		}
		
	}
}
