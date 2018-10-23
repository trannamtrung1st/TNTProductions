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
		[JsonProperty("paySlipId")]
		public Nullable<int> PaySlipId { get; set; }
		[JsonProperty("payrollDetailId")]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("value")]
		public Nullable<double> Value { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("payrollDetail")]
		public PayrollDetailViewModel PayrollDetailVM { get; set; }
		[JsonProperty("paySlip")]
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
