using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class OrderViewModel: BaseViewModel<Order>
	{
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("total_amount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount")]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("customer_iid")]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("customer_sid")]
		public string CustomerSID { get; set; }
		[JsonProperty("cashier_object")]
		public string CashierObject { get; set; }
		[JsonProperty("date")]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("store_iid")]
		public Nullable<int> StoreIID { get; set; }
		[JsonProperty("store_sid")]
		public string StoreSID { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("order_items")]
		public IEnumerable<OrderItemViewModel> OrderItemsVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public OrderViewModel(Order entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderViewModel()
		{
			this.OrderItemsVM = new HashSet<OrderItemViewModel>();
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
