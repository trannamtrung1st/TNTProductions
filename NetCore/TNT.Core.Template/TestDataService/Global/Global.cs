using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestDataService.Models;
using TestDataService.ViewModels;

namespace TestDataService.Global
{
    public static partial class G
    {
        public static void Configure(IApplicationBuilder app)
        {
            G.Builder.RegisterRequestScopeInstance(app);
            MapperConfigs.Add(
                cfg =>
                {
                    cfg.CreateMap<Answer, AnswerViewModel>().ReverseMap();
                    cfg.CreateMap<AppUser, AppUserViewModel>().ReverseMap();
                    cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
                    cfg.CreateMap<Interactive, InteractiveViewModel>().ReverseMap();
                    cfg.CreateMap<Post, PostViewModel>().ReverseMap();
                    cfg.CreateMap<Tags, TagsViewModel>().ReverseMap();
                    cfg.CreateMap<TagsOfPost, TagsOfPostViewModel>().ReverseMap();
                }
            );
            G.ConfigureAutomapper();
            G.ConfigureIoC();
        }

    }
}
