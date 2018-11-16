using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Container;
using AutoMapper;
using System.Web;
using PromoterDataService.Models;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;

namespace PromoterDataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper;
		public static ITContainer TContainer;
		public static void DefaultConfigure()
		{
			ConfigureAutomapper();
			ConfigureIoContainer();
		}
		
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs { get; set; }
		= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<AffliatorCashbackDetail, AffliatorCashbackDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<AppAction, AppActionViewModel>().ReverseMap();
			//	cfg.CreateMap<Campaign, CampaignViewModel>().ReverseMap();
			//	cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerCashbackDetail, CustomerCashbackDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerSegment, CustomerSegmentViewModel>().ReverseMap();
			//	cfg.CreateMap<GiftAppliedDetail, GiftAppliedDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<GiftDetail, GiftDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
			//	cfg.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
			//	cfg.CreateMap<Partner, PartnerViewModel>().ReverseMap();
			//	cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
			//	cfg.CreateMap<Promotion, PromotionViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionAppliedDetail, PromotionAppliedDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionApplySituation, PromotionApplySituationViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionDetail, PromotionDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionStoreRule, PromotionStoreRuleViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionType, PromotionTypeViewModel>().ReverseMap();
			//	cfg.CreateMap<Redemption, RedemptionViewModel>().ReverseMap();
			//	cfg.CreateMap<RedemptionRollback, RedemptionRollbackViewModel>().ReverseMap();
			//	cfg.CreateMap<Segment, SegmentViewModel>().ReverseMap();
			//	cfg.CreateMap<Store, StoreViewModel>().ReverseMap();
			//	cfg.CreateMap<ValidationRule, ValidationRuleViewModel>().ReverseMap();
			//	cfg.CreateMap<Voucher, VoucherViewModel>().ReverseMap();
			//	cfg.CreateMap<VoucherConfig, VoucherConfigViewModel>().ReverseMap();
		//	}
		//};
		public static void AddMapperConfig(Action<IMapperConfigurationExpression> cfg)
		{
			MapperConfigs.Add(cfg);
		}
		private static void ConfigureAutomapper()
		{
			//AutoMapper
			var mapConfig = new MapperConfiguration(cfg =>
			{
				foreach (var c in MapperConfigs)
				{
					c.Invoke(cfg);
				}
			});
			G.Mapper = mapConfig.CreateMapper();
			
		}
		
		private static void ConfigureIoContainer()
		{
			//IoContainer
			G.TContainer = new TContainer();
			G.TContainer.RegisterRequestScopeHandlerModule();
			G.TContainer.RegisterType<IUnitOfWork, UnitOfWork>();
			G.TContainer.RegisterType<IAffliatorCashbackDetailRepository, AffliatorCashbackDetailRepository>();
			G.TContainer.RegisterType<IAppActionRepository, AppActionRepository>();
			G.TContainer.RegisterType<ICampaignRepository, CampaignRepository>();
			G.TContainer.RegisterType<ICustomerRepository, CustomerRepository>();
			G.TContainer.RegisterType<ICustomerCashbackDetailRepository, CustomerCashbackDetailRepository>();
			G.TContainer.RegisterType<ICustomerSegmentRepository, CustomerSegmentRepository>();
			G.TContainer.RegisterType<IGiftAppliedDetailRepository, GiftAppliedDetailRepository>();
			G.TContainer.RegisterType<IGiftDetailRepository, GiftDetailRepository>();
			G.TContainer.RegisterType<IOrderRepository, OrderRepository>();
			G.TContainer.RegisterType<IOrderItemRepository, OrderItemRepository>();
			G.TContainer.RegisterType<IPartnerRepository, PartnerRepository>();
			G.TContainer.RegisterType<IProductRepository, ProductRepository>();
			G.TContainer.RegisterType<IPromotionRepository, PromotionRepository>();
			G.TContainer.RegisterType<IPromotionAppliedDetailRepository, PromotionAppliedDetailRepository>();
			G.TContainer.RegisterType<IPromotionApplySituationRepository, PromotionApplySituationRepository>();
			G.TContainer.RegisterType<IPromotionDetailRepository, PromotionDetailRepository>();
			G.TContainer.RegisterType<IPromotionStoreRuleRepository, PromotionStoreRuleRepository>();
			G.TContainer.RegisterType<IPromotionTypeRepository, PromotionTypeRepository>();
			G.TContainer.RegisterType<IRedemptionRepository, RedemptionRepository>();
			G.TContainer.RegisterType<IRedemptionRollbackRepository, RedemptionRollbackRepository>();
			G.TContainer.RegisterType<ISegmentRepository, SegmentRepository>();
			G.TContainer.RegisterType<IStoreRepository, StoreRepository>();
			G.TContainer.RegisterType<IValidationRuleRepository, ValidationRuleRepository>();
			G.TContainer.RegisterType<IVoucherRepository, VoucherRepository>();
			G.TContainer.RegisterType<IVoucherConfigRepository, VoucherConfigRepository>();
			G.TContainer.RegisterType<IAffliatorCashbackDetailService, AffliatorCashbackDetailService>();
			G.TContainer.RegisterType<IAppActionService, AppActionService>();
			G.TContainer.RegisterType<ICampaignService, CampaignService>();
			G.TContainer.RegisterType<ICustomerService, CustomerService>();
			G.TContainer.RegisterType<ICustomerCashbackDetailService, CustomerCashbackDetailService>();
			G.TContainer.RegisterType<ICustomerSegmentService, CustomerSegmentService>();
			G.TContainer.RegisterType<IGiftAppliedDetailService, GiftAppliedDetailService>();
			G.TContainer.RegisterType<IGiftDetailService, GiftDetailService>();
			G.TContainer.RegisterType<IOrderService, OrderService>();
			G.TContainer.RegisterType<IOrderItemService, OrderItemService>();
			G.TContainer.RegisterType<IPartnerService, PartnerService>();
			G.TContainer.RegisterType<IProductService, ProductService>();
			G.TContainer.RegisterType<IPromotionService, PromotionService>();
			G.TContainer.RegisterType<IPromotionAppliedDetailService, PromotionAppliedDetailService>();
			G.TContainer.RegisterType<IPromotionApplySituationService, PromotionApplySituationService>();
			G.TContainer.RegisterType<IPromotionDetailService, PromotionDetailService>();
			G.TContainer.RegisterType<IPromotionStoreRuleService, PromotionStoreRuleService>();
			G.TContainer.RegisterType<IPromotionTypeService, PromotionTypeService>();
			G.TContainer.RegisterType<IRedemptionService, RedemptionService>();
			G.TContainer.RegisterType<IRedemptionRollbackService, RedemptionRollbackService>();
			G.TContainer.RegisterType<ISegmentService, SegmentService>();
			G.TContainer.RegisterType<IStoreService, StoreService>();
			G.TContainer.RegisterType<IValidationRuleService, ValidationRuleService>();
			G.TContainer.RegisterType<IVoucherService, VoucherService>();
			G.TContainer.RegisterType<IVoucherConfigService, VoucherConfigService>();
		}
		
	}
}
