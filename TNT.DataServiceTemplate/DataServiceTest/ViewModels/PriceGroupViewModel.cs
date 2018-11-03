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
		[JsonProperty("price_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PriceGroupID { get; set; }
		[JsonProperty("price_group_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PriceGroupName { get; set; }
		[JsonProperty("start_day_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime StartDayTime { get; set; }
		[JsonProperty("end_night_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime EndNightTime { get; set; }
		[JsonProperty("day_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DayPrice { get; set; }
		[JsonProperty("round_minute", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RoundMinute { get; set; }
		[JsonProperty("first_hour_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double FirstHourPrice { get; set; }
		[JsonProperty("second_hour_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double SecondHourPrice { get; set; }
		[JsonProperty("third_hour_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double ThirdHourPrice { get; set; }
		[JsonProperty("next_hour_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double NextHourPrice { get; set; }
		[JsonProperty("night_addition_price_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int NightAdditionPriceID { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAvailable { get; set; }
		[JsonProperty("addition_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double AdditionPrice { get; set; }
		[JsonProperty("day_limit_time1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DayLimitTime1 { get; set; }
		[JsonProperty("day_price_limit_time1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DayPriceLimitTime1 { get; set; }
		[JsonProperty("day_limit_time2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DayLimitTime2 { get; set; }
		[JsonProperty("day_price_limit_time2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DayPriceLimitTime2 { get; set; }
		[JsonProperty("order_fee_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderFeeItemViewModel> OrderFeeItemsVM { get; set; }
		[JsonProperty("room_category_price_group_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoomCategoryPriceGroupMappingViewModel> RoomCategoryPriceGroupMappingsVM { get; set; }
		[JsonProperty("price_nights", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
