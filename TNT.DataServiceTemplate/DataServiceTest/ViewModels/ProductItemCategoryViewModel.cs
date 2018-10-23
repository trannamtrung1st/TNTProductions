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
		[JsonProperty("cateID")]
		public int CateID { get; set; }
		[JsonProperty("cateName")]
		public string CateName { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("productItems")]
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
