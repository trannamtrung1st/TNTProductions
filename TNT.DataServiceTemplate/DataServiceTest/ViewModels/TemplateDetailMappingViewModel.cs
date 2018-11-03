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
	public partial class TemplateDetailMappingViewModel: BaseViewModel<TemplateDetailMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("pay_slip_template_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PaySlipTemplateId { get; set; }
		[JsonProperty("payroll_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("payroll_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PayrollDetailViewModel PayrollDetailVM { get; set; }
		[JsonProperty("pay_slip_template", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		[JsonProperty("pay_slips", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public TemplateDetailMappingViewModel(TemplateDetailMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateDetailMappingViewModel()
		{
			this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
