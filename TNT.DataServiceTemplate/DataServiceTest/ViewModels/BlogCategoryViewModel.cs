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
		[JsonProperty("blogCateName")]
		public string BlogCateName { get; set; }
		[JsonProperty("blogCateName_EN")]
		public string BlogCateName_EN { get; set; }
		[JsonProperty("picUrl")]
		public string PicUrl { get; set; }
		[JsonProperty("bannerUrl")]
		public string BannerUrl { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description_EN")]
		public string Description_EN { get; set; }
		[JsonProperty("feedburnerUrl")]
		public string FeedburnerUrl { get; set; }
		[JsonProperty("pageTitle")]
		public string PageTitle { get; set; }
		[JsonProperty("pageTitle_EN")]
		public string PageTitle_EN { get; set; }
		[JsonProperty("metaDescription")]
		public string MetaDescription { get; set; }
		[JsonProperty("urlHandle")]
		public string UrlHandle { get; set; }
		[JsonProperty("isAllowComment")]
		public string IsAllowComment { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("feedburner")]
		public string Feedburner { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("seoKeyword")]
		public string SeoKeyword { get; set; }
		[JsonProperty("seoDescription")]
		public string SeoDescription { get; set; }
		[JsonProperty("imageFontAwsomeCss")]
		public string ImageFontAwsomeCss { get; set; }
		[JsonProperty("parentCateId")]
		public Nullable<int> ParentCateId { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("positionTopicHomePage")]
		public int PositionTopicHomePage { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("isDisplay")]
		public Nullable<bool> IsDisplay { get; set; }
		[JsonProperty("blogPosts")]
		public ICollection<BlogPostViewModel> BlogPostsVM { get; set; }
		[JsonProperty("tagMappings")]
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
