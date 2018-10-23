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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("timeModeRuleId")]
		public Nullable<int> TimeModeRuleId { get; set; }
		[JsonProperty("minTimeDuration")]
		public double MinTimeDuration { get; set; }
		[JsonProperty("maxTimeDuration")]
		public double MaxTimeDuration { get; set; }
		[JsonProperty("value")]
		public Nullable<double> Value { get; set; }
		[JsonProperty("rate")]
		public Nullable<double> Rate { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("timeModeRule")]
		public TimeModeRuleViewModel TimeModeRuleVM { get; set; }
		[JsonProperty("templateRuleMappings")]
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
