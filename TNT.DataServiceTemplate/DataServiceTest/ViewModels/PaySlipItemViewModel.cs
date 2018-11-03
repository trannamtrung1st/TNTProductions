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
	public partial class PaySlipItemViewModel: BaseViewModel<PaySlipItem>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("pay_slip_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PaySlipId { get; set; }
		[JsonProperty("payroll_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Value { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("payroll_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PayrollDetailViewModel PayrollDetailVM { get; set; }
		[JsonProperty("pay_slip", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PaySlipViewModel PaySlipVM { get; set; }
		
		public PaySlipItemViewModel(PaySlipItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaySlipItemViewModel()
		{
		}
		
	}
}
