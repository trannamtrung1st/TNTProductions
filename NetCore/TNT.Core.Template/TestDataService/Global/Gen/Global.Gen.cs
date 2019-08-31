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
			//	cfg.CreateMap<AspNetRoleClaims, AspNetRoleClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetRoles, AspNetRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserClaims, AspNetUserClaimsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserLogins, AspNetUserLoginsViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserRoles, AspNetUserRolesViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserTokens, AspNetUserTokensViewModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUsers, AspNetUsersViewModel>().ReverseMap();
			//	cfg.CreateMap<Epics, EpicsViewModel>().ReverseMap();
			//	cfg.CreateMap<Products, ProductsViewModel>().ReverseMap();
			//	cfg.CreateMap<Sprints, SprintsViewModel>().ReverseMap();
			//	cfg.CreateMap<TaskActivities, TaskActivitiesViewModel>().ReverseMap();
			//	cfg.CreateMap<TaskAttachments, TaskAttachmentsViewModel>().ReverseMap();
			//	cfg.CreateMap<TaskChecklistItems, TaskChecklistItemsViewModel>().ReverseMap();
			//	cfg.CreateMap<TaskChecklists, TaskChecklistsViewModel>().ReverseMap();
			//	cfg.CreateMap<TaskMembers, TaskMembersViewModel>().ReverseMap();
			//	cfg.CreateMap<Tasks, TasksViewModel>().ReverseMap();
			//	cfg.CreateMap<UserStories, UserStoriesViewModel>().ReverseMap();
			//	cfg.CreateMap<UserStoryAcceptanceCriterias, UserStoryAcceptanceCriteriasViewModel>().ReverseMap();
			//	cfg.CreateMap<UserStoryRequirements, UserStoryRequirementsViewModel>().ReverseMap();
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
				.AddScoped<TScrumContext, UnitOfWork>()
				.AddScoped<DbContext, UnitOfWork>()
				.AddScoped<IAspNetRoleClaimsRepository, AspNetRoleClaimsRepository>()
				.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>()
				.AddScoped<IAspNetUserClaimsRepository, AspNetUserClaimsRepository>()
				.AddScoped<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>()
				.AddScoped<IAspNetUserRolesRepository, AspNetUserRolesRepository>()
				.AddScoped<IAspNetUserTokensRepository, AspNetUserTokensRepository>()
				.AddScoped<IAspNetUsersRepository, AspNetUsersRepository>()
				.AddScoped<IEpicsRepository, EpicsRepository>()
				.AddScoped<IProductsRepository, ProductsRepository>()
				.AddScoped<ISprintsRepository, SprintsRepository>()
				.AddScoped<ITaskActivitiesRepository, TaskActivitiesRepository>()
				.AddScoped<ITaskAttachmentsRepository, TaskAttachmentsRepository>()
				.AddScoped<ITaskChecklistItemsRepository, TaskChecklistItemsRepository>()
				.AddScoped<ITaskChecklistsRepository, TaskChecklistsRepository>()
				.AddScoped<ITaskMembersRepository, TaskMembersRepository>()
				.AddScoped<ITasksRepository, TasksRepository>()
				.AddScoped<IUserStoriesRepository, UserStoriesRepository>()
				.AddScoped<IUserStoryAcceptanceCriteriasRepository, UserStoryAcceptanceCriteriasRepository>()
				.AddScoped<IUserStoryRequirementsRepository, UserStoryRequirementsRepository>();
		}
		
	}
}
