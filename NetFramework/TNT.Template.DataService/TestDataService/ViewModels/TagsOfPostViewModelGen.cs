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
	public partial class TagsOfPostViewModel: BaseViewModel<TagsOfPost>
	{
		//[JsonProperty("postId")]
		public int PostId { get; set; }
		//[JsonProperty("tagId")]
		public int TagId { get; set; }
		//[JsonProperty("post")]
		//public PostViewModel PostVM { get; set; }
		
		public TagsOfPostViewModel(TagsOfPost entity) : base(entity)
		{
		}
		
		public TagsOfPostViewModel()
		{
		}
		
	}
}
