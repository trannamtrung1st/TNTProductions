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
	public partial class TagMappingViewModel: BaseViewModel<TagMapping>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("tagId")]
		public int TagId { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("tagBlogId")]
		public int TagBlogId { get; set; }
		[JsonProperty("blogCategory")]
		public BlogCategoryViewModel BlogCategoryVM { get; set; }
		[JsonProperty("blogPost")]
		public BlogPostViewModel BlogPostVM { get; set; }
		[JsonProperty("tag")]
		public TagViewModel TagVM { get; set; }
		
		public TagMappingViewModel(TagMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TagMappingViewModel()
		{
		}
		
	}
}
