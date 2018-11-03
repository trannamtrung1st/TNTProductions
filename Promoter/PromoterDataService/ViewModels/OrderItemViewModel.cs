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
	public partial class OrderItemViewModel: BaseViewModel<OrderItem>
	{
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("order_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderIID { get; set; }
		[JsonProperty("order_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string OrderSID { get; set; }
		[JsonProperty("product_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductIID { get; set; }
		[JsonProperty("product_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductSID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Quantity { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("promotion_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public OrderItemViewModel(OrderItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderItemViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
