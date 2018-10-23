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
		[JsonProperty("checkingId")]
		public int CheckingId { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("checkingDate")]
		public DateTime CheckingDate { get; set; }
		[JsonProperty("creator")]
		public string Creator { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("inventoryCheckingItems")]
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
