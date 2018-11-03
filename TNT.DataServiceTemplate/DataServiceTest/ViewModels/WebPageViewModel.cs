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
	public partial class WebPageViewModel: BaseViewModel<WebPage>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("page_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageContent { get; set; }
		[JsonProperty("page_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PageTitle { get; set; }
		[JsonProperty("meta_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetaDescription { get; set; }
		[JsonProperty("is_active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("seo_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SeoName { get; set; }
		[JsonProperty("meta_keyword", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetaKeyword { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public WebPageViewModel(WebPage entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebPageViewModel()
		{
		}
		
	}
}
