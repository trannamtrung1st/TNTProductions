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
		public int? OfUserId { get; set; }
		//[JsonProperty("postedTime")]
		public DateTime? PostedTime { get; set; }
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
	
	public partial class UpdatePostViewModel: BaseUpdateViewModel<UpdatePostViewModel, Post>
	{
		//[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		//[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		//[JsonProperty("ofUserId")]
		public Wrapper<int?> OfUserId { get; set; }
		//[JsonProperty("postedTime")]
		public Wrapper<DateTime?> PostedTime { get; set; }
		//[JsonProperty("textContent")]
		public Wrapper<string> TextContent { get; set; }
		//[JsonProperty("title")]
		public Wrapper<string> Title { get; set; }
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
		
	}
}
