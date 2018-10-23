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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("payslipAttributeMappings")]
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
