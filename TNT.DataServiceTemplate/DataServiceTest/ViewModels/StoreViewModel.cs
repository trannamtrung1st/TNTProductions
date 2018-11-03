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
	public partial class StoreViewModel: BaseViewModel<Store>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("lat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Lat { get; set; }
		[JsonProperty("lon", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Lon { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> isAvailable { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("room_rent_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RoomRentMode { get; set; }
		[JsonProperty("report_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ReportDate { get; set; }
		[JsonProperty("short_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ShortName { get; set; }
		[JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GroupId { get; set; }
		[JsonProperty("open_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> OpenTime { get; set; }
		[JsonProperty("close_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CloseTime { get; set; }
		[JsonProperty("default_admin_password", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DefaultAdminPassword { get; set; }
		[JsonProperty("has_products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasProducts { get; set; }
		[JsonProperty("has_news", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasNews { get; set; }
		[JsonProperty("has_image_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasImageCollections { get; set; }
		[JsonProperty("has_multiple_language", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasMultipleLanguage { get; set; }
		[JsonProperty("has_web_pages", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasWebPages { get; set; }
		[JsonProperty("has_customer_feedbacks", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasCustomerFeedbacks { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("has_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasOrder { get; set; }
		[JsonProperty("has_blog_edit_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> HasBlogEditCollections { get; set; }
		[JsonProperty("logo_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LogoUrl { get; set; }
		[JsonProperty("fb_access_token", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FbAccessToken { get; set; }
		[JsonProperty("store_feature_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreFeatureFilter { get; set; }
		[JsonProperty("run_report", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> RunReport { get; set; }
		[JsonProperty("attendance_store_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AttendanceStoreFilter { get; set; }
		[JsonProperty("store_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreCode { get; set; }
		[JsonProperty("pos_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PosId { get; set; }
		[JsonProperty("store_config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreConfig { get; set; }
		[JsonProperty("default_dash_board", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DefaultDashBoard { get; set; }
		[JsonProperty("district", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string District { get; set; }
		[JsonProperty("province", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Province { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public GroupViewModel GroupVM { get; set; }
		[JsonProperty("pos", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PosViewModel PosVM { get; set; }
		[JsonProperty("articles", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ArticleViewModel> ArticlesVM { get; set; }
		[JsonProperty("asp_net_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("attendances", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AttendanceViewModel> AttendancesVM { get; set; }
		[JsonProperty("attendance_dates", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AttendanceDateViewModel> AttendanceDatesVM { get; set; }
		[JsonProperty("blog_posts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostViewModel> BlogPostsVM { get; set; }
		[JsonProperty("blog_post_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostCollectionViewModel> BlogPostCollectionsVM { get; set; }
		[JsonProperty("costs", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CostViewModel> CostsVM { get; set; }
		[JsonProperty("coupons", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CouponViewModel> CouponsVM { get; set; }
		[JsonProperty("customer_store_report_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerStoreReportMappingViewModel> CustomerStoreReportMappingsVM { get; set; }
		[JsonProperty("date_products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DateProductViewModel> DateProductsVM { get; set; }
		[JsonProperty("date_product_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DateProductItemViewModel> DateProductItemsVM { get; set; }
		[JsonProperty("date_reports", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DateReportViewModel> DateReportsVM { get; set; }
		[JsonProperty("devices", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeviceViewModel> DevicesVM { get; set; }
		[JsonProperty("employee_in_stores", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		[JsonProperty("image_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ImageCollectionViewModel> ImageCollectionsVM { get; set; }
		[JsonProperty("inventory_date_reports", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryDateReportViewModel> InventoryDateReportsVM { get; set; }
		[JsonProperty("inventory_receipts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptViewModel> InventoryReceiptsVM { get; set; }
		[JsonProperty("inventory_receipts1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptViewModel> InventoryReceipts1VM { get; set; }
		[JsonProperty("inventory_receipts2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptViewModel> InventoryReceipts2VM { get; set; }
		[JsonProperty("languages", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<LanguageViewModel> LanguagesVM { get; set; }
		[JsonProperty("language_keys", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<LanguageKeyViewModel> LanguageKeysVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("payment_reports", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaymentReportViewModel> PaymentReportsVM { get; set; }
		[JsonProperty("product_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		[JsonProperty("product_detail_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductDetailMappingViewModel> ProductDetailMappingsVM { get; set; }
		[JsonProperty("promotion_store_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		[JsonProperty("report_trackings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ReportTrackingViewModel> ReportTrackingsVM { get; set; }
		[JsonProperty("room_categories", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoomCategoryViewModel> RoomCategoriesVM { get; set; }
		[JsonProperty("store_domains", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreDomainViewModel> StoreDomainsVM { get; set; }
		[JsonProperty("store_group_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreGroupMappingViewModel> StoreGroupMappingsVM { get; set; }
		[JsonProperty("store_themes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreThemeViewModel> StoreThemesVM { get; set; }
		[JsonProperty("store_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreUserViewModel> StoreUsersVM { get; set; }
		[JsonProperty("store_web_routes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreWebRouteViewModel> StoreWebRoutesVM { get; set; }
		[JsonProperty("store_web_settings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreWebSettingViewModel> StoreWebSettingsVM { get; set; }
		[JsonProperty("store_web_view_counters", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreWebViewCounterViewModel> StoreWebViewCountersVM { get; set; }
		[JsonProperty("view_counters", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ViewCounterViewModel> ViewCountersVM { get; set; }
		[JsonProperty("web_menu_categories", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<WebMenuCategoryViewModel> WebMenuCategoriesVM { get; set; }
		[JsonProperty("web_pages", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<WebPageViewModel> WebPagesVM { get; set; }
		
		public StoreViewModel(Store entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreViewModel()
		{
			this.ArticlesVM = new HashSet<ArticleViewModel>();
			this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			this.AttendancesVM = new HashSet<AttendanceViewModel>();
			this.AttendanceDatesVM = new HashSet<AttendanceDateViewModel>();
			this.BlogPostsVM = new HashSet<BlogPostViewModel>();
			this.BlogPostCollectionsVM = new HashSet<BlogPostCollectionViewModel>();
			this.CostsVM = new HashSet<CostViewModel>();
			this.CouponsVM = new HashSet<CouponViewModel>();
			this.CustomerStoreReportMappingsVM = new HashSet<CustomerStoreReportMappingViewModel>();
			this.DateProductsVM = new HashSet<DateProductViewModel>();
			this.DateProductItemsVM = new HashSet<DateProductItemViewModel>();
			this.DateReportsVM = new HashSet<DateReportViewModel>();
			this.DevicesVM = new HashSet<DeviceViewModel>();
			this.EmployeeInStoresVM = new HashSet<EmployeeInStoreViewModel>();
			this.ImageCollectionsVM = new HashSet<ImageCollectionViewModel>();
			this.InventoryDateReportsVM = new HashSet<InventoryDateReportViewModel>();
			this.InventoryReceiptsVM = new HashSet<InventoryReceiptViewModel>();
			this.InventoryReceipts1VM = new HashSet<InventoryReceiptViewModel>();
			this.InventoryReceipts2VM = new HashSet<InventoryReceiptViewModel>();
			this.LanguagesVM = new HashSet<LanguageViewModel>();
			this.LanguageKeysVM = new HashSet<LanguageKeyViewModel>();
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.PaymentReportsVM = new HashSet<PaymentReportViewModel>();
			this.ProductCollectionsVM = new HashSet<ProductCollectionViewModel>();
			this.ProductDetailMappingsVM = new HashSet<ProductDetailMappingViewModel>();
			this.PromotionStoreMappingsVM = new HashSet<PromotionStoreMappingViewModel>();
			this.ReportTrackingsVM = new HashSet<ReportTrackingViewModel>();
			this.RoomCategoriesVM = new HashSet<RoomCategoryViewModel>();
			this.StoreDomainsVM = new HashSet<StoreDomainViewModel>();
			this.StoreGroupMappingsVM = new HashSet<StoreGroupMappingViewModel>();
			this.StoreThemesVM = new HashSet<StoreThemeViewModel>();
			this.StoreUsersVM = new HashSet<StoreUserViewModel>();
			this.StoreWebRoutesVM = new HashSet<StoreWebRouteViewModel>();
			this.StoreWebSettingsVM = new HashSet<StoreWebSettingViewModel>();
			this.StoreWebViewCountersVM = new HashSet<StoreWebViewCounterViewModel>();
			this.ViewCountersVM = new HashSet<ViewCounterViewModel>();
			this.WebMenuCategoriesVM = new HashSet<WebMenuCategoryViewModel>();
			this.WebPagesVM = new HashSet<WebPageViewModel>();
		}
		
	}
}
