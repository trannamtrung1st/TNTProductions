using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Global;
using T2CDataService.Models;

namespace T2CDataService.ViewModels.Client
{
    public class ClientCommentViewModel : BaseViewModel<Comment>
    {
        [JsonProperty("commentId")]
        public int CommentId { get; set; }
        [JsonProperty("inPostId")]
        public Nullable<int> InPostId { get; set; }
        [JsonProperty("byUserId")]
        public Nullable<int> ByUserId { get; set; }
        [JsonProperty("postedTime")]
        public Nullable<DateTime> PostedTime { get; set; }
        [JsonProperty("cContent")]
        public string CContent { get; set; }
        [JsonProperty("user")]
        public UserViewModel User { get; set; }
        [JsonProperty("post")]
        public PostViewModel PostVM { get; set; }

        public ClientCommentViewModel(Comment entity) : this()
        {
            FromEntity(entity);
        }

        public ClientCommentViewModel()
        {
        }

    }
}
