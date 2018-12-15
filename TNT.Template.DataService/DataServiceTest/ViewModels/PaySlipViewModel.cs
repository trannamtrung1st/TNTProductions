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
	public partial class PaySlipViewModel: BaseViewModel<PaySlip>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("payroll_period_id")]
		public Nullable<int> PayrollPeriodId { get; set; }
		[JsonProperty("employee_id")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("template_detail_mapping_id")]
		public Nullable<int> TemplateDetailMappingId { get; set; }
		[JsonProperty("from_date")]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("to_date")]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("final_paid")]
		public Nullable<double> FinalPaid { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("employee")]
		//public EmployeeViewModel EmployeeVM { get; set; }
		//[JsonProperty("payroll_period")]
		//public PayrollPeriodViewModel PayrollPeriodVM { get; set; }
		//[JsonProperty("template_detail_mapping")]
		//public TemplateDetailMappingViewModel TemplateDetailMappingVM { get; set; }
		//[JsonProperty("payslip_attribute_mappings")]
		//public IEnumerable<PayslipAttributeMappingViewModel> PayslipAttributeMappingsVM { get; set; }
		//[JsonProperty("pay_slip_items")]
		//public IEnumerable<PaySlipItemViewModel> PaySlipItemsVM { get; set; }
		
		public PaySlipViewModel(PaySlip entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaySlipViewModel()
		{
			//this.PayslipAttributeMappingsVM = new HashSet<PayslipAttributeMappingViewModel>();
			//this.PaySlipItemsVM = new HashSet<PaySlipItemViewModel>();
		}
		
	}
}
