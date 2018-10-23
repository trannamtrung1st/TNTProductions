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
	public partial class StoreWebViewCounterViewModel: BaseViewModel<StoreWebViewCounter>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("weeklyViewCount")]
		public int WeeklyViewCount { get; set; }
		[JsonProperty("monthlyViewCount")]
		public int MonthlyViewCount { get; set; }
		[JsonProperty("totalViewCount")]
		public int TotalViewCount { get; set; }
		[JsonProperty("lastUpdate")]
		public DateTime LastUpdate { get; set; }
		[JsonProperty("todayViewCount")]
		public int TodayViewCount { get; set; }
		[JsonProperty("yearlyViewCount")]
		public int YearlyViewCount { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public StoreWebViewCounterViewModel(StoreWebViewCounter entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreWebViewCounterViewModel()
		{
		}
		
	}
}
