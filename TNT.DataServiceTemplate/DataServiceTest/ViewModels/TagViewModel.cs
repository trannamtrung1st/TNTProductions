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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("tag_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TagName { get; set; }
		[JsonProperty("tag_name__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TagName_EN { get; set; }
		[JsonProperty("tag_views", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<long> TagViews { get; set; }
		[JsonProperty("tag_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> TagActive { get; set; }
		[JsonProperty("tag_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
