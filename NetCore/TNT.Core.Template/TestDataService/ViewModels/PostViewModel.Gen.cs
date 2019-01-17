using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Global;
using TestDataService.Models;
using Newtonsoft.Json;

namespace TestDataService.ViewModels
{
	public partial class PostViewModel: BaseViewModel<Post>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("ofUserId")]
		public Nullable<int> OfUserId { get; set; }
		//[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		//[JsonProperty("textContent")]
		public string TextContent { get; set; }
		//[JsonProperty("title")]
		public string Title { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("answer")]
		//public IEnumerable<AnswerViewModel> AnswerVM { get; set; }
		//[JsonProperty("comment")]
		//public IEnumerable<CommentViewModel> CommentVM { get; set; }
		//[JsonProperty("interactive")]
		//public IEnumerable<InteractiveViewModel> InteractiveVM { get; set; }
		//[JsonProperty("tagsOfPost")]
		//public IEnumerable<TagsOfPostViewModel> TagsOfPostVM { get; set; }
		
		public PostViewModel(Post entity) : base(entity)
		{
		}
		
		public PostViewModel()
		{
		}
		
	}
}
