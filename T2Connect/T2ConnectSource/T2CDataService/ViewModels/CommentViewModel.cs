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
	public partial class CommentViewModel: BaseViewModel<Comment>
	{
		[JsonProperty("commentId")]
		public int CommentId { get; set; }
		[JsonProperty("inPostId")]
		public Nullable<int> InPostId { get; set; }
		[JsonIgnore]
		public bool Deactive { get; set; }
		[JsonProperty("byUserId")]
		public Nullable<int> ByUserId { get; set; }
		[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		[JsonProperty("cContent")]
		public string CContent { get; set; }
		[JsonProperty("post")]
		public PostViewModel PostVM { get; set; }
		[JsonProperty("user")]
		public UserViewModel UserVM { get; set; }
		
		public CommentViewModel(Comment entity) : this()
		{
			FromEntity(entity);
		}
		
		public CommentViewModel()
		{
		}
		
	}
}
