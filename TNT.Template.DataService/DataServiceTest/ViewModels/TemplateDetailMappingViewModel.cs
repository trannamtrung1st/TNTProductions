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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("pay_slip_template_id")]
		public int PaySlipTemplateId { get; set; }
		[JsonProperty("payroll_detail_id")]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("payroll_detail")]
		//public PayrollDetailViewModel PayrollDetailVM { get; set; }
		//[JsonProperty("pay_slip_template")]
		//public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		//[JsonProperty("pay_slips")]
		//public IEnumerable<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public TemplateDetailMappingViewModel(TemplateDetailMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateDetailMappingViewModel()
		{
			//this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
