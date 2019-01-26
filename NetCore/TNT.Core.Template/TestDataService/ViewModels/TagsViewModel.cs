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
	public partial class TagsViewModel: BaseViewModel<Tags>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("description")]
		public string Description { get; set; }
		//[JsonProperty("tagCode")]
		public string TagCode { get; set; }
		//[JsonProperty("tagsOfPost")]
		//public IEnumerable<TagsOfPostViewModel> TagsOfPostVM { get; set; }
		
		public TagsViewModel(Tags entity) : base(entity)
		{
		}
		
		public TagsViewModel()
		{
		}
		
	}
	
	public partial class UpdateTagsViewModel: BaseUpdateViewModel<UpdateTagsViewModel, Tags>
	{
		//[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		//[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		//[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		//[JsonProperty("tagCode")]
		public Wrapper<string> TagCode { get; set; }
		//[JsonProperty("tagsOfPost")]
		//public IEnumerable<TagsOfPostViewModel> TagsOfPostVM { get; set; }
		
	}
}
