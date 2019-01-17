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
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("doB")]
		public Nullable<DateTime> DoB { get; set; }
		//[JsonProperty("email")]
		public string Email { get; set; }
		//[JsonProperty("sex")]
		public Nullable<bool> Sex { get; set; }
		//[JsonProperty("username")]
		public string Username { get; set; }
		//[JsonProperty("answer")]
		//public IEnumerable<AnswerViewModel> AnswerVM { get; set; }
		//[JsonProperty("comment")]
		//public IEnumerable<CommentViewModel> CommentVM { get; set; }
		//[JsonProperty("interactive")]
		//public IEnumerable<InteractiveViewModel> InteractiveVM { get; set; }
		//[JsonProperty("post")]
		//public IEnumerable<PostViewModel> PostVM { get; set; }
		
		public AppUserViewModel(AppUser entity) : base(entity)
		{
		}
		
		public AppUserViewModel()
		{
		}
		
	}
}
