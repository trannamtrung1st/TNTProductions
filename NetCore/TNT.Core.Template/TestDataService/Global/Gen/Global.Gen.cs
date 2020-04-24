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
			//var vmType = typeof(IViewModel);
			//var modelTypes = AppDomain.CurrentDomain.GetAssemblies()
			//	.SelectMany(t => t.GetTypes())
			//	.Where(t => vmType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
			//var maps = new Dictionary<Type, Type>();
			//foreach (var t in modelTypes)
			//{
			//	var genArgs = t.BaseType?.GetGenericArguments().FirstOrDefault();
			//	if (genArgs != null) cfg.CreateMap(genArgs, t).ReverseMap();
		//}
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
				.AddScoped<DbContext, TemplateContext>();
			
			var baseRepoType = typeof(IRepository);
			var repoTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(t => t.GetTypes())
				.Where(t => baseRepoType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
			var maps = new Dictionary<Type, Type>();
			foreach (var t in repoTypes)
			{
				var iRepoType = t.GetInterface($"I{t.Name}");
				if (iRepoType != null) services.AddScoped(iRepoType, t);
			}
			ServiceInjection.Register(new List<Type>(){ typeof(G) });
		}
		
	}
}
