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
		[JsonProperty("title_En")]
		public string Title_En { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("description_En")]
		public string Description_En { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("createDate")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("updateDate")]
		public Nullable<DateTime> UpdateDate { get; set; }
		[JsonProperty("picUrl")]
		public string PicUrl { get; set; }
		[JsonProperty("opening")]
		public string Opening { get; set; }
		[JsonProperty("content")]
		public string Content { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("customerId")]
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
