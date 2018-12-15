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
		[JsonProperty("cate_id")]
		public int CateID { get; set; }
		[JsonProperty("cate_name")]
		public string CateName { get; set; }
		[JsonProperty("cate_name_eng")]
		public string CateNameEng { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("is_displayed")]
		public bool IsDisplayed { get; set; }
		[JsonProperty("is_displayed_website")]
		public bool IsDisplayedWebsite { get; set; }
		[JsonProperty("is_extra")]
		public bool IsExtra { get; set; }
		[JsonProperty("display_order")]
		public int DisplayOrder { get; set; }
		[JsonProperty("adjustment_note")]
		public string AdjustmentNote { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("seo_name")]
		public string SeoName { get; set; }
		[JsonProperty("seo_keyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("seo_description")]
		public string SeoDescription { get; set; }
		[JsonProperty("image_font_awsome_css")]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parent_cate_id")]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("pic_url")]
		public string PicUrl { get; set; }
		[JsonProperty("banner_url")]
		public string BannerUrl { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description_eng")]
		public string DescriptionEng { get; set; }
		[JsonProperty("banner_description")]
		public string BannerDescription { get; set; }
		[JsonProperty("banner_description_eng")]
		public string BannerDescriptionEng { get; set; }
		[JsonProperty("att1")]
		public string Att1 { get; set; }
		[JsonProperty("att2")]
		public string Att2 { get; set; }
		[JsonProperty("att3")]
		public string Att3 { get; set; }
		[JsonProperty("att4")]
		public string Att4 { get; set; }
		[JsonProperty("att5")]
		public string Att5 { get; set; }
		[JsonProperty("att6")]
		public string Att6 { get; set; }
		[JsonProperty("att7")]
		public string Att7 { get; set; }
		[JsonProperty("att8")]
		public string Att8 { get; set; }
		[JsonProperty("att9")]
		public string Att9 { get; set; }
		[JsonProperty("att10")]
		public string Att10 { get; set; }
		[JsonProperty("vat")]
		public Nullable<double> VAT { get; set; }
		//[JsonProperty("brand")]
		//public BrandViewModel BrandVM { get; set; }
		//[JsonProperty("product_category2")]
		//public ProductCategoryViewModel ProductCategory2VM { get; set; }
		//[JsonProperty("category_extra_mappings")]
		//public IEnumerable<CategoryExtraMappingViewModel> CategoryExtraMappingsVM { get; set; }
		//[JsonProperty("category_extra_mappings1")]
		//public IEnumerable<CategoryExtraMappingViewModel> CategoryExtraMappings1VM { get; set; }
		//[JsonProperty("products")]
		//public IEnumerable<ProductViewModel> ProductsVM { get; set; }
		//[JsonProperty("product_category1")]
		//public IEnumerable<ProductCategoryViewModel> ProductCategory1VM { get; set; }
		
		public ProductCategoryViewModel(ProductCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductCategoryViewModel()
		{
			//this.CategoryExtraMappingsVM = new HashSet<CategoryExtraMappingViewModel>();
			//this.CategoryExtraMappings1VM = new HashSet<CategoryExtraMappingViewModel>();
			//this.ProductsVM = new HashSet<ProductViewModel>();
			//this.ProductCategory1VM = new HashSet<ProductCategoryViewModel>();
		}
		
	}
}
