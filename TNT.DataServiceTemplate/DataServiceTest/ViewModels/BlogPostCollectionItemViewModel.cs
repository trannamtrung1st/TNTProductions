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
	public partial class BlogPostCollectionItemViewModel: BaseViewModel<BlogPostCollectionItem>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("blogPostCollectionId")]
		public int BlogPostCollectionId { get; set; }
		[JsonProperty("blogPostId")]
		public int BlogPostId { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("blogPostCollection")]
		public BlogPostCollectionViewModel BlogPostCollectionVM { get; set; }
		
		public BlogPostCollectionItemViewModel(BlogPostCollectionItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostCollectionItemViewModel()
		{
		}
		
	}
}
