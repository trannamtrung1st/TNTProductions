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
		= new List<Action<IMapperConfigurationExpression>>()
		{
			cfg =>
			{
				cfg.CreateMap<Models.Campaign, CampaignViewModel>().ReverseMap();
				cfg.CreateMap<Models.Customer, CustomerViewModel>().ReverseMap();
				cfg.CreateMap<Models.CustomerSegment, CustomerSegmentViewModel>().ReverseMap();
				cfg.CreateMap<Models.Event, EventViewModel>().ReverseMap();
				cfg.CreateMap<Models.Order, OrderViewModel>().ReverseMap();
				cfg.CreateMap<Models.OrderItem, OrderItemViewModel>().ReverseMap();
				cfg.CreateMap<Models.Product, ProductViewModel>().ReverseMap();
				cfg.CreateMap<Models.Promotion, PromotionViewModel>().ReverseMap();
				cfg.CreateMap<Models.PromotionAppliedDetail, PromotionAppliedDetailViewModel>().ReverseMap();
				cfg.CreateMap<Models.PromotionDetail, PromotionDetailViewModel>().ReverseMap();
				cfg.CreateMap<Models.Redemption, RedemptionViewModel>().ReverseMap();
				cfg.CreateMap<Models.RedemptionRollback, RedemptionRollbackViewModel>().ReverseMap();
				cfg.CreateMap<Models.Segment, SegmentViewModel>().ReverseMap();
				cfg.CreateMap<Models.Store, StoreViewModel>().ReverseMap();
				cfg.CreateMap<Models.ValidationRule, ValidationRuleViewModel>().ReverseMap();
				cfg.CreateMap<Models.Voucher, VoucherViewModel>().ReverseMap();
			}
		};
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
			G.TContainer.RegisterType<ICampaignRepository, CampaignRepository>();
			G.TContainer.RegisterType<ICustomerRepository, CustomerRepository>();
			G.TContainer.RegisterType<ICustomerSegmentRepository, CustomerSegmentRepository>();
			G.TContainer.RegisterType<IEventRepository, EventRepository>();
			G.TContainer.RegisterType<IOrderRepository, OrderRepository>();
			G.TContainer.RegisterType<IOrderItemRepository, OrderItemRepository>();
			G.TContainer.RegisterType<IProductRepository, ProductRepository>();
			G.TContainer.RegisterType<IPromotionRepository, PromotionRepository>();
			G.TContainer.RegisterType<IPromotionAppliedDetailRepository, PromotionAppliedDetailRepository>();
			G.TContainer.RegisterType<IPromotionDetailRepository, PromotionDetailRepository>();
			G.TContainer.RegisterType<IRedemptionRepository, RedemptionRepository>();
			G.TContainer.RegisterType<IRedemptionRollbackRepository, RedemptionRollbackRepository>();
			G.TContainer.RegisterType<ISegmentRepository, SegmentRepository>();
			G.TContainer.RegisterType<IStoreRepository, StoreRepository>();
			G.TContainer.RegisterType<IValidationRuleRepository, ValidationRuleRepository>();
			G.TContainer.RegisterType<IVoucherRepository, VoucherRepository>();
			G.TContainer.RegisterType<ICampaignService, CampaignService>();
			G.TContainer.RegisterType<ICustomerService, CustomerService>();
			G.TContainer.RegisterType<ICustomerSegmentService, CustomerSegmentService>();
			G.TContainer.RegisterType<IEventService, EventService>();
			G.TContainer.RegisterType<IOrderService, OrderService>();
			G.TContainer.RegisterType<IOrderItemService, OrderItemService>();
			G.TContainer.RegisterType<IProductService, ProductService>();
			G.TContainer.RegisterType<IPromotionService, PromotionService>();
			G.TContainer.RegisterType<IPromotionAppliedDetailService, PromotionAppliedDetailService>();
			G.TContainer.RegisterType<IPromotionDetailService, PromotionDetailService>();
			G.TContainer.RegisterType<IRedemptionService, RedemptionService>();
			G.TContainer.RegisterType<IRedemptionRollbackService, RedemptionRollbackService>();
			G.TContainer.RegisterType<ISegmentService, SegmentService>();
			G.TContainer.RegisterType<IStoreService, StoreService>();
			G.TContainer.RegisterType<IValidationRuleService, ValidationRuleService>();
			G.TContainer.RegisterType<IVoucherService, VoucherService>();
		}
		
	}
}
