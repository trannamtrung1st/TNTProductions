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
	public partial class CommentViewModel: BaseViewModel<Comment>
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
		//[JsonProperty("toAnswerId")]
		public int? ToAnswerId { get; set; }
		//[JsonProperty("toPostId")]
		public int? ToPostId { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		//[JsonProperty("interactive")]
		//public IEnumerable<InteractiveViewModel> InteractiveVM { get; set; }
		
		public CommentViewModel(Comment entity) : base(entity)
		{
		}
		
		public CommentViewModel()
		{
		}
		
	}
	
	public partial class UpdateCommentViewModel: BaseUpdateViewModel<UpdateCommentViewModel, Comment>
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
		//[JsonProperty("toAnswerId")]
		public Wrapper<int?> ToAnswerId { get; set; }
		//[JsonProperty("toPostId")]
		public Wrapper<int?> ToPostId { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		//[JsonProperty("interactive")]
		//public IEnumerable<InteractiveViewModel> InteractiveVM { get; set; }
		
	}
}
