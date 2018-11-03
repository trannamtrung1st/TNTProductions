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
	public partial class TemplateReportProductItemMappingViewModel: BaseViewModel<TemplateReportProductItemMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("inventory_template_report_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InventoryTemplateReportId { get; set; }
		[JsonProperty("product_item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductItemId { get; set; }
		[JsonProperty("mapping_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MappingIndex { get; set; }
		[JsonProperty("inventory_template_report", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public InventoryTemplateReportViewModel InventoryTemplateReportVM { get; set; }
		[JsonProperty("product_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductItemViewModel ProductItemVM { get; set; }
		
		public TemplateReportProductItemMappingViewModel(TemplateReportProductItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateReportProductItemMappingViewModel()
		{
		}
		
	}
}
