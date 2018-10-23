using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class TagViewModel: BaseViewModel<Tag>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("tagName")]
		public string TagName { get; set; }
		[JsonProperty("tagName_EN")]
		public string TagName_EN { get; set; }
		[JsonProperty("tagViews")]
		public Nullable<long> TagViews { get; set; }
		[JsonProperty("tagActive")]
		public Nullable<bool> TagActive { get; set; }
		[JsonProperty("tagMappings")]
		public ICollection<TagMappingViewModel> TagMappingsVM { get; set; }
		
		public TagViewModel(Tag entity) : this()
		{
			FromEntity(entity);
		}
		
		public TagViewModel()
		{
			this.TagMappingsVM = new HashSet<TagMappingViewModel>();
		}
		
	}
}
