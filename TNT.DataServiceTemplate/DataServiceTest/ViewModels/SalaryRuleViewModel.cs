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
	public partial class SalaryRuleViewModel: BaseViewModel<SalaryRule>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("time_mode_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TimeModeRuleId { get; set; }
		[JsonProperty("min_time_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double MinTimeDuration { get; set; }
		[JsonProperty("max_time_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double MaxTimeDuration { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Value { get; set; }
		[JsonProperty("rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Rate { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("time_mode_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public TimeModeRuleViewModel TimeModeRuleVM { get; set; }
		[JsonProperty("template_rule_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TemplateRuleMappingViewModel> TemplateRuleMappingsVM { get; set; }
		
		public SalaryRuleViewModel(SalaryRule entity) : this()
		{
			FromEntity(entity);
		}
		
		public SalaryRuleViewModel()
		{
			this.TemplateRuleMappingsVM = new HashSet<TemplateRuleMappingViewModel>();
		}
		
	}
}
