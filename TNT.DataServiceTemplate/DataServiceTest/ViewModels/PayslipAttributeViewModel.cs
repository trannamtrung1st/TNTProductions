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
	public partial class PayslipAttributeViewModel: BaseViewModel<PayslipAttribute>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("payslip_attribute_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PayslipAttributeMappingViewModel> PayslipAttributeMappingsVM { get; set; }
		
		public PayslipAttributeViewModel(PayslipAttribute entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayslipAttributeViewModel()
		{
			this.PayslipAttributeMappingsVM = new HashSet<PayslipAttributeMappingViewModel>();
		}
		
	}
}
