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
	public partial class InventoryDateReportViewModel: BaseViewModel<InventoryDateReport>
	{
		[JsonProperty("report_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ReportID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreateDate { get; set; }
		[JsonProperty("creator", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Creator { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("inventory_date_report_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryDateReportItemViewModel> InventoryDateReportItemsVM { get; set; }
		
		public InventoryDateReportViewModel(InventoryDateReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryDateReportViewModel()
		{
			this.InventoryDateReportItemsVM = new HashSet<InventoryDateReportItemViewModel>();
		}
		
	}
}
