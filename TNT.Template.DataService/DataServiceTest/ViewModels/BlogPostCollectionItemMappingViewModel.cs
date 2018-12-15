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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("blog_post_collection_id")]
		public int BlogPostCollectionId { get; set; }
		[JsonProperty("blog_post_id")]
		public int BlogPostId { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("blog_post")]
		//public BlogPostViewModel BlogPostVM { get; set; }
		//[JsonProperty("blog_post_collection")]
		//public BlogPostCollectionViewModel BlogPostCollectionVM { get; set; }
		
		public BlogPostCollectionItemMappingViewModel(BlogPostCollectionItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostCollectionItemMappingViewModel()
		{
		}
		
	}
}
