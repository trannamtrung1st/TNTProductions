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
	public partial class PayslipAttributeMappingViewModel: BaseViewModel<PayslipAttributeMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("payslip_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PayslipId { get; set; }
		[JsonProperty("attribute_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AttributeId { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Value { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("pay_slip", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PaySlipViewModel PaySlipVM { get; set; }
		[JsonProperty("payslip_attribute", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PayslipAttributeViewModel PayslipAttributeVM { get; set; }
		
		public PayslipAttributeMappingViewModel(PayslipAttributeMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayslipAttributeMappingViewModel()
		{
		}
		
	}
}
