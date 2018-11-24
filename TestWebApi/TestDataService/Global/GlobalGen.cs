using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Container;
using AutoMapper;
using System.Web;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TestDataService.Models.Services;
using TestDataService.Managers;
using TestDataService.ViewModels;

namespace TestDataService.Global
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
			//	cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
			//	cfg.CreateMap<EmployeeSkill, EmployeeSkillViewModel>().ReverseMap();
			//	cfg.CreateMap<Skill, SkillViewModel>().ReverseMap();
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
			Builder.RegisterType<IUnitOfWork, UnitOfWork>();
			Builder.RegisterType<EmployeeManagerEntities>();
			Builder.RegisterType<IEmployeeRepository, EmployeeRepository>();
			Builder.RegisterType<IEmployeeSkillRepository, EmployeeSkillRepository>();
			Builder.RegisterType<ISkillRepository, SkillRepository>();
			Builder.RegisterType<IEmployeeService, EmployeeService>();
			Builder.RegisterType<IEmployeeSkillService, EmployeeSkillService>();
			Builder.RegisterType<ISkillService, SkillService>();
			G.TContainer = Builder.Build();
		}
		
	}
}
