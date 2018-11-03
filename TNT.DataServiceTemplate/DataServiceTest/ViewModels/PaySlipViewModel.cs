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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("payroll_period_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PayrollPeriodId { get; set; }
		[JsonProperty("employee_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("template_detail_mapping_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TemplateDetailMappingId { get; set; }
		[JsonProperty("from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("final_paid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalPaid { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("payroll_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PayrollPeriodViewModel PayrollPeriodVM { get; set; }
		[JsonProperty("template_detail_mapping", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public TemplateDetailMappingViewModel TemplateDetailMappingVM { get; set; }
		[JsonProperty("payslip_attribute_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PayslipAttributeMappingViewModel> PayslipAttributeMappingsVM { get; set; }
		[JsonProperty("pay_slip_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaySlipItemViewModel> PaySlipItemsVM { get; set; }
		
		public PaySlipViewModel(PaySlip entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaySlipViewModel()
		{
			this.PayslipAttributeMappingsVM = new HashSet<PayslipAttributeMappingViewModel>();
			this.PaySlipItemsVM = new HashSet<PaySlipItemViewModel>();
		}
		
	}
}
