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
		[JsonProperty("room_price_id")]
		public int RoomPriceID { get; set; }
		[JsonProperty("price_group_id")]
		public int PriceGroupID { get; set; }
		[JsonProperty("start_time")]
		public DateTime StartTime { get; set; }
		[JsonProperty("end_time")]
		public DateTime EndTime { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("max_duration")]
		public int MaxDuration { get; set; }
		[JsonProperty("price_per_hour")]
		public double PricePerHour { get; set; }
		[JsonProperty("check_time")]
		public DateTime CheckTime { get; set; }
		//[JsonProperty("price_group")]
		//public PriceGroupViewModel PriceGroupVM { get; set; }
		
		public PriceNightViewModel(PriceNight entity) : this()
		{
			FromEntity(entity);
		}
		
		public PriceNightViewModel()
		{
		}
		
	}
}
