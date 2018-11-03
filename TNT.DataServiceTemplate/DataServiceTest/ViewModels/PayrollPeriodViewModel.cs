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
	public partial class PayrollPeriodViewModel: BaseViewModel<PayrollPeriod>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("pay_slip_template_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PaySlipTemplateId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsActive { get; set; }
		[JsonProperty("pay_slip_template", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		[JsonProperty("pay_slips", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public PayrollPeriodViewModel(PayrollPeriod entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayrollPeriodViewModel()
		{
			this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
