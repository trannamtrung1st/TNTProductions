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
	public partial class AppUserViewModel: BaseViewModel<AppUser>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("username")]
		public string Username { get; set; }
		//[JsonProperty("doB")]
		public Nullable<DateTime> DoB { get; set; }
		//[JsonProperty("sex")]
		public Nullable<bool> Sex { get; set; }
		//[JsonProperty("email")]
		public string Email { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("answers")]
		//public IEnumerable<AnswerViewModel> AnswersVM { get; set; }
		//[JsonProperty("comments")]
		//public IEnumerable<CommentViewModel> CommentsVM { get; set; }
		//[JsonProperty("interactives")]
		//public IEnumerable<InteractiveViewModel> InteractivesVM { get; set; }
		//[JsonProperty("posts")]
		//public IEnumerable<PostViewModel> PostsVM { get; set; }
		
		public AppUserViewModel(AppUser entity) : base(entity)
		{
		}
		
		public AppUserViewModel()
		{
		}
		
	}
}
