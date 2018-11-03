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
	public partial class ProductCategoryViewModel: BaseViewModel<ProductCategory>
	{
		[JsonProperty("cate_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CateID { get; set; }
		[JsonProperty("cate_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CateName { get; set; }
		[JsonProperty("cate_name_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CateNameEng { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("is_displayed", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDisplayed { get; set; }
		[JsonProperty("is_displayed_website", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDisplayedWebsite { get; set; }
		[JsonProperty("is_extra", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsExtra { get; set; }
		[JsonProperty("display_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DisplayOrder { get; set; }
		[JsonProperty("adjustment_note", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AdjustmentNote { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("seo_keyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoKeyword { get; set; }
		[JsonProperty("seo_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoDescription { get; set; }
		[JsonProperty("image_font_awsome_css", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parent_cate_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PicUrl { get; set; }
		[JsonProperty("banner_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BannerUrl { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("description_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DescriptionEng { get; set; }
		[JsonProperty("banner_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BannerDescription { get; set; }
		[JsonProperty("banner_description_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BannerDescriptionEng { get; set; }
		[JsonProperty("att1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att1 { get; set; }
		[JsonProperty("att2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att2 { get; set; }
		[JsonProperty("att3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att3 { get; set; }
		[JsonProperty("att4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att4 { get; set; }
		[JsonProperty("att5", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att5 { get; set; }
		[JsonProperty("att6", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att6 { get; set; }
		[JsonProperty("att7", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att7 { get; set; }
		[JsonProperty("att8", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att8 { get; set; }
		[JsonProperty("att9", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att9 { get; set; }
		[JsonProperty("att10", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att10 { get; set; }
		[JsonProperty("vat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> VAT { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("product_category2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCategoryViewModel ProductCategory2VM { get; set; }
		[JsonProperty("category_extra_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CategoryExtraMappingViewModel> CategoryExtraMappingsVM { get; set; }
		[JsonProperty("category_extra_mappings1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CategoryExtraMappingViewModel> CategoryExtraMappings1VM { get; set; }
		[JsonProperty("products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductViewModel> ProductsVM { get; set; }
		[JsonProperty("product_category1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCategoryViewModel> ProductCategory1VM { get; set; }
		
		public ProductCategoryViewModel(ProductCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductCategoryViewModel()
		{
			this.CategoryExtraMappingsVM = new HashSet<CategoryExtraMappingViewModel>();
			this.CategoryExtraMappings1VM = new HashSet<CategoryExtraMappingViewModel>();
			this.ProductsVM = new HashSet<ProductViewModel>();
			this.ProductCategory1VM = new HashSet<ProductCategoryViewModel>();
		}
		
	}
}
