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
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("order_iid")]
		public Nullable<int> OrderIID { get; set; }
		[JsonProperty("order_sid")]
		public string OrderSID { get; set; }
		[JsonProperty("product_iid")]
		public Nullable<int> ProductIID { get; set; }
		[JsonProperty("product_sid")]
		public string ProductSID { get; set; }
		[JsonProperty("quantity")]
		public Nullable<int> Quantity { get; set; }
		[JsonProperty("total_amount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount")]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
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
