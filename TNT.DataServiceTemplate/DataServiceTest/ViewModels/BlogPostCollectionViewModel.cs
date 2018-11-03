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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("seo_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoDescription { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PicUrl { get; set; }
		[JsonProperty("parent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("is_display", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDisplay { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Position { get; set; }
		[JsonProperty("seo_keyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoKeyword { get; set; }
		[JsonProperty("limitation", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Limitation { get; set; }
		[JsonProperty("seo_name1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName1 { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("blog_post_collection2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BlogPostCollectionViewModel BlogPostCollection2VM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("blog_post_collection1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostCollectionViewModel> BlogPostCollection1VM { get; set; }
		[JsonProperty("blog_post_collection_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostCollectionItemMappingViewModel> BlogPostCollectionItemMappingsVM { get; set; }
		[JsonProperty("blog_post_collection_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
