using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestDataService.Models.Entities;
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
			//	cfg.CreateMap<AspNetRoleClaims, AspNetRoleClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetRoles, AspNetRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserClaims, AspNetUserClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserLogins, AspNetUserLoginsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserRoles, AspNetUserRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserTokens, AspNetUserTokensViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUsers, AspNetUsersViewModel>().ReverseMap();
			//	cfg.CreateMap<Documents, DocumentsViewModel>().ReverseMap();
			//	cfg.CreateMap<Organizations, OrganizationsViewModel>().ReverseMap();
			//	cfg.CreateMap<Projects, ProjectsViewModel>().ReverseMap();
			//	cfg.CreateMap<VisionAndScopeDocs, VisionAndScopeDocsViewModel>().ReverseMap();
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
		
		private static void ConfigureIoC(IServiceCollection services)
		{
			//IoC
			services.AddScoped<UnitOfWork>()
				.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<DataContext, UnitOfWork>()
				.AddScoped<DbContext, UnitOfWork>()
				.AddScoped<IAspNetRoleClaimsRepository, AspNetRoleClaimsRepository>()
				.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>()
				.AddScoped<IAspNetUserClaimsRepository, AspNetUserClaimsRepository>()
				.AddScoped<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>()
				.AddScoped<IAspNetUserRolesRepository, AspNetUserRolesRepository>()
				.AddScoped<IAspNetUserTokensRepository, AspNetUserTokensRepository>()
				.AddScoped<IAspNetUsersRepository, AspNetUsersRepository>()
				.AddScoped<IDocumentsRepository, DocumentsRepository>()
				.AddScoped<IOrganizationsRepository, OrganizationsRepository>()
				.AddScoped<IProjectsRepository, ProjectsRepository>()
				.AddScoped<IVisionAndScopeDocsRepository, VisionAndScopeDocsRepository>();
		}
		
	}
}
