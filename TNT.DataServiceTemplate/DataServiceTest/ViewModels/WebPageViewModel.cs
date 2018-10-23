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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("pageContent")]
		public string PageContent { get; set; }
		[JsonProperty("pageTitle")]
		public string PageTitle { get; set; }
		[JsonProperty("metaDescription")]
		public string MetaDescription { get; set; }
		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("seoName")]
		public string SeoName { get; set; }
		[JsonProperty("metaKeyword")]
		public string MetaKeyword { get; set; }
		[JsonProperty("store")]
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
