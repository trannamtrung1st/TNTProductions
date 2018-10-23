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
	public partial class ProductViewModel: BaseViewModel<Product>
	{
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("productName")]
		public string ProductName { get; set; }
		[JsonProperty("productNameEng")]
		public string ProductNameEng { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("picURL")]
		public string PicURL { get; set; }
		[JsonProperty("catID")]
		public int CatID { get; set; }
		[JsonProperty("isAvailable")]
		public bool IsAvailable { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("discountPercent")]
		public double DiscountPercent { get; set; }
		[JsonProperty("discountPrice")]
		public double DiscountPrice { get; set; }
		[JsonProperty("productType")]
		public int ProductType { get; set; }
		[JsonProperty("displayOrder")]
		public int DisplayOrder { get; set; }
		[JsonProperty("hasExtra")]
		public bool HasExtra { get; set; }
		[JsonProperty("isFixedPrice")]
		public bool IsFixedPrice { get; set; }
		[JsonProperty("posX")]
		public Nullable<int> PosX { get; set; }
		[JsonProperty("posY")]
		public Nullable<int> PosY { get; set; }
		[JsonProperty("colorGroup")]
		public Nullable<int> ColorGroup { get; set; }
		[JsonProperty("group")]
		public Nullable<int> Group { get; set; }
		[JsonProperty("groupId")]
		public Nullable<int> GroupId { get; set; }
		[JsonProperty("isMenuDisplay")]
		public Nullable<bool> IsMenuDisplay { get; set; }
		[JsonProperty("generalProductId")]
		public Nullable<int> GeneralProductId { get; set; }
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
		[JsonProperty("maxExtra")]
		public Nullable<int> MaxExtra { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("descriptionEng")]
		public string DescriptionEng { get; set; }
		[JsonProperty("introduction")]
		public string Introduction { get; set; }
		[JsonProperty("introductionEng")]
		public string IntroductionEng { get; set; }
		[JsonProperty("printGroup")]
		public Nullable<int> PrintGroup { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("isHomePage")]
		public Nullable<int> IsHomePage { get; set; }
		[JsonProperty("webContent")]
		public string WebContent { get; set; }
		[JsonProperty("seoKeyWords")]
		public string SeoKeyWords { get; set; }
		[JsonProperty("seoDescription")]
		public string SeoDescription { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("isDefaultChildProduct")]
		public int IsDefaultChildProduct { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("saleType")]
		public Nullable<int> SaleType { get; set; }
		[JsonProperty("isMostOrdered")]
		public bool IsMostOrdered { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("createTime")]
		public Nullable<DateTime> CreateTime { get; set; }
		[JsonProperty("ratingTotal")]
		public Nullable<int> RatingTotal { get; set; }
		[JsonProperty("numOfUserVoted")]
		public Nullable<int> NumOfUserVoted { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("group1")]
		public GroupViewModel Group1VM { get; set; }
		[JsonProperty("productCategory")]
		public ProductCategoryViewModel ProductCategoryVM { get; set; }
		[JsonProperty("customerProductMappings")]
		public ICollection<CustomerProductMappingViewModel> CustomerProductMappingsVM { get; set; }
		[JsonProperty("dateProducts")]
		public ICollection<DateProductViewModel> DateProductsVM { get; set; }
		[JsonProperty("favoriteds")]
		public ICollection<FavoritedViewModel> FavoritedsVM { get; set; }
		[JsonProperty("orderDetails")]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		[JsonProperty("productItemCompositionMappings")]
		public ICollection<ProductItemCompositionMappingViewModel> ProductItemCompositionMappingsVM { get; set; }
		[JsonProperty("productComboDetails")]
		public ICollection<ProductComboDetailViewModel> ProductComboDetailsVM { get; set; }
		[JsonProperty("productComboDetails1")]
		public ICollection<ProductComboDetailViewModel> ProductComboDetails1VM { get; set; }
		[JsonProperty("productCollectionItemMappings")]
		public ICollection<ProductCollectionItemMappingViewModel> ProductCollectionItemMappingsVM { get; set; }
		[JsonProperty("productDetailMappings")]
		public ICollection<ProductDetailMappingViewModel> ProductDetailMappingsVM { get; set; }
		[JsonProperty("productImages")]
		public ICollection<ProductImageViewModel> ProductImagesVM { get; set; }
		[JsonProperty("productSpecifications")]
		public ICollection<ProductSpecificationViewModel> ProductSpecificationsVM { get; set; }
		[JsonProperty("ratingProducts")]
		public ICollection<RatingProductViewModel> RatingProductsVM { get; set; }
		[JsonProperty("ratingStars")]
		public ICollection<RatingStarViewModel> RatingStarsVM { get; set; }
		
		public ProductViewModel(Product entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductViewModel()
		{
			this.CustomerProductMappingsVM = new HashSet<CustomerProductMappingViewModel>();
			this.DateProductsVM = new HashSet<DateProductViewModel>();
			this.FavoritedsVM = new HashSet<FavoritedViewModel>();
			this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
			this.ProductItemCompositionMappingsVM = new HashSet<ProductItemCompositionMappingViewModel>();
			this.ProductComboDetailsVM = new HashSet<ProductComboDetailViewModel>();
			this.ProductComboDetails1VM = new HashSet<ProductComboDetailViewModel>();
			this.ProductCollectionItemMappingsVM = new HashSet<ProductCollectionItemMappingViewModel>();
			this.ProductDetailMappingsVM = new HashSet<ProductDetailMappingViewModel>();
			this.ProductImagesVM = new HashSet<ProductImageViewModel>();
			this.ProductSpecificationsVM = new HashSet<ProductSpecificationViewModel>();
			this.RatingProductsVM = new HashSet<RatingProductViewModel>();
			this.RatingStarsVM = new HashSet<RatingStarViewModel>();
		}
		
	}
}
