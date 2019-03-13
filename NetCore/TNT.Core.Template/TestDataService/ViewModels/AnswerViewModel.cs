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
	public partial class AnswerViewModel: BaseViewModel<Answer>
	{
		//[JsonProperty("ofUserId")]
		public int OfUserId { get; set; }
		//[JsonProperty("toPostId")]
		public int ToPostId { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("postedTime")]
		public DateTime? PostedTime { get; set; }
		//[JsonProperty("textContent")]
		public string TextContent { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		
		public AnswerViewModel(Answer entity) : base(entity)
		{
		}
		
		public AnswerViewModel()
		{
		}
		
	}
	
	public partial class UpdateAnswerViewModel: BaseUpdateViewModel<UpdateAnswerViewModel, Answer>
	{
		//[JsonProperty("ofUserId")]
		public Wrapper<int> OfUserId { get; set; }
		//[JsonProperty("toPostId")]
		public Wrapper<int> ToPostId { get; set; }
		//[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		//[JsonProperty("postedTime")]
		public Wrapper<DateTime?> PostedTime { get; set; }
		//[JsonProperty("textContent")]
		public Wrapper<string> TextContent { get; set; }
		//[JsonProperty("ofUser")]
		//public AppUserViewModel OfUserVM { get; set; }
		//[JsonProperty("toPost")]
		//public PostViewModel ToPostVM { get; set; }
		
	}
}