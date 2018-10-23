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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("paySlipTemplateId")]
		public Nullable<int> PaySlipTemplateId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("fromDate")]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("toDate")]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("isActive")]
		public Nullable<bool> IsActive { get; set; }
		[JsonProperty("paySlipTemplate")]
		public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		[JsonProperty("paySlips")]
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
