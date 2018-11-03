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
	public partial class InventoryTemplateReportViewModel: BaseViewModel<InventoryTemplateReport>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("template_report_product_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TemplateReportProductItemMappingViewModel> TemplateReportProductItemMappingsVM { get; set; }
		
		public InventoryTemplateReportViewModel(InventoryTemplateReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryTemplateReportViewModel()
		{
			this.TemplateReportProductItemMappingsVM = new HashSet<TemplateReportProductItemMappingViewModel>();
		}
		
	}
}
