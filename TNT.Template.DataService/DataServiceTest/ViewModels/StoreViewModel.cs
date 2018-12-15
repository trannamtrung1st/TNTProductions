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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("lat")]
		public string Lat { get; set; }
		[JsonProperty("lon")]
		public string Lon { get; set; }
		[JsonProperty("is_available")]
		public Nullable<bool> isAvailable { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("create_date")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("room_rent_mode")]
		public Nullable<int> RoomRentMode { get; set; }
		[JsonProperty("report_date")]
		public Nullable<DateTime> ReportDate { get; set; }
		[JsonProperty("short_name")]
		public string ShortName { get; set; }
		[JsonProperty("group_id")]
		public Nullable<int> GroupId { get; set; }
		[JsonProperty("open_time")]
		public Nullable<DateTime> OpenTime { get; set; }
		[JsonProperty("close_time")]
		public Nullable<DateTime> CloseTime { get; set; }
		[JsonProperty("default_admin_password")]
		public string DefaultAdminPassword { get; set; }
		[JsonProperty("has_products")]
		public Nullable<bool> HasProducts { get; set; }
		[JsonProperty("has_news")]
		public Nullable<bool> HasNews { get; set; }
		[JsonProperty("has_image_collections")]
		public Nullable<bool> HasImageCollections { get; set; }
		[JsonProperty("has_multiple_language")]
		public Nullable<bool> HasMultipleLanguage { get; set; }
		[JsonProperty("has_web_pages")]
		public Nullable<bool> HasWebPages { get; set; }
		[JsonProperty("has_customer_feedbacks")]
		public Nullable<bool> HasCustomerFeedbacks { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("has_order")]
		public Nullable<bool> HasOrder { get; set; }
		[JsonProperty("has_blog_edit_collections")]
		public Nullable<bool> HasBlogEditCollections { get; set; }
		[JsonProperty("logo_url")]
		public string LogoUrl { get; set; }
		[JsonProperty("fb_access_token")]
		public string FbAccessToken { get; set; }
		[JsonProperty("store_feature_filter")]
		public string StoreFeatureFilter { get; set; }
		[JsonProperty("run_report")]
		public Nullable<bool> RunReport { get; set; }
		[JsonProperty("attendance_store_filter")]
		public Nullable<int> AttendanceStoreFilter { get; set; }
		[JsonProperty("store_code")]
		public string StoreCode { get; set; }
		[JsonProperty("pos_id")]
		public Nullable<int> PosId { get; set; }
		[JsonProperty("store_config")]
		public string StoreConfig { get; set; }
		[JsonProperty("default_dash_board")]
		public string DefaultDashBoard { get; set; }
		[JsonProperty("district")]
		public string District { get; set; }
		[JsonProperty("province")]
		public string Province { get; set; }
		//[JsonProperty("brand")]
		//public BrandViewModel BrandVM { get; set; }
		//[JsonProperty("group")]
		//public GroupViewModel GroupVM { get; set; }
		//[JsonProperty("pos")]
		//public PosViewModel PosVM { get; set; }
		//[JsonProperty("articles")]
		//public IEnumerable<ArticleViewModel> ArticlesVM { get; set; }
		//[JsonProperty("asp_net_users")]
		//public IEnumerable<AspNetUserViewModel> AspNetUsersVM { get; set; }
		//[JsonProperty("attendances")]
		//public IEnumerable<AttendanceViewModel> AttendancesVM { get; set; }
		//[JsonProperty("attendance_dates")]
		//public IEnumerable<AttendanceDateViewModel> AttendanceDatesVM { get; set; }
		//[JsonProperty("blog_posts")]
		//public IEnumerable<BlogPostViewModel> BlogPostsVM { get; set; }
		//[JsonProperty("blog_post_collections")]
		//public IEnumerable<BlogPostCollectionViewModel> BlogPostCollectionsVM { get; set; }
		//[JsonProperty("costs")]
		//public IEnumerable<CostViewModel> CostsVM { get; set; }
		//[JsonProperty("coupons")]
		//public IEnumerable<CouponViewModel> CouponsVM { get; set; }
		//[JsonProperty("customer_store_report_mappings")]
		//public IEnumerable<CustomerStoreReportMappingViewModel> CustomerStoreReportMappingsVM { get; set; }
		//[JsonProperty("date_products")]
		//public IEnumerable<DateProductViewModel> DateProductsVM { get; set; }
		//[JsonProperty("date_product_items")]
		//public IEnumerable<DateProductItemViewModel> DateProductItemsVM { get; set; }
		//[JsonProperty("date_reports")]
		//public IEnumerable<DateReportViewModel> DateReportsVM { get; set; }
		//[JsonProperty("devices")]
		//public IEnumerable<DeviceViewModel> DevicesVM { get; set; }
		//[JsonProperty("employee_in_stores")]
		//public IEnumerable<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		//[JsonProperty("image_collections")]
		//public IEnumerable<ImageCollectionViewModel> ImageCollectionsVM { get; set; }
		//[JsonProperty("inventory_date_reports")]
		//public IEnumerable<InventoryDateReportViewModel> InventoryDateReportsVM { get; set; }
		//[JsonProperty("inventory_receipts")]
		//public IEnumerable<InventoryReceiptViewModel> InventoryReceiptsVM { get; set; }
		//[JsonProperty("inventory_receipts1")]
		//public IEnumerable<InventoryReceiptViewModel> InventoryReceipts1VM { get; set; }
		//[JsonProperty("inventory_receipts2")]
		//public IEnumerable<InventoryReceiptViewModel> InventoryReceipts2VM { get; set; }
		//[JsonProperty("languages")]
		//public IEnumerable<LanguageViewModel> LanguagesVM { get; set; }
		//[JsonProperty("language_keys")]
		//public IEnumerable<LanguageKeyViewModel> LanguageKeysVM { get; set; }
		//[JsonProperty("orders")]
		//public IEnumerable<OrderViewModel> OrdersVM { get; set; }
		//[JsonProperty("payment_reports")]
		//public IEnumerable<PaymentReportViewModel> PaymentReportsVM { get; set; }
		//[JsonProperty("product_collections")]
		//public IEnumerable<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		//[JsonProperty("product_detail_mappings")]
		//public IEnumerable<ProductDetailMappingViewModel> ProductDetailMappingsVM { get; set; }
		//[JsonProperty("promotion_store_mappings")]
		//public IEnumerable<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		//[JsonProperty("report_trackings")]
		//public IEnumerable<ReportTrackingViewModel> ReportTrackingsVM { get; set; }
		//[JsonProperty("room_categories")]
		//public IEnumerable<RoomCategoryViewModel> RoomCategoriesVM { get; set; }
		//[JsonProperty("store_domains")]
		//public IEnumerable<StoreDomainViewModel> StoreDomainsVM { get; set; }
		//[JsonProperty("store_group_mappings")]
		//public IEnumerable<StoreGroupMappingViewModel> StoreGroupMappingsVM { get; set; }
		//[JsonProperty("store_themes")]
		//public IEnumerable<StoreThemeViewModel> StoreThemesVM { get; set; }
		//[JsonProperty("store_users")]
		//public IEnumerable<StoreUserViewModel> StoreUsersVM { get; set; }
		//[JsonProperty("store_web_routes")]
		//public IEnumerable<StoreWebRouteViewModel> StoreWebRoutesVM { get; set; }
		//[JsonProperty("store_web_settings")]
		//public IEnumerable<StoreWebSettingViewModel> StoreWebSettingsVM { get; set; }
		//[JsonProperty("store_web_view_counters")]
		//public IEnumerable<StoreWebViewCounterViewModel> StoreWebViewCountersVM { get; set; }
		//[JsonProperty("view_counters")]
		//public IEnumerable<ViewCounterViewModel> ViewCountersVM { get; set; }
		//[JsonProperty("web_menu_categories")]
		//public IEnumerable<WebMenuCategoryViewModel> WebMenuCategoriesVM { get; set; }
		//[JsonProperty("web_pages")]
		//public IEnumerable<WebPageViewModel> WebPagesVM { get; set; }
		
		public StoreViewModel(Store entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreViewModel()
		{
			//this.ArticlesVM = new HashSet<ArticleViewModel>();
			//this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			//this.AttendancesVM = new HashSet<AttendanceViewModel>();
			//this.AttendanceDatesVM = new HashSet<AttendanceDateViewModel>();
			//this.BlogPostsVM = new HashSet<BlogPostViewModel>();
			//this.BlogPostCollectionsVM = new HashSet<BlogPostCollectionViewModel>();
			//this.CostsVM = new HashSet<CostViewModel>();
			//this.CouponsVM = new HashSet<CouponViewModel>();
			//this.CustomerStoreReportMappingsVM = new HashSet<CustomerStoreReportMappingViewModel>();
			//this.DateProductsVM = new HashSet<DateProductViewModel>();
			//this.DateProductItemsVM = new HashSet<DateProductItemViewModel>();
			//this.DateReportsVM = new HashSet<DateReportViewModel>();
			//this.DevicesVM = new HashSet<DeviceViewModel>();
			//this.EmployeeInStoresVM = new HashSet<EmployeeInStoreViewModel>();
			//this.ImageCollectionsVM = new HashSet<ImageCollectionViewModel>();
			//this.InventoryDateReportsVM = new HashSet<InventoryDateReportViewModel>();
			//this.InventoryReceiptsVM = new HashSet<InventoryReceiptViewModel>();
			//this.InventoryReceipts1VM = new HashSet<InventoryReceiptViewModel>();
			//this.InventoryReceipts2VM = new HashSet<InventoryReceiptViewModel>();
			//this.LanguagesVM = new HashSet<LanguageViewModel>();
			//this.LanguageKeysVM = new HashSet<LanguageKeyViewModel>();
			//this.OrdersVM = new HashSet<OrderViewModel>();
			//this.PaymentReportsVM = new HashSet<PaymentReportViewModel>();
			//this.ProductCollectionsVM = new HashSet<ProductCollectionViewModel>();
			//this.ProductDetailMappingsVM = new HashSet<ProductDetailMappingViewModel>();
			//this.PromotionStoreMappingsVM = new HashSet<PromotionStoreMappingViewModel>();
			//this.ReportTrackingsVM = new HashSet<ReportTrackingViewModel>();
			//this.RoomCategoriesVM = new HashSet<RoomCategoryViewModel>();
			//this.StoreDomainsVM = new HashSet<StoreDomainViewModel>();
			//this.StoreGroupMappingsVM = new HashSet<StoreGroupMappingViewModel>();
			//this.StoreThemesVM = new HashSet<StoreThemeViewModel>();
			//this.StoreUsersVM = new HashSet<StoreUserViewModel>();
			//this.StoreWebRoutesVM = new HashSet<StoreWebRouteViewModel>();
			//this.StoreWebSettingsVM = new HashSet<StoreWebSettingViewModel>();
			//this.StoreWebViewCountersVM = new HashSet<StoreWebViewCounterViewModel>();
			//this.ViewCountersVM = new HashSet<ViewCounterViewModel>();
			//this.WebMenuCategoriesVM = new HashSet<WebMenuCategoryViewModel>();
			//this.WebPagesVM = new HashSet<WebPageViewModel>();
		}
		
	}
}
