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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("webElementId")]
		public Nullable<int> WebElementId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("template")]
		public Nullable<int> Template { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("showOnContentPage")]
		public Nullable<bool> ShowOnContentPage { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("webElements")]
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
