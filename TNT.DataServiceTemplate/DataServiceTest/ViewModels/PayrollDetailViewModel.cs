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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Value { get; set; }
		[JsonProperty("payroll_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PayrollCategoryId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("payroll_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PayrollCategoryViewModel PayrollCategoryVM { get; set; }
		[JsonProperty("pay_slip_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaySlipItemViewModel> PaySlipItemsVM { get; set; }
		[JsonProperty("template_detail_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
