using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Global;
using T2CDataService.Models;
using T2CDataService.Utilities;

namespace T2CDataService.ViewModels.Client
{
    public class ClientQuestionViewModel : BaseViewModel<Question>
    {
        [JsonProperty("questionId")]
        public int QuestionId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("byUserId")]
        public Nullable<int> ByUserId { get; set; }
        [JsonProperty("postedTime")]
        public Nullable<DateTime> PostedTime { get; set; }
        [JsonProperty("qContent")]
        public string PContent { get; set; }
        [JsonProperty("user")]
        public UserViewModel User { get; set; }
        [JsonProperty("answers")]
        public ICollection<ClientAnswerViewModel> AnswersVM { get; set; }
        [JsonProperty("comments")]
        public ICollection<ClientCommentViewModel> CommentsVM { get; set; }

        public ClientQuestionViewModel(Question entity) : this()
        {
            FromEntity(entity);
        }

        public ClientQuestionViewModel()
        {
            this.AnswersVM = new HashSet<ClientAnswerViewModel>();
            this.CommentsVM = new HashSet<ClientCommentViewModel>();
        }

        public override void FromEntity(Question entity)
        {
            Entity = entity;
            G.Mapper.Map(entity, this);
            CopyFrom(entity.Post);
        }

        public override Question ToEntity()
        {
            if (Entity != null)
                return Entity;
            var question = G.Mapper.Map<Question>(this);
            question.Post = new Post();
            CopyTo(question.Post);
            return question;
        }
    }
}
