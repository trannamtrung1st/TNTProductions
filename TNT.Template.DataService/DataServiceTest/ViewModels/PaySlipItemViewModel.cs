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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("pay_slip_id")]
		public Nullable<int> PaySlipId { get; set; }
		[JsonProperty("payroll_detail_id")]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("value")]
		public Nullable<double> Value { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("payroll_detail")]
		//public PayrollDetailViewModel PayrollDetailVM { get; set; }
		//[JsonProperty("pay_slip")]
		//public PaySlipViewModel PaySlipVM { get; set; }
		
		public PaySlipItemViewModel(PaySlipItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaySlipItemViewModel()
		{
		}
		
	}
}
