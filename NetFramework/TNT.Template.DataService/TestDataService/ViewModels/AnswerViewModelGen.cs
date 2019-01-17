﻿using System;
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
		//[JsonProperty("textContent")]
		public string TextContent { get; set; }
		//[JsonProperty("postedTime")]
		public Nullable<DateTime> PostedTime { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("appUser")]
		//public AppUserViewModel AppUserVM { get; set; }
		//[JsonProperty("post")]
		//public PostViewModel PostVM { get; set; }
		
		public AnswerViewModel(Answer entity) : base(entity)
		{
		}
		
		public AnswerViewModel()
		{
		}
		
	}
}