using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoC.Container;
using AutoMapper;
using System.Web;
using System.Data.Entity;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TestDataService.ViewModels;

namespace TestDataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		public static ITContainer TContainer { get; private set; }
		private static TContainerBuilder Builder = new TContainerBuilder();
		private static void DefaultConfigure()
		{
			ConfigureAutomapper();
			ConfigureIoC();
		}
		
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<AppAction, AppActionViewModel>().ReverseMap();
			//	cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerEvent, CustomerEventViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerFilter, CustomerFilterViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerFilterMetadata, CustomerFilterMetadataViewModel>().ReverseMap();
			//	cfg.CreateMap<CustomerMetadata, CustomerMetadataViewModel>().ReverseMap();
			//	cfg.CreateMap<EventTrigger, EventTriggerViewModel>().ReverseMap();
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
		
		private static void ConfigureIoC()
		{
			//IoC
			var repoOpt = new BuilderOptions();
			repoOpt.InjectableConstructors = new Dictionary<int, Params[]>();
			repoOpt.InjectableConstructors[0] = new Params[] { Params.Injectable<IUnitOfWork>() };
			
			Builder.RegisterType<IUnitOfWork, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<AppEntity, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<DbContext, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<IAppActionRepository, AppActionRepository>(repoOpt)
				.RegisterType<ICustomerRepository, CustomerRepository>(repoOpt)
				.RegisterType<ICustomerEventRepository, CustomerEventRepository>(repoOpt)
				.RegisterType<ICustomerFilterRepository, CustomerFilterRepository>(repoOpt)
				.RegisterType<ICustomerFilterMetadataRepository, CustomerFilterMetadataRepository>(repoOpt)
				.RegisterType<ICustomerMetadataRepository, CustomerMetadataRepository>(repoOpt)
				.RegisterType<IEventTriggerRepository, EventTriggerRepository>(repoOpt)
				.AttachAllRegisteredToLifetimeScope();
			G.TContainer = Builder.Build();
		}
		
	}
}
