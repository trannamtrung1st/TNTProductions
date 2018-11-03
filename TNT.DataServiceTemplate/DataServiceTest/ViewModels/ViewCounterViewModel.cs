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
	public partial class ViewCounterViewModel: BaseViewModel<ViewCounter>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("online_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OnlineCount { get; set; }
		[JsonProperty("today_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TodayCount { get; set; }
		[JsonProperty("this_week_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ThisWeekCount { get; set; }
		[JsonProperty("this_month_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ThisMonthCount { get; set; }
		[JsonProperty("total_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalCount { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public ViewCounterViewModel(ViewCounter entity) : this()
		{
			FromEntity(entity);
		}
		
		public ViewCounterViewModel()
		{
		}
		
	}
}
