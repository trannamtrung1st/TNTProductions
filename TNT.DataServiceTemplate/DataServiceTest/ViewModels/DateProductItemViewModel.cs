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
	public partial class DateProductItemViewModel: BaseViewModel<DateProductItem>
	{
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("productItemID")]
		public int ProductItemID { get; set; }
		[JsonProperty("productItemName")]
		public string ProductItemName { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("unit")]
		public string Unit { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public DateProductItemViewModel(DateProductItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateProductItemViewModel()
		{
		}
		
	}
}
