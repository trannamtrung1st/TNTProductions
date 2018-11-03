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
	public partial class EventLocationViewModel: BaseViewModel<EventLocation>
	{
		[JsonProperty("location_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int LocationId { get; set; }
		[JsonProperty("location_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LocationName { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		
		public EventLocationViewModel(EventLocation entity) : this()
		{
			FromEntity(entity);
		}
		
		public EventLocationViewModel()
		{
		}
		
	}
}
