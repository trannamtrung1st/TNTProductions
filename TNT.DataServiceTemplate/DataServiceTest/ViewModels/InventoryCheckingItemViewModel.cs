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
		[JsonProperty("inventory_checking_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InventoryCheckingID { get; set; }
		[JsonProperty("item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemID { get; set; }
		[JsonProperty("checking_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CheckingId { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Quantity { get; set; }
		[JsonProperty("unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Unit { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Price { get; set; }
		[JsonProperty("inventory_checking", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
