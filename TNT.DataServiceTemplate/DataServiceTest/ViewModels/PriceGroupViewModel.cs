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
	public partial class PriceGroupViewModel: BaseViewModel<PriceGroup>
	{
		[JsonProperty("priceGroupID")]
		public int PriceGroupID { get; set; }
		[JsonProperty("priceGroupName")]
		public string PriceGroupName { get; set; }
		[JsonProperty("startDayTime")]
		public DateTime StartDayTime { get; set; }
		[JsonProperty("endNightTime")]
		public DateTime EndNightTime { get; set; }
		[JsonProperty("dayPrice")]
		public double DayPrice { get; set; }
		[JsonProperty("roundMinute")]
		public int RoundMinute { get; set; }
		[JsonProperty("firstHourPrice")]
		public double FirstHourPrice { get; set; }
		[JsonProperty("secondHourPrice")]
		public double SecondHourPrice { get; set; }
		[JsonProperty("thirdHourPrice")]
		public double ThirdHourPrice { get; set; }
		[JsonProperty("nextHourPrice")]
		public double NextHourPrice { get; set; }
		[JsonProperty("nightAdditionPriceID")]
		public int NightAdditionPriceID { get; set; }
		[JsonProperty("isAvailable")]
		public bool IsAvailable { get; set; }
		[JsonProperty("additionPrice")]
		public double AdditionPrice { get; set; }
		[JsonProperty("dayLimitTime1")]
		public int DayLimitTime1 { get; set; }
		[JsonProperty("dayPriceLimitTime1")]
		public double DayPriceLimitTime1 { get; set; }
		[JsonProperty("dayLimitTime2")]
		public int DayLimitTime2 { get; set; }
		[JsonProperty("dayPriceLimitTime2")]
		public double DayPriceLimitTime2 { get; set; }
		[JsonProperty("orderFeeItems")]
		public ICollection<OrderFeeItemViewModel> OrderFeeItemsVM { get; set; }
		[JsonProperty("roomCategoryPriceGroupMappings")]
		public ICollection<RoomCategoryPriceGroupMappingViewModel> RoomCategoryPriceGroupMappingsVM { get; set; }
		[JsonProperty("priceNights")]
		public ICollection<PriceNightViewModel> PriceNightsVM { get; set; }
		
		public PriceGroupViewModel(PriceGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public PriceGroupViewModel()
		{
			this.OrderFeeItemsVM = new HashSet<OrderFeeItemViewModel>();
			this.RoomCategoryPriceGroupMappingsVM = new HashSet<RoomCategoryPriceGroupMappingViewModel>();
			this.PriceNightsVM = new HashSet<PriceNightViewModel>();
		}
		
	}
}
