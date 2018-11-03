﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class PaySlipTemplateViewModel: BaseViewModel<PaySlipTemplate>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("payroll_periods", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PayrollPeriodViewModel> PayrollPeriodsVM { get; set; }
		[JsonProperty("template_detail_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TemplateDetailMappingViewModel> TemplateDetailMappingsVM { get; set; }
		[JsonProperty("template_rule_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TemplateRuleMappingViewModel> TemplateRuleMappingsVM { get; set; }
		
		public PaySlipTemplateViewModel(PaySlipTemplate entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaySlipTemplateViewModel()
		{
			this.PayrollPeriodsVM = new HashSet<PayrollPeriodViewModel>();
			this.TemplateDetailMappingsVM = new HashSet<TemplateDetailMappingViewModel>();
			this.TemplateRuleMappingsVM = new HashSet<TemplateRuleMappingViewModel>();
		}
		
	}
}
