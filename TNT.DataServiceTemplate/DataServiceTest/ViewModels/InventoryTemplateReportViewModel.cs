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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("templateReportProductItemMappings")]
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
