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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("name_eng")]
		public string NameEng { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description_eng")]
		public string DescriptionEng { get; set; }
		[JsonProperty("seo")]
		public string SEO { get; set; }
		[JsonProperty("seodescription")]
		public string SEODescription { get; set; }
		[JsonProperty("seokeyword")]
		public string SEOKeyword { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("banner_url")]
		public string BannerUrl { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		//[JsonProperty("brand")]
		//public BrandViewModel BrandVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("product_collection_item_mappings")]
		//public IEnumerable<ProductCollectionItemMappingViewModel> ProductCollectionItemMappingsVM { get; set; }
		
		public ProductCollectionViewModel(ProductCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductCollectionViewModel()
		{
			//this.ProductCollectionItemMappingsVM = new HashSet<ProductCollectionItemMappingViewModel>();
		}
		
	}
}
