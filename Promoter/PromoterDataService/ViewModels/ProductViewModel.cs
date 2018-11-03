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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("parent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("smallest_unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SmallestUnit { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Price { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("product2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel Product2VM { get; set; }
		[JsonProperty("gift_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<GiftAppliedDetailViewModel> GiftAppliedDetailsVM { get; set; }
		[JsonProperty("gift_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<GiftDetailViewModel> GiftDetailsVM { get; set; }
		[JsonProperty("order_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderItemViewModel> OrderItemsVM { get; set; }
		[JsonProperty("product1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductViewModel> Product1VM { get; set; }
		
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
