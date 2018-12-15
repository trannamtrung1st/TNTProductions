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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("inventory_template_report_id")]
		public int InventoryTemplateReportId { get; set; }
		[JsonProperty("product_item_id")]
		public int ProductItemId { get; set; }
		[JsonProperty("mapping_index")]
		public int MappingIndex { get; set; }
		//[JsonProperty("inventory_template_report")]
		//public InventoryTemplateReportViewModel InventoryTemplateReportVM { get; set; }
		//[JsonProperty("product_item")]
		//public ProductItemViewModel ProductItemVM { get; set; }
		
		public TemplateReportProductItemMappingViewModel(TemplateReportProductItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateReportProductItemMappingViewModel()
		{
		}
		
	}
}
