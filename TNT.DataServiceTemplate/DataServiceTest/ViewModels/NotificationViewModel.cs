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
	public partial class NotificationViewModel: BaseViewModel<Notification>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("title__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title_En { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("description__en", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description_En { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("update_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> UpdateDate { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PicUrl { get; set; }
		[JsonProperty("opening", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Opening { get; set; }
		[JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Content { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		
		public NotificationViewModel(Notification entity) : this()
		{
			FromEntity(entity);
		}
		
		public NotificationViewModel()
		{
		}
		
	}
}
