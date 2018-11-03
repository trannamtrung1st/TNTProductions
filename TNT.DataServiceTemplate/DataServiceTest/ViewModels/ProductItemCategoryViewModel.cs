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
	public partial class ProductItemCategoryViewModel: BaseViewModel<ProductItemCategory>
	{
		[JsonProperty("cate_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CateID { get; set; }
		[JsonProperty("cate_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CateName { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductItemViewModel> ProductItemsVM { get; set; }
		
		public ProductItemCategoryViewModel(ProductItemCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductItemCategoryViewModel()
		{
			this.ProductItemsVM = new HashSet<ProductItemViewModel>();
		}
		
	}
}
