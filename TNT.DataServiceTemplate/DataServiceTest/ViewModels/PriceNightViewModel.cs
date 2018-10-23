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
		[JsonProperty("roomPriceID")]
		public int RoomPriceID { get; set; }
		[JsonProperty("priceGroupID")]
		public int PriceGroupID { get; set; }
		[JsonProperty("startTime")]
		public DateTime StartTime { get; set; }
		[JsonProperty("endTime")]
		public DateTime EndTime { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("maxDuration")]
		public int MaxDuration { get; set; }
		[JsonProperty("pricePerHour")]
		public double PricePerHour { get; set; }
		[JsonProperty("checkTime")]
		public DateTime CheckTime { get; set; }
		[JsonProperty("priceGroup")]
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
