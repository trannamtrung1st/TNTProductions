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
                    //cfg.CreateMap<Answer, BasicAnswerViewModel>().ReverseMap();
                    //cfg.CreateMap<AppUser, BasicAppUserViewModel>().ReverseMap();
                    //cfg.CreateMap<Comment, BasicCommentViewModel>().ReverseMap();
                    //cfg.CreateMap<Interactive, BasicInteractiveViewModel>().ReverseMap();
                    //cfg.CreateMap<Post, BasicPostViewModel>().ReverseMap();
                    //cfg.CreateMap<Tags, BasicTagsViewModel>().ReverseMap();
                    //cfg.CreateMap<TagsOfPost, BasicTagsOfPostViewModel>().ReverseMap();
                }
            );
            G.ConfigureAutomapper();
            G.ConfigureIoC();
        }

    }
}
