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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("parent_id")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("detail")]
		public string Detail { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		//[JsonProperty("web_element_type")]
		//public WebElementTypeViewModel WebElementTypeVM { get; set; }
		
		public WebElementViewModel(WebElement entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebElementViewModel()
		{
		}
		
	}
}
