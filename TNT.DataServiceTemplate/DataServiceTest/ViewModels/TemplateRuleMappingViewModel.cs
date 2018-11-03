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
	public partial class TemplateRuleMappingViewModel: BaseViewModel<TemplateRuleMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("pay_slip_template_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PaySlipTemplateId { get; set; }
		[JsonProperty("salary_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SalaryRuleId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("pay_slip_template", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		[JsonProperty("salary_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public SalaryRuleViewModel SalaryRuleVM { get; set; }
		
		public TemplateRuleMappingViewModel(TemplateRuleMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateRuleMappingViewModel()
		{
		}
		
	}
}
