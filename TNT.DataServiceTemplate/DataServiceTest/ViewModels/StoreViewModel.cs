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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("lat")]
		public string Lat { get; set; }
		[JsonProperty("lon")]
		public string Lon { get; set; }
		[JsonProperty("isAvailable")]
		public Nullable<bool> isAvailable { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("createDate")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("roomRentMode")]
		public Nullable<int> RoomRentMode { get; set; }
		[JsonProperty("reportDate")]
		public Nullable<DateTime> ReportDate { get; set; }
		[JsonProperty("shortName")]
		public string ShortName { get; set; }
		[JsonProperty("groupId")]
		public Nullable<int> GroupId { get; set; }
		[JsonProperty("openTime")]
		public Nullable<DateTime> OpenTime { get; set; }
		[JsonProperty("closeTime")]
		public Nullable<DateTime> CloseTime { get; set; }
		[JsonProperty("defaultAdminPassword")]
		public string DefaultAdminPassword { get; set; }
		[JsonProperty("hasProducts")]
		public Nullable<bool> HasProducts { get; set; }
		[JsonProperty("hasNews")]
		public Nullable<bool> HasNews { get; set; }
		[JsonProperty("hasImageCollections")]
		public Nullable<bool> HasImageCollections { get; set; }
		[JsonProperty("hasMultipleLanguage")]
		public Nullable<bool> HasMultipleLanguage { get; set; }
		[JsonProperty("hasWebPages")]
		public Nullable<bool> HasWebPages { get; set; }
		[JsonProperty("hasCustomerFeedbacks")]
		public Nullable<bool> HasCustomerFeedbacks { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("hasOrder")]
		public Nullable<bool> HasOrder { get; set; }
		[JsonProperty("hasBlogEditCollections")]
		public Nullable<bool> HasBlogEditCollections { get; set; }
		[JsonProperty("logoUrl")]
		public string LogoUrl { get; set; }
		[JsonProperty("fbAccessToken")]
		public string FbAccessToken { get; set; }
		[JsonProperty("storeFeatureFilter")]
		public string StoreFeatureFilter { get; set; }
		[JsonProperty("runReport")]
		public Nullable<bool> RunReport { get; set; }
		[JsonProperty("attendanceStoreFilter")]
		public Nullable<int> AttendanceStoreFilter { get; set; }
		[JsonProperty("storeCode")]
		public string StoreCode { get; set; }
		[JsonProperty("posId")]
		public Nullable<int> PosId { get; set; }
		[JsonProperty("storeConfig")]
		public string StoreConfig { get; set; }
		[JsonProperty("defaultDashBoard")]
		public string DefaultDashBoard { get; set; }
		[JsonProperty("district")]
		public string District { get; set; }
		[JsonProperty("province")]
		public string Province { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("group")]
		public GroupViewModel GroupVM { get; set; }
		[JsonProperty("pos")]
		public PosViewModel PosVM { get; set; }
		[JsonProperty("articles")]
		public ICollection<ArticleViewModel> ArticlesVM { get; set; }
		[JsonProperty("aspNetUsers")]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("attendances")]
		public ICollection<AttendanceViewModel> AttendancesVM { get; set; }
		[JsonProperty("attendanceDates")]
		public ICollection<AttendanceDateViewModel> AttendanceDatesVM { get; set; }
		[JsonProperty("blogPosts")]
		public ICollection<BlogPostViewModel> BlogPostsVM { get; set; }
		[JsonProperty("blogPostCollections")]
		public ICollection<BlogPostCollectionViewModel> BlogPostCollectionsVM { get; set; }
		[JsonProperty("costs")]
		public ICollection<CostViewModel> CostsVM { get; set; }
		[JsonProperty("coupons")]
		public ICollection<CouponViewModel> CouponsVM { get; set; }
		[JsonProperty("customerStoreReportMappings")]
		public ICollection<CustomerStoreReportMappingViewModel> CustomerStoreReportMappingsVM { get; set; }
		[JsonProperty("dateProducts")]
		public ICollection<DateProductViewModel> DateProductsVM { get; set; }
		[JsonProperty("dateProductItems")]
		public ICollection<DateProductItemViewModel> DateProductItemsVM { get; set; }
		[JsonProperty("dateReports")]
		public ICollection<DateReportViewModel> DateReportsVM { get; set; }
		[JsonProperty("devices")]
		public ICollection<DeviceViewModel> DevicesVM { get; set; }
		[JsonProperty("employeeInStores")]
		public ICollection<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		[JsonProperty("imageCollections")]
		public ICollection<ImageCollectionViewModel> ImageCollectionsVM { get; set; }
		[JsonProperty("inventoryDateReports")]
		public ICollection<InventoryDateReportViewModel> InventoryDateReportsVM { get; set; }
		[JsonProperty("inventoryReceipts")]
		public ICollection<InventoryReceiptViewModel> InventoryReceiptsVM { get; set; }
		[JsonProperty("inventoryReceipts1")]
		public ICollection<InventoryReceiptViewModel> InventoryReceipts1VM { get; set; }
		[JsonProperty("inventoryReceipts2")]
		public ICollection<InventoryReceiptViewModel> InventoryReceipts2VM { get; set; }
		[JsonProperty("languages")]
		public ICollection<LanguageViewModel> LanguagesVM { get; set; }
		[JsonProperty("languageKeys")]
		public ICollection<LanguageKeyViewModel> LanguageKeysVM { get; set; }
		[JsonProperty("orders")]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("paymentReports")]
		public ICollection<PaymentReportViewModel> PaymentReportsVM { get; set; }
		[JsonProperty("productCollections")]
		public ICollection<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		[JsonProperty("productDetailMappings")]
		public ICollection<ProductDetailMappingViewModel> ProductDetailMappingsVM { get; set; }
		[JsonProperty("promotionStoreMappings")]
		public ICollection<PromotionStoreMappingViewModel> PromotionStoreMappingsVM { get; set; }
		[JsonProperty("reportTrackings")]
		public ICollection<ReportTrackingViewModel> ReportTrackingsVM { get; set; }
		[JsonProperty("roomCategories")]
		public ICollection<RoomCategoryViewModel> RoomCategoriesVM { get; set; }
		[JsonProperty("storeDomains")]
		public ICollection<StoreDomainViewModel> StoreDomainsVM { get; set; }
		[JsonProperty("storeGroupMappings")]
		public ICollection<StoreGroupMappingViewModel> StoreGroupMappingsVM { get; set; }
		[JsonProperty("storeThemes")]
		public ICollection<StoreThemeViewModel> StoreThemesVM { get; set; }
		[JsonProperty("storeUsers")]
		public ICollection<StoreUserViewModel> StoreUsersVM { get; set; }
		[JsonProperty("storeWebRoutes")]
		public ICollection<StoreWebRouteViewModel> StoreWebRoutesVM { get; set; }
		[JsonProperty("storeWebSettings")]
		public ICollection<StoreWebSettingViewModel> StoreWebSettingsVM { get; set; }
		[JsonProperty("storeWebViewCounters")]
		public ICollection<StoreWebViewCounterViewModel> StoreWebViewCountersVM { get; set; }
		[JsonProperty("viewCounters")]
		public ICollection<ViewCounterViewModel> ViewCountersVM { get; set; }
		[JsonProperty("webMenuCategories")]
		public ICollection<WebMenuCategoryViewModel> WebMenuCategoriesVM { get; set; }
		[JsonProperty("webPages")]
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
