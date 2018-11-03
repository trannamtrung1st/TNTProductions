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
	public partial class InventoryCheckingViewModel: BaseViewModel<InventoryChecking>
	{
		[JsonProperty("checking_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CheckingId { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("checking_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CheckingDate { get; set; }
		[JsonProperty("creator", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Creator { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("inventory_checking_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryCheckingItemViewModel> InventoryCheckingItemsVM { get; set; }
		
		public InventoryCheckingViewModel(InventoryChecking entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryCheckingViewModel()
		{
			this.InventoryCheckingItemsVM = new HashSet<InventoryCheckingItemViewModel>();
		}
		
	}
}
