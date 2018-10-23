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
	public partial class InventoryCheckingItemViewModel: BaseViewModel<InventoryCheckingItem>
	{
		[JsonProperty("inventoryCheckingID")]
		public int InventoryCheckingID { get; set; }
		[JsonProperty("itemID")]
		public int ItemID { get; set; }
		[JsonProperty("checkingId")]
		public int CheckingId { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("unit")]
		public string Unit { get; set; }
		[JsonProperty("price")]
		public Nullable<double> Price { get; set; }
		[JsonProperty("inventoryChecking")]
		public InventoryCheckingViewModel InventoryCheckingVM { get; set; }
		
		public InventoryCheckingItemViewModel(InventoryCheckingItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryCheckingItemViewModel()
		{
		}
		
	}
}
