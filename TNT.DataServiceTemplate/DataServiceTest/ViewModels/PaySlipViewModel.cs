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
		[JsonProperty("payrollPeriodId")]
		public Nullable<int> PayrollPeriodId { get; set; }
		[JsonProperty("employeeId")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("templateDetailMappingId")]
		public Nullable<int> TemplateDetailMappingId { get; set; }
		[JsonProperty("fromDate")]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("toDate")]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("finalPaid")]
		public Nullable<double> FinalPaid { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("employee")]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("payrollPeriod")]
		public PayrollPeriodViewModel PayrollPeriodVM { get; set; }
		[JsonProperty("templateDetailMapping")]
		public TemplateDetailMappingViewModel TemplateDetailMappingVM { get; set; }
		[JsonProperty("payslipAttributeMappings")]
		public ICollection<PayslipAttributeMappingViewModel> PayslipAttributeMappingsVM { get; set; }
		[JsonProperty("paySlipItems")]
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
