using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class AppActionViewModel: BaseViewModel<AppAction>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("customer_iid")]
		public Nullable<int> CustomerIID { get; set; }
		[JsonProperty("source_id")]
		public string SourceId { get; set; }
		[JsonProperty("source_type")]
		public Nullable<int> SourceType { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("content_object")]
		public string ContentObject { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		
		public AppActionViewModel(AppAction entity) : this()
		{
			FromEntity(entity);
		}
		
		public AppActionViewModel()
		{
		}
		
	}
}
