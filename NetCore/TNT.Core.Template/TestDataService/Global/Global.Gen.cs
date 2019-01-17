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
using TNT.Core.IoC.Container;

namespace TestDataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		public static ITContainer TContainer { get; private set; }
		private static TContainerBuilder Builder = new TContainerBuilder();
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
		
		private static void ConfigureIoC()
		{
			//IoC
			var repoOpt = new BuilderOptions();
			repoOpt.InjectableConstructors = new Dictionary<int, Params[]>();
			repoOpt.InjectableConstructors[0] = new Params[] { Params.Injectable<IUnitOfWork>() };
			
			Builder.RegisterType<IUnitOfWork, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<FushariContext, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<DbContext, UnitOfWork>(container => new UnitOfWork(container))
				.RegisterType<IAnswerRepository, AnswerRepository>(repoOpt)
				.RegisterType<IAppUserRepository, AppUserRepository>(repoOpt)
				.RegisterType<ICommentRepository, CommentRepository>(repoOpt)
				.RegisterType<IInteractiveRepository, InteractiveRepository>(repoOpt)
				.RegisterType<IPostRepository, PostRepository>(repoOpt)
				.RegisterType<ITagsRepository, TagsRepository>(repoOpt)
				.RegisterType<ITagsOfPostRepository, TagsOfPostRepository>(repoOpt)
				.AttachAllRegisteredToLifetimeScope();
			G.TContainer = Builder.Build();
		}
		
	}
}
