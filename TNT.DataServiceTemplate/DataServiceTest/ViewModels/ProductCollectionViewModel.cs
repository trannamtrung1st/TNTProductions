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
	public partial class ProductCollectionViewModel: BaseViewModel<ProductCollection>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("name_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NameEng { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("description_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DescriptionEng { get; set; }
		[JsonProperty("seo", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SEO { get; set; }
		[JsonProperty("seodescription", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SEODescription { get; set; }
		[JsonProperty("seokeyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SEOKeyword { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("banner_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BannerUrl { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("product_collection_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCollectionItemMappingViewModel> ProductCollectionItemMappingsVM { get; set; }
		
		public ProductCollectionViewModel(ProductCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductCollectionViewModel()
		{
			this.ProductCollectionItemMappingsVM = new HashSet<ProductCollectionItemMappingViewModel>();
		}
		
	}
}
