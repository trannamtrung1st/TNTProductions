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
	public partial class PayrollDetailViewModel: BaseViewModel<PayrollDetail>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("value")]
		public Nullable<double> Value { get; set; }
		[JsonProperty("payrollCategoryId")]
		public Nullable<int> PayrollCategoryId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("payrollCategory")]
		public PayrollCategoryViewModel PayrollCategoryVM { get; set; }
		[JsonProperty("paySlipItems")]
		public ICollection<PaySlipItemViewModel> PaySlipItemsVM { get; set; }
		[JsonProperty("templateDetailMappings")]
		public ICollection<TemplateDetailMappingViewModel> TemplateDetailMappingsVM { get; set; }
		
		public PayrollDetailViewModel(PayrollDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayrollDetailViewModel()
		{
			this.PaySlipItemsVM = new HashSet<PaySlipItemViewModel>();
			this.TemplateDetailMappingsVM = new HashSet<TemplateDetailMappingViewModel>();
		}
		
	}
}
