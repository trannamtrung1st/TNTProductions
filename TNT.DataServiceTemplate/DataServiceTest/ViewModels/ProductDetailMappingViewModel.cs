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
	public partial class ProductDetailMappingViewModel: BaseViewModel<ProductDetailMapping>
	{
		[JsonProperty("product_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductDetailID { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Price { get; set; }
		[JsonProperty("discount_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountPrice { get; set; }
		[JsonProperty("discount_percent", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountPercent { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public ProductDetailMappingViewModel(ProductDetailMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductDetailMappingViewModel()
		{
		}
		
	}
}
