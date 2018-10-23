using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Models;
using T2CDataService.ViewModels;
using T2CDataService.ViewModels.Client;

namespace T2CDataService.Global
{
    public partial class G
    {
        public static void Configure()
        {
            AddMapperConfig(cfg =>
            {
                cfg.CreateMap<ClientAnswerViewModel, Answer>().ReverseMap();
                cfg.CreateMap<ClientAnswerViewModel, Post>().ReverseMap();
                cfg.CreateMap<ClientQuestionViewModel, Question>().ReverseMap();
                cfg.CreateMap<ClientQuestionViewModel, Post>().ReverseMap();
                cfg.CreateMap<ClientCommentViewModel, Comment>().ReverseMap();
                cfg.CreateMap<CreateUserViewModel, User>().ReverseMap();
            });
            DefaultConfigure();
        }
    }
}
