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
	public partial class BlogPostViewModel: BaseViewModel<BlogPost>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("title__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title_En { get; set; }
		[JsonProperty("opening", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Opening { get; set; }
		[JsonProperty("opening__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Opening_En { get; set; }
		[JsonProperty("blog_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BlogContent { get; set; }
		[JsonProperty("blog_content__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BlogContent_En { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Image { get; set; }
		[JsonProperty("author", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Author { get; set; }
		[JsonProperty("created_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreatedTime { get; set; }
		[JsonProperty("updated_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime UpdatedTime { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("meta_keyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetaKeyword { get; set; }
		[JsonProperty("total_visit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalVisit { get; set; }
		[JsonProperty("end_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("excerpt", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Excerpt { get; set; }
		[JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string URL { get; set; }
		[JsonProperty("blog_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BlogCategoryId { get; set; }
		[JsonProperty("page_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageTitle { get; set; }
		[JsonProperty("page_title__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageTitle_En { get; set; }
		[JsonProperty("meta_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetaDescription { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("last_update_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LastUpdatePerson { get; set; }
		[JsonProperty("reference", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Reference { get; set; }
		[JsonProperty("link_ref1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LinkRef1 { get; set; }
		[JsonProperty("link_ref2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LinkRef2 { get; set; }
		[JsonProperty("link_ref3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LinkRef3 { get; set; }
		[JsonProperty("link_ref4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LinkRef4 { get; set; }
		[JsonProperty("link_ref5", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LinkRef5 { get; set; }
		[JsonProperty("blog_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BlogType { get; set; }
		[JsonProperty("location_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> LocationId { get; set; }
		[JsonProperty("author_refer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AuthorRefer { get; set; }
		[JsonProperty("user_approve", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserApprove { get; set; }
		[JsonProperty("public_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> PublicDate { get; set; }
		[JsonProperty("blog_post_collection_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BlogPostCollectionNumber { get; set; }
		[JsonProperty("blog_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BlogCategoryViewModel BlogCategoryVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("blog_post_collection_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostCollectionItemMappingViewModel> BlogPostCollectionItemMappingsVM { get; set; }
		[JsonProperty("blog_post_images", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostImageViewModel> BlogPostImagesVM { get; set; }
		[JsonProperty("tag_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TagMappingViewModel> TagMappingsVM { get; set; }
		
		public BlogPostViewModel(BlogPost entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogPostViewModel()
		{
			this.BlogPostCollectionItemMappingsVM = new HashSet<BlogPostCollectionItemMappingViewModel>();
			this.BlogPostImagesVM = new HashSet<BlogPostImageViewModel>();
			this.TagMappingsVM = new HashSet<TagMappingViewModel>();
		}
		
	}
}
