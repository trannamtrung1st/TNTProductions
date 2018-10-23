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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("title_En")]
		public string Title_En { get; set; }
		[JsonProperty("opening")]
		public string Opening { get; set; }
		[JsonProperty("opening_En")]
		public Nullable<int> Opening_En { get; set; }
		[JsonProperty("blogContent")]
		public string BlogContent { get; set; }
		[JsonProperty("blogContent_En")]
		public string BlogContent_En { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("image")]
		public string Image { get; set; }
		[JsonProperty("author")]
		public string Author { get; set; }
		[JsonProperty("createdTime")]
		public DateTime CreatedTime { get; set; }
		[JsonProperty("updatedTime")]
		public DateTime UpdatedTime { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("metaKeyword")]
		public string MetaKeyword { get; set; }
		[JsonProperty("totalVisit")]
		public Nullable<int> TotalVisit { get; set; }
		[JsonProperty("endDate")]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("startDate")]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("excerpt")]
		public string Excerpt { get; set; }
		[JsonProperty("uRL")]
		public string URL { get; set; }
		[JsonProperty("blogCategoryId")]
		public Nullable<int> BlogCategoryId { get; set; }
		[JsonProperty("pageTitle")]
		public string PageTitle { get; set; }
		[JsonProperty("pageTitle_En")]
		public string PageTitle_En { get; set; }
		[JsonProperty("metaDescription")]
		public string MetaDescription { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("lastUpdatePerson")]
		public string LastUpdatePerson { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("linkRef1")]
		public string LinkRef1 { get; set; }
		[JsonProperty("linkRef2")]
		public string LinkRef2 { get; set; }
		[JsonProperty("linkRef3")]
		public string LinkRef3 { get; set; }
		[JsonProperty("linkRef4")]
		public string LinkRef4 { get; set; }
		[JsonProperty("linkRef5")]
		public string LinkRef5 { get; set; }
		[JsonProperty("blogType")]
		public Nullable<int> BlogType { get; set; }
		[JsonProperty("locationId")]
		public Nullable<int> LocationId { get; set; }
		[JsonProperty("authorRefer")]
		public string AuthorRefer { get; set; }
		[JsonProperty("userApprove")]
		public string UserApprove { get; set; }
		[JsonProperty("publicDate")]
		public Nullable<DateTime> PublicDate { get; set; }
		[JsonProperty("blogPostCollectionNumber")]
		public Nullable<int> BlogPostCollectionNumber { get; set; }
		[JsonProperty("blogCategory")]
		public BlogCategoryViewModel BlogCategoryVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("blogPostCollectionItemMappings")]
		public ICollection<BlogPostCollectionItemMappingViewModel> BlogPostCollectionItemMappingsVM { get; set; }
		[JsonProperty("blogPostImages")]
		public ICollection<BlogPostImageViewModel> BlogPostImagesVM { get; set; }
		[JsonProperty("tagMappings")]
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
