using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Container;
using AutoMapper;
using System.Web;
using Promoter.DataService.Models;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Models.Services;
using Promoter.DataService.Managers;
using Promoter.DataService.ViewModels;

namespace Promoter.DataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper;
		public static ITContainer TContainer;
		private static ITContainerBuilder Builder = new TContainerBuilder();
		private static void DefaultConfigure()
		{
			ConfigureAutomapper();
			ConfigureIoContainer();
		}
		
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<PC_DateTimeFilter, PC_DateTimeFilterViewModel>().ReverseMap();
			//	cfg.CreateMap<PC_ProductFilter, PC_ProductFilterViewModel>().ReverseMap();
			//	cfg.CreateMap<PC_StoreFilter, PC_StoreFilterViewModel>().ReverseMap();
			//	cfg.CreateMap<Promotion, PromotionViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionAwardCashback, PromotionAwardCashbackViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionAwardDiscount, PromotionAwardDiscountViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionAwardGift, PromotionAwardGiftViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionConstraint, PromotionConstraintViewModel>().ReverseMap();
			//	cfg.CreateMap<PromotionDetail, PromotionDetailViewModel>().ReverseMap();
			//	cfg.CreateMap<Voucher, VoucherViewModel>().ReverseMap();
		//	}
		//};
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
			Builder.RegisterRequestScopeHandlerModule();
			Builder.RegisterType<IUnitOfWork, UnitOfWork>();
			Builder.RegisterType<PromoterEntities>();
			Builder.RegisterType<IPC_DateTimeFilterRepository, PC_DateTimeFilterRepository>();
			Builder.RegisterType<IPC_ProductFilterRepository, PC_ProductFilterRepository>();
			Builder.RegisterType<IPC_StoreFilterRepository, PC_StoreFilterRepository>();
			Builder.RegisterType<IPromotionRepository, PromotionRepository>();
			Builder.RegisterType<IPromotionAwardCashbackRepository, PromotionAwardCashbackRepository>();
			Builder.RegisterType<IPromotionAwardDiscountRepository, PromotionAwardDiscountRepository>();
			Builder.RegisterType<IPromotionAwardGiftRepository, PromotionAwardGiftRepository>();
			Builder.RegisterType<IPromotionConstraintRepository, PromotionConstraintRepository>();
			Builder.RegisterType<IPromotionDetailRepository, PromotionDetailRepository>();
			Builder.RegisterType<IVoucherRepository, VoucherRepository>();
			Builder.RegisterType<IPC_DateTimeFilterService, PC_DateTimeFilterService>();
			Builder.RegisterType<IPC_ProductFilterService, PC_ProductFilterService>();
			Builder.RegisterType<IPC_StoreFilterService, PC_StoreFilterService>();
			Builder.RegisterType<IPromotionService, PromotionService>();
			Builder.RegisterType<IPromotionAwardCashbackService, PromotionAwardCashbackService>();
			Builder.RegisterType<IPromotionAwardDiscountService, PromotionAwardDiscountService>();
			Builder.RegisterType<IPromotionAwardGiftService, PromotionAwardGiftService>();
			Builder.RegisterType<IPromotionConstraintService, PromotionConstraintService>();
			Builder.RegisterType<IPromotionDetailService, PromotionDetailService>();
			Builder.RegisterType<IVoucherService, VoucherService>();
			G.TContainer = Builder.Build();
		}
		
	}
}
