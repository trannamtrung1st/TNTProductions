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
		//[JsonProperty("toPostId")]
		public Nullable<int> ToPostId { get; set; }
		//[JsonProperty("toAnswerId")]
		public Nullable<int> ToAnswerId { get; set; }
		//[JsonProperty("textContent")]
		public string TextContent { get; set; }
		//[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		//[JsonProperty("ofUserId")]
		public Nullable<int> OfUserId { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("appUser")]
		//public AppUserViewModel AppUserVM { get; set; }
		//[JsonProperty("post")]
		//public PostViewModel PostVM { get; set; }
		//[JsonProperty("interactives")]
		//public IEnumerable<InteractiveViewModel> InteractivesVM { get; set; }
		
		public CommentViewModel(Comment entity) : base(entity)
		{
		}
		
		public CommentViewModel()
		{
		}
		
	}
}
