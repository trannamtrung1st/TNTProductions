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
	public partial class InteractiveViewModel: BaseViewModel<Interactive>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("happenedTime")]
		public DateTime? HappenedTime { get; set; }
		//[JsonProperty("isLike")]
		public bool? IsLike { get; set; }
		//[JsonProperty("ofUserId")]
		public int? OfUserId { get; set; }
		//[JsonProperty("toAnswerId")]
		public int? ToAnswerId { get; set; }
		//[JsonProperty("toCommentId")]
		public int? ToCommentId { get; set; }
		//[JsonProperty("toPostId")]
		public int? ToPostId { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toComment")]
		//public CommentViewModel ToCommentVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		
		public InteractiveViewModel(Interactive entity) : base(entity)
		{
		}
		
		public InteractiveViewModel()
		{
		}
		
	}
	
	public partial class UpdateInteractiveViewModel: BaseUpdateViewModel<UpdateInteractiveViewModel, Interactive>
	{
		//[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		//[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		//[JsonProperty("happenedTime")]
		public Wrapper<DateTime?> HappenedTime { get; set; }
		//[JsonProperty("isLike")]
		public Wrapper<bool?> IsLike { get; set; }
		//[JsonProperty("ofUserId")]
		public Wrapper<int?> OfUserId { get; set; }
		//[JsonProperty("toAnswerId")]
		public Wrapper<int?> ToAnswerId { get; set; }
		//[JsonProperty("toCommentId")]
		public Wrapper<int?> ToCommentId { get; set; }
		//[JsonProperty("toPostId")]
		public Wrapper<int?> ToPostId { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toComment")]
		//public CommentViewModel ToCommentVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		
	}
}
