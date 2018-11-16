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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("title__en")]
		public string Title_En { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description__en")]
		public string Description_En { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("create_date")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("update_date")]
		public Nullable<DateTime> UpdateDate { get; set; }
		[JsonProperty("pic_url")]
		public string PicUrl { get; set; }
		[JsonProperty("opening")]
		public string Opening { get; set; }
		[JsonProperty("content")]
		public string Content { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("customer_id")]
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
