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
	public partial class WebCustomerFeedbackViewModel: BaseViewModel<WebCustomerFeedback>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("fullname", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fullname { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("company", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Company { get; set; }
		[JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Content { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Collection { get; set; }
		[JsonProperty("custom_fields", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomFields { get; set; }
		
		public WebCustomerFeedbackViewModel(WebCustomerFeedback entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebCustomerFeedbackViewModel()
		{
		}
		
	}
}
