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
	public partial class InventoryDateReportItemViewModel: BaseViewModel<InventoryDateReportItem>
	{
		[JsonProperty("itemID")]
		public int ItemID { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("reportID")]
		public int ReportID { get; set; }
		[JsonProperty("importAmount")]
		public Nullable<double> ImportAmount { get; set; }
		[JsonProperty("exportAmount")]
		public Nullable<double> ExportAmount { get; set; }
		[JsonProperty("cancelAmount")]
		public Nullable<double> CancelAmount { get; set; }
		[JsonProperty("soldAmount")]
		public Nullable<double> SoldAmount { get; set; }
		[JsonProperty("returnAmount")]
		public Nullable<double> ReturnAmount { get; set; }
		[JsonProperty("changeInventoryAmount")]
		public Nullable<double> ChangeInventoryAmount { get; set; }
		[JsonProperty("theoryAmount")]
		public Nullable<double> TheoryAmount { get; set; }
		[JsonProperty("realAmount")]
		public Nullable<double> RealAmount { get; set; }
		[JsonProperty("totalExport")]
		public Nullable<double> TotalExport { get; set; }
		[JsonProperty("totalImport")]
		public Nullable<double> TotalImport { get; set; }
		[JsonProperty("receivedChangeInventoryAmount")]
		public Nullable<double> ReceivedChangeInventoryAmount { get; set; }
		[JsonProperty("isSelected")]
		public Nullable<bool> IsSelected { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("inventoryDateReport")]
		public InventoryDateReportViewModel InventoryDateReportVM { get; set; }
		[JsonProperty("productItem")]
		public ProductItemViewModel ProductItemVM { get; set; }
		
		public InventoryDateReportItemViewModel(InventoryDateReportItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryDateReportItemViewModel()
		{
		}
		
	}
}
