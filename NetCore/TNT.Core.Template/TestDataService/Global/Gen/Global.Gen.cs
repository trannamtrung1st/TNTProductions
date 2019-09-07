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
				.AddScoped<DbContext, DataContext>()
				.AddScoped<IProductsRepository, ProductsRepository>();
		}
		
	}
}
