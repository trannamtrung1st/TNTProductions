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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("pay_slip_template_id")]
		public Nullable<int> PaySlipTemplateId { get; set; }
		[JsonProperty("salary_rule_id")]
		public Nullable<int> SalaryRuleId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("pay_slip_template")]
		//public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		//[JsonProperty("salary_rule")]
		//public SalaryRuleViewModel SalaryRuleVM { get; set; }
		
		public TemplateRuleMappingViewModel(TemplateRuleMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateRuleMappingViewModel()
		{
		}
		
	}
}
