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
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("nameEng")]
		public string NameEng { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("descriptionEng")]
		public string DescriptionEng { get; set; }
		[JsonProperty("sEO")]
		public string SEO { get; set; }
		[JsonProperty("sEODescription")]
		public string SEODescription { get; set; }
		[JsonProperty("sEOKeyword")]
		public string SEOKeyword { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("bannerUrl")]
		public string BannerUrl { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("productCollectionItemMappings")]
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
