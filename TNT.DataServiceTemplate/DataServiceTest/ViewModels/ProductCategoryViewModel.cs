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
		[JsonProperty("cateID")]
		public int CateID { get; set; }
		[JsonProperty("cateName")]
		public string CateName { get; set; }
		[JsonProperty("cateNameEng")]
		public string CateNameEng { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("isDisplayed")]
		public bool IsDisplayed { get; set; }
		[JsonProperty("isDisplayedWebsite")]
		public bool IsDisplayedWebsite { get; set; }
		[JsonProperty("isExtra")]
		public bool IsExtra { get; set; }
		[JsonProperty("displayOrder")]
		public int DisplayOrder { get; set; }
		[JsonProperty("adjustmentNote")]
		public string AdjustmentNote { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("seoKeyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("seoDescription")]
		public string SeoDescription { get; set; }
		[JsonProperty("imageFontAwsomeCss")]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parentCateId")]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("picUrl")]
		public string PicUrl { get; set; }
		[JsonProperty("bannerUrl")]
		public string BannerUrl { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("descriptionEng")]
		public string DescriptionEng { get; set; }
		[JsonProperty("bannerDescription")]
		public string BannerDescription { get; set; }
		[JsonProperty("bannerDescriptionEng")]
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
		[JsonProperty("vAT")]
		public Nullable<double> VAT { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("productCategory2")]
		public ProductCategoryViewModel ProductCategory2VM { get; set; }
		[JsonProperty("categoryExtraMappings")]
		public ICollection<CategoryExtraMappingViewModel> CategoryExtraMappingsVM { get; set; }
		[JsonProperty("categoryExtraMappings1")]
		public ICollection<CategoryExtraMappingViewModel> CategoryExtraMappings1VM { get; set; }
		[JsonProperty("products")]
		public ICollection<ProductViewModel> ProductsVM { get; set; }
		[JsonProperty("productCategory1")]
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
