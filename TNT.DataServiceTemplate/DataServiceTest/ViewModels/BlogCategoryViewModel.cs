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
	public partial class BlogCategoryViewModel: BaseViewModel<BlogCategory>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("blog_cate_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BlogCateName { get; set; }
		[JsonProperty("blog_cate_name__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BlogCateName_EN { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PicUrl { get; set; }
		[JsonProperty("banner_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BannerUrl { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("description__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description_EN { get; set; }
		[JsonProperty("feedburner_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FeedburnerUrl { get; set; }
		[JsonProperty("page_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageTitle { get; set; }
		[JsonProperty("page_title__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageTitle_EN { get; set; }
		[JsonProperty("meta_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetaDescription { get; set; }
		[JsonProperty("url_handle", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UrlHandle { get; set; }
		[JsonProperty("is_allow_comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IsAllowComment { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("feedburner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Feedburner { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("seo_keyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoKeyword { get; set; }
		[JsonProperty("seo_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoDescription { get; set; }
		[JsonProperty("image_font_awsome_css", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parent_cate_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("position_topic_home_page", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PositionTopicHomePage { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("is_display", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDisplay { get; set; }
		[JsonProperty("blog_posts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<BlogPostViewModel> BlogPostsVM { get; set; }
		[JsonProperty("tag_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TagMappingViewModel> TagMappingsVM { get; set; }
		
		public BlogCategoryViewModel(BlogCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogCategoryViewModel()
		{
			this.BlogPostsVM = new HashSet<BlogPostViewModel>();
			this.TagMappingsVM = new HashSet<TagMappingViewModel>();
		}
		
	}
}
