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
    public class ClientAnswerViewModel : BaseViewModel<Answer>
    {
        [JsonProperty("answerId")]
        public int AnswerId { get; set; }
        [JsonProperty("inQuestionId")]
        public Nullable<int> InQuestionId { get; set; }
        [JsonProperty("byUserId")]
        public Nullable<int> ByUserId { get; set; }
        [JsonProperty("postedTime")]
        public Nullable<DateTime> PostedTime { get; set; }
        [JsonProperty("aContent")]
        public string PContent { get; set; }
        [JsonProperty("user")]
        public UserViewModel User { get; set; }
        [JsonProperty("question")]
        public ClientQuestionViewModel QuestionVM { get; set; }
        [JsonProperty("comments")]
        public ICollection<ClientCommentViewModel> CommentsVM { get; set; }

        public ClientAnswerViewModel(Answer entity) : this()
        {
            FromEntity(entity);
        }

        public ClientAnswerViewModel()
        {
            this.CommentsVM = new HashSet<ClientCommentViewModel>();
        }

        public override void FromEntity(Answer entity)
        {
            Entity = entity;
            G.Mapper.Map(entity, this);
            CopyFrom(entity.Post);
        }

        public override Answer ToEntity()
        {
            if (Entity != null)
                return Entity;
            var answer = G.Mapper.Map<Answer>(this);
            answer.Post = new Post();
            CopyTo(answer.Post);
            return answer;
        }

    }
}
