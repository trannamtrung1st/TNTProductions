using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Container;
using AutoMapper;
using T2CDataService.Models;
using T2CDataService.Models.Repositories;
using T2CDataService.Models.Services;
using T2CDataService.ViewModels;

namespace T2CDataService.Global
{
	public partial class G
	{
		public static IMapper Mapper;
		public static ITContainer TContainer;
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs { get; set; }
		= new List<Action<IMapperConfigurationExpression>>()
		{
			cfg =>
			{
				cfg.CreateMap<Answer, AnswerViewModel>().ReverseMap();
				cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
				cfg.CreateMap<Post, PostViewModel>().ReverseMap();
				cfg.CreateMap<Question, QuestionViewModel>().ReverseMap();
				cfg.CreateMap<User, UserViewModel>().ReverseMap();
			}
		};
		public static void AddMapperConfig(Action<IMapperConfigurationExpression> cfg)
		{
			MapperConfigs.Add(cfg);
		}
		private static void DefaultConfigure()
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
			
			//IoContainer
			G.TContainer = new TContainer();
			G.TContainer.RegisterType<IAnswerRepository, AnswerRepository>();
			G.TContainer.RegisterType<ICommentRepository, CommentRepository>();
			G.TContainer.RegisterType<IPostRepository, PostRepository>();
			G.TContainer.RegisterType<IQuestionRepository, QuestionRepository>();
			G.TContainer.RegisterType<IUserRepository, UserRepository>();
			G.TContainer.RegisterType<IAnswerService, AnswerService>();
			G.TContainer.RegisterType<ICommentService, CommentService>();
			G.TContainer.RegisterType<IPostService, PostService>();
			G.TContainer.RegisterType<IQuestionService, QuestionService>();
			G.TContainer.RegisterType<IUserService, UserService>();
		}
	}
}
