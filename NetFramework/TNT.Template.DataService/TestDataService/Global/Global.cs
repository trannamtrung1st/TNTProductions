using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TestDataService.ViewModels;

namespace TestDataService.Global
{
    public static partial class G
    {

        public static void Configure()
        {
            G.Builder.RegisterRequestScopeHandlerModule();
            G.MapperConfigs.Add(
            cfg =>
            {
                cfg.CreateMap<Answer, AnswerViewModel>().ReverseMap();
                cfg.CreateMap<AppUser, AppUserViewModel>().ReverseMap();
                cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
                cfg.CreateMap<Interactive, InteractiveViewModel>().ReverseMap();
                cfg.CreateMap<Post, PostViewModel>().ReverseMap();
                cfg.CreateMap<TagsOfPost, TagsOfPostViewModel>().ReverseMap();
            });
            G.DefaultConfigure();
        }

    }
}
