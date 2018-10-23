﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceTest.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class passioTestEntities : DbContext
    {
        public passioTestEntities()
            : base("name=passioTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<AreaDelivery> AreaDeliveries { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceDate> AttendanceDates { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<BlogPostCollection> BlogPostCollections { get; set; }
        public virtual DbSet<BlogPostCollectionItem> BlogPostCollectionItems { get; set; }
        public virtual DbSet<BlogPostCollectionItemMapping> BlogPostCollectionItemMappings { get; set; }
        public virtual DbSet<BlogPostImage> BlogPostImages { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CategoryExtra> CategoryExtras { get; set; }
        public virtual DbSet<CategoryExtraMapping> CategoryExtraMappings { get; set; }
        public virtual DbSet<CheckFinger> CheckFingers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<CostCategory> CostCategories { get; set; }
        public virtual DbSet<CostInventoryMapping> CostInventoryMappings { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponCampaign> CouponCampaigns { get; set; }
        public virtual DbSet<CouponProvider> CouponProviders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerFilter> CustomerFilters { get; set; }
        public virtual DbSet<CustomerProductMapping> CustomerProductMappings { get; set; }
        public virtual DbSet<CustomerStoreReportMapping> CustomerStoreReportMappings { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<DateHotelReport> DateHotelReports { get; set; }
        public virtual DbSet<DateProduct> DateProducts { get; set; }
        public virtual DbSet<DateProductItem> DateProductItems { get; set; }
        public virtual DbSet<DateReport> DateReports { get; set; }
        public virtual DbSet<DayMode> DayModes { get; set; }
        public virtual DbSet<DeliveryInfo> DeliveryInfoes { get; set; }
        public virtual DbSet<DeliveryInformation> DeliveryInformations { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeFinger> EmployeeFingers { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public virtual DbSet<EmployeeInStore> EmployeeInStores { get; set; }
        public virtual DbSet<EventLocation> EventLocations { get; set; }
        public virtual DbSet<Favorited> Favoriteds { get; set; }
        public virtual DbSet<FingerScanMachine> FingerScanMachines { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<ImageCollection> ImageCollections { get; set; }
        public virtual DbSet<ImageCollectionItem> ImageCollectionItems { get; set; }
        public virtual DbSet<InventoryChecking> InventoryCheckings { get; set; }
        public virtual DbSet<InventoryCheckingItem> InventoryCheckingItems { get; set; }
        public virtual DbSet<InventoryDateReport> InventoryDateReports { get; set; }
        public virtual DbSet<InventoryDateReportItem> InventoryDateReportItems { get; set; }
        public virtual DbSet<InventoryReceipt> InventoryReceipts { get; set; }
        public virtual DbSet<InventoryReceiptItem> InventoryReceiptItems { get; set; }
        public virtual DbSet<InventoryTemplateReport> InventoryTemplateReports { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageKey> LanguageKeys { get; set; }
        public virtual DbSet<LanguageValue> LanguageValues { get; set; }
        public virtual DbSet<MachineConnect> MachineConnects { get; set; }
        public virtual DbSet<MembershipCard> MembershipCards { get; set; }
        public virtual DbSet<MembershipCardType> MembershipCardTypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailPromotionMapping> OrderDetailPromotionMappings { get; set; }
        public virtual DbSet<OrderFeeItem> OrderFeeItems { get; set; }
        public virtual DbSet<OrderGroup> OrderGroups { get; set; }
        public virtual DbSet<OrderPromotionMapping> OrderPromotionMappings { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PartnerMapping> PartnerMappings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentPartner> PaymentPartners { get; set; }
        public virtual DbSet<PaymentReport> PaymentReports { get; set; }
        public virtual DbSet<PayrollCategory> PayrollCategories { get; set; }
        public virtual DbSet<PayrollDetail> PayrollDetails { get; set; }
        public virtual DbSet<PayrollPeriod> PayrollPeriods { get; set; }
        public virtual DbSet<PaySlip> PaySlips { get; set; }
        public virtual DbSet<PayslipAttribute> PayslipAttributes { get; set; }
        public virtual DbSet<PayslipAttributeMapping> PayslipAttributeMappings { get; set; }
        public virtual DbSet<PaySlipItem> PaySlipItems { get; set; }
        public virtual DbSet<PaySlipTemplate> PaySlipTemplates { get; set; }
        public virtual DbSet<Pos> Pos { get; set; }
        public virtual DbSet<PosConfig> PosConfigs { get; set; }
        public virtual DbSet<PosFile> PosFiles { get; set; }
        public virtual DbSet<PriceAddition> PriceAdditions { get; set; }
        public virtual DbSet<PriceGroup> PriceGroups { get; set; }
        public virtual DbSet<PriceNight> PriceNights { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
        public virtual DbSet<ProductCollectionItemMapping> ProductCollectionItemMappings { get; set; }
        public virtual DbSet<ProductComboDetail> ProductComboDetails { get; set; }
        public virtual DbSet<ProductDetailMapping> ProductDetailMappings { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductImageCollection> ProductImageCollections { get; set; }
        public virtual DbSet<ProductImageCollectionItemMapping> ProductImageCollectionItemMappings { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<ProductItemCategory> ProductItemCategories { get; set; }
        public virtual DbSet<ProductItemCompositionMapping> ProductItemCompositionMappings { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }
        public virtual DbSet<PromotionStoreMapping> PromotionStoreMappings { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderProductItemMapping> ProviderProductItemMappings { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RatingProduct> RatingProducts { get; set; }
        public virtual DbSet<RatingStar> RatingStars { get; set; }
        public virtual DbSet<ReportTracking> ReportTrackings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomCategory> RoomCategories { get; set; }
        public virtual DbSet<RoomCategoryPriceGroupMapping> RoomCategoryPriceGroupMappings { get; set; }
        public virtual DbSet<RoomFloor> RoomFloors { get; set; }
        public virtual DbSet<SalaryHour> SalaryHours { get; set; }
        public virtual DbSet<SalaryRule> SalaryRules { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreDomain> StoreDomains { get; set; }
        public virtual DbSet<StoreGroup> StoreGroups { get; set; }
        public virtual DbSet<StoreGroupMapping> StoreGroupMappings { get; set; }
        public virtual DbSet<StoreTheme> StoreThemes { get; set; }
        public virtual DbSet<StoreUser> StoreUsers { get; set; }
        public virtual DbSet<StoreWebRoute> StoreWebRoutes { get; set; }
        public virtual DbSet<StoreWebRouteModel> StoreWebRouteModels { get; set; }
        public virtual DbSet<StoreWebSetting> StoreWebSettings { get; set; }
        public virtual DbSet<StoreWebViewCounter> StoreWebViewCounters { get; set; }
        public virtual DbSet<SubRentGroup> SubRentGroups { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemPartnerMapping> SystemPartnerMappings { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagMapping> TagMappings { get; set; }
        public virtual DbSet<TemplateDetailMapping> TemplateDetailMappings { get; set; }
        public virtual DbSet<TemplateReportProductItemMapping> TemplateReportProductItemMappings { get; set; }
        public virtual DbSet<TemplateRuleMapping> TemplateRuleMappings { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<TimeFrame> TimeFrames { get; set; }
        public virtual DbSet<TimeModeRule> TimeModeRules { get; set; }
        public virtual DbSet<TimeModeType> TimeModeTypes { get; set; }
        public virtual DbSet<TokenUser> TokenUsers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VATOrder> VATOrders { get; set; }
        public virtual DbSet<VATOrderMapping> VATOrderMappings { get; set; }
        public virtual DbSet<ViewCounter> ViewCounters { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<WebCustomerFeedback> WebCustomerFeedbacks { get; set; }
        public virtual DbSet<WebElement> WebElements { get; set; }
        public virtual DbSet<WebElementType> WebElementTypes { get; set; }
        public virtual DbSet<WebMenu> WebMenus { get; set; }
        public virtual DbSet<WebMenuCategory> WebMenuCategories { get; set; }
        public virtual DbSet<WebPage> WebPages { get; set; }
        public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    }
}
