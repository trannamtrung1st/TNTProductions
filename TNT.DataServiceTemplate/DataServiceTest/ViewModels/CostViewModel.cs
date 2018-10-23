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
		[JsonProperty("costID")]
		public int CostID { get; set; }
		[JsonProperty("catID")]
		public int CatID { get; set; }
		[JsonProperty("costDescription")]
		public string CostDescription { get; set; }
		[JsonProperty("costDate")]
		public DateTime CostDate { get; set; }
		[JsonProperty("amount")]
		public double Amount { get; set; }
		[JsonProperty("costStatus")]
		public int CostStatus { get; set; }
		[JsonProperty("paidPerson")]
		public string PaidPerson { get; set; }
		[JsonProperty("loggedPerson")]
		public string LoggedPerson { get; set; }
		[JsonProperty("approvedPerson")]
		public string ApprovedPerson { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("costCategoryType")]
		public Nullable<int> CostCategoryType { get; set; }
		[JsonProperty("costCode")]
		public string CostCode { get; set; }
		[JsonProperty("costType")]
		public Nullable<int> CostType { get; set; }
		[JsonProperty("costCategory")]
		public CostCategoryViewModel CostCategoryVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("costInventoryMappings")]
		public ICollection<CostInventoryMappingViewModel> CostInventoryMappingsVM { get; set; }
		[JsonProperty("payments")]
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
