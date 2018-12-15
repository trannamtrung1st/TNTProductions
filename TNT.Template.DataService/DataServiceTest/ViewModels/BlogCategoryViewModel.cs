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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("blog_cate_name")]
		public string BlogCateName { get; set; }
		[JsonProperty("blog_cate_name__en")]
		public string BlogCateName_EN { get; set; }
		[JsonProperty("pic_url")]
		public string PicUrl { get; set; }
		[JsonProperty("banner_url")]
		public string BannerUrl { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description__en")]
		public string Description_EN { get; set; }
		[JsonProperty("feedburner_url")]
		public string FeedburnerUrl { get; set; }
		[JsonProperty("page_title")]
		public string PageTitle { get; set; }
		[JsonProperty("page_title__en")]
		public string PageTitle_EN { get; set; }
		[JsonProperty("meta_description")]
		public string MetaDescription { get; set; }
		[JsonProperty("url_handle")]
		public string UrlHandle { get; set; }
		[JsonProperty("is_allow_comment")]
		public string IsAllowComment { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("is_active")]
		public bool IsActive { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("feedburner")]
		public string Feedburner { get; set; }
		[JsonProperty("seo_name")]
		public string SeoName { get; set; }
		[JsonProperty("seo_keyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("seo_description")]
		public string SeoDescription { get; set; }
		[JsonProperty("image_font_awsome_css")]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parent_cate_id")]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("position_topic_home_page")]
		public int PositionTopicHomePage { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("is_display")]
		public Nullable<bool> IsDisplay { get; set; }
		//[JsonProperty("blog_posts")]
		//public IEnumerable<BlogPostViewModel> BlogPostsVM { get; set; }
		//[JsonProperty("tag_mappings")]
		//public IEnumerable<TagMappingViewModel> TagMappingsVM { get; set; }
		
		public BlogCategoryViewModel(BlogCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public BlogCategoryViewModel()
		{
			//this.BlogPostsVM = new HashSet<BlogPostViewModel>();
			//this.TagMappingsVM = new HashSet<TagMappingViewModel>();
		}
		
	}
}
