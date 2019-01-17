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
		//[JsonProperty("title")]
		public string Title { get; set; }
		//[JsonProperty("textContent")]
		public string TextContent { get; set; }
		//[JsonProperty("ofUserId")]
		public Nullable<int> OfUserId { get; set; }
		//[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("appUser")]
		//public AppUserViewModel AppUserVM { get; set; }
		//[JsonProperty("answers")]
		//public IEnumerable<AnswerViewModel> AnswersVM { get; set; }
		//[JsonProperty("comments")]
		//public IEnumerable<CommentViewModel> CommentsVM { get; set; }
		//[JsonProperty("interactives")]
		//public IEnumerable<InteractiveViewModel> InteractivesVM { get; set; }
		//[JsonProperty("tagsOfPosts")]
		//public IEnumerable<TagsOfPostViewModel> TagsOfPostsVM { get; set; }
		
		public PostViewModel(Post entity) : base(entity)
		{
		}
		
		public PostViewModel()
		{
		}
		
	}
}
