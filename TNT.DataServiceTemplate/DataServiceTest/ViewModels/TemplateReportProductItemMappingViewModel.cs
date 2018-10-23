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
		[JsonProperty("inventoryTemplateReportId")]
		public int InventoryTemplateReportId { get; set; }
		[JsonProperty("productItemId")]
		public int ProductItemId { get; set; }
		[JsonProperty("mappingIndex")]
		public int MappingIndex { get; set; }
		[JsonProperty("inventoryTemplateReport")]
		public InventoryTemplateReportViewModel InventoryTemplateReportVM { get; set; }
		[JsonProperty("productItem")]
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
