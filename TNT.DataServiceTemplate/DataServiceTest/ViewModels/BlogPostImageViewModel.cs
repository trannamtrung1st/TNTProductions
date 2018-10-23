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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("blogPostId")]
		public int BlogPostId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("blogPost")]
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
