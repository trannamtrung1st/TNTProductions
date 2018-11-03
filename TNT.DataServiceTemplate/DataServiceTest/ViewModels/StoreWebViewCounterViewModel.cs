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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("weekly_view_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int WeeklyViewCount { get; set; }
		[JsonProperty("monthly_view_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MonthlyViewCount { get; set; }
		[JsonProperty("total_view_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalViewCount { get; set; }
		[JsonProperty("last_update", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime LastUpdate { get; set; }
		[JsonProperty("today_view_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TodayViewCount { get; set; }
		[JsonProperty("yearly_view_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int YearlyViewCount { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
