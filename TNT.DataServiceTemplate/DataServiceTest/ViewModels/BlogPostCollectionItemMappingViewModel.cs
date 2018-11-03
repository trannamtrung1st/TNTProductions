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
	public partial class BlogPostCollectionItemMappingViewModel: BaseViewModel<BlogPostCollectionItemMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("blog_post_collection_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BlogPostCollectionId { get; set; }
		[JsonProperty("blog_post_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BlogPostId { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("blog_post", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BlogPostViewModel BlogPostVM { get; set; }
		[JsonProperty("blog_post_collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BlogPostCollectionViewModel BlogPostCollectionVM { get; set; }
		
		public BlogPostCollectionItemMappingViewModel(BlogPostCollectionItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostCollectionItemMappingViewModel()
		{
		}
		
	}
}
