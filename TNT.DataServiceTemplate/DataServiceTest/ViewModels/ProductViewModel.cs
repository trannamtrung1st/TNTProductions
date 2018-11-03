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
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductID { get; set; }
		[JsonProperty("product_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductName { get; set; }
		[JsonProperty("product_name_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductNameEng { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Price { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PicURL { get; set; }
		[JsonProperty("cat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CatID { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAvailable { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("discount_percent", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DiscountPercent { get; set; }
		[JsonProperty("discount_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DiscountPrice { get; set; }
		[JsonProperty("product_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductType { get; set; }
		[JsonProperty("display_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DisplayOrder { get; set; }
		[JsonProperty("has_extra", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool HasExtra { get; set; }
		[JsonProperty("is_fixed_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsFixedPrice { get; set; }
		[JsonProperty("pos_x", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PosX { get; set; }
		[JsonProperty("pos_y", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PosY { get; set; }
		[JsonProperty("color_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ColorGroup { get; set; }
		[JsonProperty("group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Group { get; set; }
		[JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GroupId { get; set; }
		[JsonProperty("is_menu_display", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsMenuDisplay { get; set; }
		[JsonProperty("general_product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GeneralProductId { get; set; }
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
		[JsonProperty("max_extra", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxExtra { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("description_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DescriptionEng { get; set; }
		[JsonProperty("introduction", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Introduction { get; set; }
		[JsonProperty("introduction_eng", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IntroductionEng { get; set; }
		[JsonProperty("print_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PrintGroup { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("is_home_page", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> IsHomePage { get; set; }
		[JsonProperty("web_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string WebContent { get; set; }
		[JsonProperty("seo_key_words", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoKeyWords { get; set; }
		[JsonProperty("seo_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoDescription { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("is_default_child_product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IsDefaultChildProduct { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Position { get; set; }
		[JsonProperty("sale_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SaleType { get; set; }
		[JsonProperty("is_most_ordered", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsMostOrdered { get; set; }
		[JsonProperty("note", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Note { get; set; }
		[JsonProperty("create_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateTime { get; set; }
		[JsonProperty("rating_total", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RatingTotal { get; set; }
		[JsonProperty("num_of_user_voted", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> NumOfUserVoted { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("group1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public GroupViewModel Group1VM { get; set; }
		[JsonProperty("product_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCategoryViewModel ProductCategoryVM { get; set; }
		[JsonProperty("customer_product_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerProductMappingViewModel> CustomerProductMappingsVM { get; set; }
		[JsonProperty("date_products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DateProductViewModel> DateProductsVM { get; set; }
		[JsonProperty("favoriteds", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<FavoritedViewModel> FavoritedsVM { get; set; }
		[JsonProperty("order_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		[JsonProperty("product_item_composition_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductItemCompositionMappingViewModel> ProductItemCompositionMappingsVM { get; set; }
		[JsonProperty("product_combo_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductComboDetailViewModel> ProductComboDetailsVM { get; set; }
		[JsonProperty("product_combo_details1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductComboDetailViewModel> ProductComboDetails1VM { get; set; }
		[JsonProperty("product_collection_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCollectionItemMappingViewModel> ProductCollectionItemMappingsVM { get; set; }
		[JsonProperty("product_detail_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductDetailMappingViewModel> ProductDetailMappingsVM { get; set; }
		[JsonProperty("product_images", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductImageViewModel> ProductImagesVM { get; set; }
		[JsonProperty("product_specifications", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductSpecificationViewModel> ProductSpecificationsVM { get; set; }
		[JsonProperty("rating_products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RatingProductViewModel> RatingProductsVM { get; set; }
		[JsonProperty("rating_stars", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
