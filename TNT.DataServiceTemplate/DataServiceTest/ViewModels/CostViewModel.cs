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
	public partial class CostViewModel: BaseViewModel<Cost>
	{
		[JsonProperty("cost_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CostID { get; set; }
		[JsonProperty("cat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CatID { get; set; }
		[JsonProperty("cost_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CostDescription { get; set; }
		[JsonProperty("cost_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CostDate { get; set; }
		[JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Amount { get; set; }
		[JsonProperty("cost_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CostStatus { get; set; }
		[JsonProperty("paid_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PaidPerson { get; set; }
		[JsonProperty("logged_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LoggedPerson { get; set; }
		[JsonProperty("approved_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApprovedPerson { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("cost_category_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CostCategoryType { get; set; }
		[JsonProperty("cost_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CostCode { get; set; }
		[JsonProperty("cost_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CostType { get; set; }
		[JsonProperty("cost_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CostCategoryViewModel CostCategoryVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("cost_inventory_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CostInventoryMappingViewModel> CostInventoryMappingsVM { get; set; }
		[JsonProperty("payments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaymentViewModel> PaymentsVM { get; set; }
		
		public CostViewModel(Cost entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostViewModel()
		{
			this.CostInventoryMappingsVM = new HashSet<CostInventoryMappingViewModel>();
			this.PaymentsVM = new HashSet<PaymentViewModel>();
		}
		
	}
}
