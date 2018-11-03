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
		[JsonProperty("item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Quantity { get; set; }
		[JsonProperty("report_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ReportID { get; set; }
		[JsonProperty("import_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> ImportAmount { get; set; }
		[JsonProperty("export_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> ExportAmount { get; set; }
		[JsonProperty("cancel_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CancelAmount { get; set; }
		[JsonProperty("sold_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> SoldAmount { get; set; }
		[JsonProperty("return_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> ReturnAmount { get; set; }
		[JsonProperty("change_inventory_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> ChangeInventoryAmount { get; set; }
		[JsonProperty("theory_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TheoryAmount { get; set; }
		[JsonProperty("real_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> RealAmount { get; set; }
		[JsonProperty("total_export", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalExport { get; set; }
		[JsonProperty("total_import", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalImport { get; set; }
		[JsonProperty("received_change_inventory_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> ReceivedChangeInventoryAmount { get; set; }
		[JsonProperty("is_selected", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsSelected { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Price { get; set; }
		[JsonProperty("inventory_date_report", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public InventoryDateReportViewModel InventoryDateReportVM { get; set; }
		[JsonProperty("product_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
