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
	public partial class WebElementTypeViewModel: BaseViewModel<WebElementType>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("web_element_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> WebElementId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("template", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Template { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Position { get; set; }
		[JsonProperty("show_on_content_page", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> ShowOnContentPage { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("web_elements", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<WebElementViewModel> WebElementsVM { get; set; }
		
		public WebElementTypeViewModel(WebElementType entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebElementTypeViewModel()
		{
			this.WebElementsVM = new HashSet<WebElementViewModel>();
		}
		
	}
}
