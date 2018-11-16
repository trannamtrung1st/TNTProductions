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
	public partial class ProductViewModel: BaseViewModel<Product>
	{
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("parent_id")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("smallest_unit")]
		public string SmallestUnit { get; set; }
		[JsonProperty("price")]
		public Nullable<double> Price { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("product2")]
		public ProductViewModel Product2VM { get; set; }
		[JsonProperty("gift_applied_details")]
		public IEnumerable<GiftAppliedDetailViewModel> GiftAppliedDetailsVM { get; set; }
		[JsonProperty("gift_details")]
		public IEnumerable<GiftDetailViewModel> GiftDetailsVM { get; set; }
		[JsonProperty("order_items")]
		public IEnumerable<OrderItemViewModel> OrderItemsVM { get; set; }
		[JsonProperty("product1")]
		public IEnumerable<ProductViewModel> Product1VM { get; set; }
		
		public ProductViewModel(Product entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductViewModel()
		{
			this.GiftAppliedDetailsVM = new HashSet<GiftAppliedDetailViewModel>();
			this.GiftDetailsVM = new HashSet<GiftDetailViewModel>();
			this.OrderItemsVM = new HashSet<OrderItemViewModel>();
			this.Product1VM = new HashSet<ProductViewModel>();
		}
		
	}
}
