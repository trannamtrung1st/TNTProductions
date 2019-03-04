using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataService.Models;
using DataService.Models.Repositories;
using DataService.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<Answer, AnswerViewModel>().ReverseMap();
			//	cfg.CreateMap<AppUser, AppUserViewModel>().ReverseMap();
			//	cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
			//	cfg.CreateMap<Interactive, InteractiveViewModel>().ReverseMap();
			//	cfg.CreateMap<Post, PostViewModel>().ReverseMap();
			//	cfg.CreateMap<Tags, TagsViewModel>().ReverseMap();
			//	cfg.CreateMap<TagsOfPost, TagsOfPostViewModel>().ReverseMap();
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
			services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(provider))
				.AddScoped<FushariContext, UnitOfWork>(provider => new UnitOfWork(provider))
				.AddScoped<DbContext, UnitOfWork>(provider => new UnitOfWork(provider))
				.AddScoped<IAnswerRepository, AnswerRepository>()
				.AddScoped<IAppUserRepository, AppUserRepository>()
				.AddScoped<ICommentRepository, CommentRepository>()
				.AddScoped<IInteractiveRepository, InteractiveRepository>()
				.AddScoped<IPostRepository, PostRepository>()
				.AddScoped<ITagsRepository, TagsRepository>()
				.AddScoped<ITagsOfPostRepository, TagsOfPostRepository>();
		}
		
	}
}
