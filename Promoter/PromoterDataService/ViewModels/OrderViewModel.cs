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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("customer_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("customer_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerSID { get; set; }
		[JsonProperty("cashier_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CashierObject { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("store_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreIID { get; set; }
		[JsonProperty("store_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreSID { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("order_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderItemViewModel> OrderItemsVM { get; set; }
		[JsonProperty("promotion_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
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
