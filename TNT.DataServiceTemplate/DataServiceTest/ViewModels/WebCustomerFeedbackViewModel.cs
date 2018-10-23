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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("fullname")]
		public string Fullname { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("company")]
		public string Company { get; set; }
		[JsonProperty("content")]
		public string Content { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("collection")]
		public string Collection { get; set; }
		[JsonProperty("customFields")]
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
