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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CustomerID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("total_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalOrder { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("average_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> AverageAmount { get; set; }
		[JsonProperty("visit_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VisitAmount { get; set; }
		[JsonProperty("date_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DateAmount { get; set; }
		[JsonProperty("frequency", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Frequency { get; set; }
		[JsonProperty("last_visit_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime LastVisitDate { get; set; }
		[JsonProperty("update_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime UpdateDate { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
