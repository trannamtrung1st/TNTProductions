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
	public partial class CustomerStoreReportMappingViewModel: BaseViewModel<CustomerStoreReportMapping>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("customer_id")]
		public int CustomerID { get; set; }
		[JsonProperty("store_id")]
		public int StoreID { get; set; }
		[JsonProperty("total_order")]
		public Nullable<int> TotalOrder { get; set; }
		[JsonProperty("total_amount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("average_amount")]
		public Nullable<double> AverageAmount { get; set; }
		[JsonProperty("visit_amount")]
		public Nullable<int> VisitAmount { get; set; }
		[JsonProperty("date_amount")]
		public Nullable<int> DateAmount { get; set; }
		[JsonProperty("frequency")]
		public Nullable<double> Frequency { get; set; }
		[JsonProperty("last_visit_date")]
		public DateTime LastVisitDate { get; set; }
		[JsonProperty("update_date")]
		public DateTime UpdateDate { get; set; }
		//[JsonProperty("customer")]
		//public CustomerViewModel CustomerVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public CustomerStoreReportMappingViewModel(CustomerStoreReportMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerStoreReportMappingViewModel()
		{
		}
		
	}
}
