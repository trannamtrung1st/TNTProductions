using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TempDataService.Models.Configs;
using TempDataService.Models.Repositories;

namespace TempDataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<BooksTests, BooksTestsViewModel>().ReverseMap();
			//	AutoMapper.Mapper.Initialize(cfg as MapperConfigurationExpression);
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
		
		private static void ConfigureIoC(IServiceCollection services, IMongoDbSettings settings)
		{
			//IoC
			services.AddSingleton(settings)
				.AddSingleton<IBooksTestsRepository, BooksTestsRepository>();
		}
		
	}
}
