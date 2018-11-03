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
	public partial class PriceNightViewModel: BaseViewModel<PriceNight>
	{
		[JsonProperty("room_price_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RoomPriceID { get; set; }
		[JsonProperty("price_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PriceGroupID { get; set; }
		[JsonProperty("start_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime StartTime { get; set; }
		[JsonProperty("end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime EndTime { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Price { get; set; }
		[JsonProperty("max_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MaxDuration { get; set; }
		[JsonProperty("price_per_hour", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double PricePerHour { get; set; }
		[JsonProperty("check_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CheckTime { get; set; }
		[JsonProperty("price_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PriceGroupViewModel PriceGroupVM { get; set; }
		
		public PriceNightViewModel(PriceNight entity) : this()
		{
			FromEntity(entity);
		}
		
		public PriceNightViewModel()
		{
		}
		
	}
}
