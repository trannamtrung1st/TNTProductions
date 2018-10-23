using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Global;
using T2CDataService.Models;
using Newtonsoft.Json;

namespace T2CDataService.ViewModels
{
	public partial class PostViewModel: BaseViewModel<Post>
	{
		[JsonProperty("postId")]
		public int PostId { get; set; }
		[JsonProperty("byUserId")]
		public Nullable<int> ByUserId { get; set; }
		[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		[JsonProperty("pContent")]
		public string PContent { get; set; }
		[JsonProperty("answer")]
		public AnswerViewModel AnswerVM { get; set; }
		[JsonProperty("user")]
		public UserViewModel UserVM { get; set; }
		[JsonProperty("question")]
		public QuestionViewModel QuestionVM { get; set; }
		[JsonProperty("comments")]
		public ICollection<CommentViewModel> CommentsVM { get; set; }
		
		public PostViewModel(Post entity) : this()
		{
			FromEntity(entity);
		}
		
		public PostViewModel()
		{
			this.CommentsVM = new HashSet<CommentViewModel>();
		}
		
	}
}
