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
			//	cfg.CreateMap<Brand, BrandViewModel>().ReverseMap();
			//	cfg.CreateMap<BrandAccount, BrandAccountViewModel>().ReverseMap();
			//	cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
			//	cfg.CreateMap<Membership, MembershipViewModel>().ReverseMap();
			//	cfg.CreateMap<MembershipAccount, MembershipAccountViewModel>().ReverseMap();
			//	cfg.CreateMap<MembershipCard, MembershipCardViewModel>().ReverseMap();
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
			Builder.RegisterType<IBrandRepository, BrandRepository>();
			Builder.RegisterType<IBrandAccountRepository, BrandAccountRepository>();
			Builder.RegisterType<ICustomerRepository, CustomerRepository>();
			Builder.RegisterType<IMembershipRepository, MembershipRepository>();
			Builder.RegisterType<IMembershipAccountRepository, MembershipAccountRepository>();
			Builder.RegisterType<IMembershipCardRepository, MembershipCardRepository>();
			Builder.RegisterType<IBrandService, BrandService>();
			Builder.RegisterType<IBrandAccountService, BrandAccountService>();
			Builder.RegisterType<ICustomerService, CustomerService>();
			Builder.RegisterType<IMembershipService, MembershipService>();
			Builder.RegisterType<IMembershipAccountService, MembershipAccountService>();
			Builder.RegisterType<IMembershipCardService, MembershipCardService>();
			G.TContainer = Builder.Build();
		}
		
	}
}
