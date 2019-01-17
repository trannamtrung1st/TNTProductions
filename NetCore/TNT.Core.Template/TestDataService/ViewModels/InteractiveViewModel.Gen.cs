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
		public Nullable<DateTime> HappenedTime { get; set; }
		//[JsonProperty("isLike")]
		public Nullable<bool> IsLike { get; set; }
		//[JsonProperty("ofUserId")]
		public Nullable<int> OfUserId { get; set; }
		//[JsonProperty("toAnswerId")]
		public Nullable<int> ToAnswerId { get; set; }
		//[JsonProperty("toCommentId")]
		public Nullable<int> ToCommentId { get; set; }
		//[JsonProperty("toPostId")]
		public Nullable<int> ToPostId { get; set; }
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
}
