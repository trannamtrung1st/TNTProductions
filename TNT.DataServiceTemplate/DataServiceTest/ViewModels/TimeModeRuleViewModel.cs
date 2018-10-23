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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("startHour")]
		public Nullable<System.TimeSpan> StartHour { get; set; }
		[JsonProperty("endHour")]
		public Nullable<System.TimeSpan> EndHour { get; set; }
		[JsonProperty("minDuration")]
		public Nullable<double> MinDuration { get; set; }
		[JsonProperty("maxDuration")]
		public Nullable<double> MaxDuration { get; set; }
		[JsonProperty("dayModeId")]
		public Nullable<int> DayModeId { get; set; }
		[JsonProperty("timeModeTypeId")]
		public Nullable<int> TimeModeTypeId { get; set; }
		[JsonProperty("defaultRate")]
		public Nullable<double> DefaultRate { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("dayMode")]
		public DayModeViewModel DayModeVM { get; set; }
		[JsonProperty("timeModeType")]
		public TimeModeTypeViewModel TimeModeTypeVM { get; set; }
		[JsonProperty("salaryRules")]
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
