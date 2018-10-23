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
	public partial class BlogPostCollectionViewModel: BaseViewModel<BlogPostCollection>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("seoDescription")]
		public string SeoDescription { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("picUrl")]
		public string PicUrl { get; set; }
		[JsonProperty("parentId")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("isDisplay")]
		public bool IsDisplay { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("seoKeyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("limitation")]
		public int Limitation { get; set; }
		[JsonProperty("seoName1")]
		public string SeoName1 { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("blogPostCollection2")]
		public BlogPostCollectionViewModel BlogPostCollection2VM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("blogPostCollection1")]
		public ICollection<BlogPostCollectionViewModel> BlogPostCollection1VM { get; set; }
		[JsonProperty("blogPostCollectionItemMappings")]
		public ICollection<BlogPostCollectionItemMappingViewModel> BlogPostCollectionItemMappingsVM { get; set; }
		[JsonProperty("blogPostCollectionItems")]
		public ICollection<BlogPostCollectionItemViewModel> BlogPostCollectionItemsVM { get; set; }
		
		public BlogPostCollectionViewModel(BlogPostCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostCollectionViewModel()
		{
			this.BlogPostCollection1VM = new HashSet<BlogPostCollectionViewModel>();
			this.BlogPostCollectionItemMappingsVM = new HashSet<BlogPostCollectionItemMappingViewModel>();
			this.BlogPostCollectionItemsVM = new HashSet<BlogPostCollectionItemViewModel>();
		}
		
	}
}
