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
	public partial class PaySlipTemplateViewModel: BaseViewModel<PaySlipTemplate>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("payrollPeriods")]
		public ICollection<PayrollPeriodViewModel> PayrollPeriodsVM { get; set; }
		[JsonProperty("templateDetailMappings")]
		public ICollection<TemplateDetailMappingViewModel> TemplateDetailMappingsVM { get; set; }
		[JsonProperty("templateRuleMappings")]
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
