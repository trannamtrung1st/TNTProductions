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
		[JsonProperty("tag_id")]
		public int TagId { get; set; }
		[JsonProperty("category_id")]
		public int CategoryId { get; set; }
		[JsonProperty("tag_blog_id")]
		public int TagBlogId { get; set; }
		//[JsonProperty("blog_category")]
		//public BlogCategoryViewModel BlogCategoryVM { get; set; }
		//[JsonProperty("blog_post")]
		//public BlogPostViewModel BlogPostVM { get; set; }
		//[JsonProperty("tag")]
		//public TagViewModel TagVM { get; set; }
		
		public TagMappingViewModel(TagMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TagMappingViewModel()
		{
		}
		
	}
}
