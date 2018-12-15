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
		[JsonProperty("report_id")]
		public int ReportID { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }
		[JsonProperty("creator")]
		public string Creator { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("inventory_date_report_items")]
		//public IEnumerable<InventoryDateReportItemViewModel> InventoryDateReportItemsVM { get; set; }
		
		public InventoryDateReportViewModel(InventoryDateReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryDateReportViewModel()
		{
			//this.InventoryDateReportItemsVM = new HashSet<InventoryDateReportItemViewModel>();
		}
		
	}
}
