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
		[JsonProperty("seo_name")]
		public string SeoName { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("seo_description")]
		public string SeoDescription { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("pic_url")]
		public string PicUrl { get; set; }
		[JsonProperty("parent_id")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("is_display")]
		public bool IsDisplay { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("seo_keyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("limitation")]
		public int Limitation { get; set; }
		[JsonProperty("seo_name1")]
		public string SeoName1 { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		//[JsonProperty("blog_post_collection2")]
		//public BlogPostCollectionViewModel BlogPostCollection2VM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("blog_post_collection1")]
		//public IEnumerable<BlogPostCollectionViewModel> BlogPostCollection1VM { get; set; }
		//[JsonProperty("blog_post_collection_item_mappings")]
		//public IEnumerable<BlogPostCollectionItemMappingViewModel> BlogPostCollectionItemMappingsVM { get; set; }
		//[JsonProperty("blog_post_collection_items")]
		//public IEnumerable<BlogPostCollectionItemViewModel> BlogPostCollectionItemsVM { get; set; }
		
		public BlogPostCollectionViewModel(BlogPostCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostCollectionViewModel()
		{
			//this.BlogPostCollection1VM = new HashSet<BlogPostCollectionViewModel>();
			//this.BlogPostCollectionItemMappingsVM = new HashSet<BlogPostCollectionItemMappingViewModel>();
			//this.BlogPostCollectionItemsVM = new HashSet<BlogPostCollectionItemViewModel>();
		}
		
	}
}
