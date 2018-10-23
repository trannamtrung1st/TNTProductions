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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("customerID")]
		public int CustomerID { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("totalOrder")]
		public Nullable<int> TotalOrder { get; set; }
		[JsonProperty("totalAmount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("averageAmount")]
		public Nullable<double> AverageAmount { get; set; }
		[JsonProperty("visitAmount")]
		public Nullable<int> VisitAmount { get; set; }
		[JsonProperty("dateAmount")]
		public Nullable<int> DateAmount { get; set; }
		[JsonProperty("frequency")]
		public Nullable<double> Frequency { get; set; }
		[JsonProperty("lastVisitDate")]
		public DateTime LastVisitDate { get; set; }
		[JsonProperty("updateDate")]
		public DateTime UpdateDate { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public CustomerStoreReportMappingViewModel(CustomerStoreReportMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerStoreReportMappingViewModel()
		{
		}
		
	}
}
