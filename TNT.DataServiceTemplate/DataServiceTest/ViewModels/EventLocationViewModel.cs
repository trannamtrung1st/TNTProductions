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
		[JsonProperty("locationId")]
		public int LocationId { get; set; }
		[JsonProperty("locationName")]
		public string LocationName { get; set; }
		[JsonProperty("active")]
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
