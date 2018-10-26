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
	public partial class EventViewModel: BaseViewModel<Event>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("customerId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("sourceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SourceId { get; set; }
		[JsonProperty("sourceIdDataType", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SourceIdDataType { get; set; }
		[JsonProperty("sourceType", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SourceType { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("contentObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContentObject { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		
		public EventViewModel(Event entity) : this()
		{
			FromEntity(entity);
		}
		
		public EventViewModel()
		{
		}
		
	}
}
