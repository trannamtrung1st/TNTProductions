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
	public partial class UserViewModel: BaseViewModel<User>
	{
		[JsonProperty("userId")]
		public int UserId { get; set; }
		[JsonProperty("firstname")]
		public string Firstname { get; set; }
		[JsonProperty("lastname")]
		public string Lastname { get; set; }
		[JsonProperty("dob")]
		public Nullable<DateTime> Dob { get; set; }
		[JsonProperty("joinedDate")]
		public Nullable<DateTime> JoinedDate { get; set; }
		[JsonIgnore]
		public bool Deactive { get; set; }
		[JsonProperty("comments")]
		public ICollection<CommentViewModel> CommentsVM { get; set; }
		[JsonProperty("posts")]
		public ICollection<PostViewModel> PostsVM { get; set; }
		
		public UserViewModel(User entity) : this()
		{
			FromEntity(entity);
		}
		
		public UserViewModel()
		{
			this.CommentsVM = new HashSet<CommentViewModel>();
			this.PostsVM = new HashSet<PostViewModel>();
		}
		
	}
}
