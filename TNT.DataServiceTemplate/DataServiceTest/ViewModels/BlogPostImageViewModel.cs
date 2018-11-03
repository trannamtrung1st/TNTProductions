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
	public partial class BlogPostImageViewModel: BaseViewModel<BlogPostImage>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("blog_post_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BlogPostId { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("blog_post", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BlogPostViewModel BlogPostVM { get; set; }
		
		public BlogPostImageViewModel(BlogPostImage entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostImageViewModel()
		{
		}
		
	}
}
