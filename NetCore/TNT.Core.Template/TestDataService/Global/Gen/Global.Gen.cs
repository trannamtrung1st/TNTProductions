using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TestDataService.ViewModels;
using TNT.Core.Helpers.DI;
using Microsoft.Extensions.DependencyInjection;

namespace TestDataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<AspNetRoleClaims, AspNetRoleClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetRoles, AspNetRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserClaims, AspNetUserClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserLogins, AspNetUserLoginsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserRoles, AspNetUserRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserTokens, AspNetUserTokensViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUsers, AspNetUsersViewModel>().ReverseMap();
			//	cfg.CreateMap<Logs, LogsViewModel>().ReverseMap();
			//	cfg.CreateMap<Products, ProductsViewModel>().ReverseMap();
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
		
		private static void ConfigureIoC(IServiceCollection services)
		{
			//IoC
			services.AddScoped<UnitOfWork>()
				.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<DbContext, TemplateContext>()
				.AddScoped<IAspNetRoleClaimsRepository, AspNetRoleClaimsRepository>()
				.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>()
				.AddScoped<IAspNetUserClaimsRepository, AspNetUserClaimsRepository>()
				.AddScoped<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>()
				.AddScoped<IAspNetUserRolesRepository, AspNetUserRolesRepository>()
				.AddScoped<IAspNetUserTokensRepository, AspNetUserTokensRepository>()
				.AddScoped<IAspNetUsersRepository, AspNetUsersRepository>()
				.AddScoped<ILogsRepository, LogsRepository>()
				.AddScoped<IProductsRepository, ProductsRepository>();
			ServiceInjection.Register(new List<Type>(){ typeof(G) });
		}
		
	}
}
