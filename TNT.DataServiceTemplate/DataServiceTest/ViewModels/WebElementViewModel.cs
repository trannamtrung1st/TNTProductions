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
	public partial class WebElementViewModel: BaseViewModel<WebElement>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("parent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Detail { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("web_element_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public WebElementTypeViewModel WebElementTypeVM { get; set; }
		
		public WebElementViewModel(WebElement entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebElementViewModel()
		{
		}
		
	}
}
