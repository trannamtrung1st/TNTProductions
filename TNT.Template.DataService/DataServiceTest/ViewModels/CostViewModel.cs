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
		[JsonProperty("cost_id")]
		public int CostID { get; set; }
		[JsonProperty("cat_id")]
		public int CatID { get; set; }
		[JsonProperty("cost_description")]
		public string CostDescription { get; set; }
		[JsonProperty("cost_date")]
		public DateTime CostDate { get; set; }
		[JsonProperty("amount")]
		public double Amount { get; set; }
		[JsonProperty("cost_status")]
		public int CostStatus { get; set; }
		[JsonProperty("paid_person")]
		public string PaidPerson { get; set; }
		[JsonProperty("logged_person")]
		public string LoggedPerson { get; set; }
		[JsonProperty("approved_person")]
		public string ApprovedPerson { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("cost_category_type")]
		public Nullable<int> CostCategoryType { get; set; }
		[JsonProperty("cost_code")]
		public string CostCode { get; set; }
		[JsonProperty("cost_type")]
		public Nullable<int> CostType { get; set; }
		//[JsonProperty("cost_category")]
		//public CostCategoryViewModel CostCategoryVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("cost_inventory_mappings")]
		//public IEnumerable<CostInventoryMappingViewModel> CostInventoryMappingsVM { get; set; }
		//[JsonProperty("payments")]
		//public IEnumerable<PaymentViewModel> PaymentsVM { get; set; }
		
		public CostViewModel(Cost entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostViewModel()
		{
			//this.CostInventoryMappingsVM = new HashSet<CostInventoryMappingViewModel>();
			//this.PaymentsVM = new HashSet<PaymentViewModel>();
		}
		
	}
}
