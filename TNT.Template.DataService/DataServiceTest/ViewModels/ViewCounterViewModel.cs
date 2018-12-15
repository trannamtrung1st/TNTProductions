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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("online_count")]
		public int OnlineCount { get; set; }
		[JsonProperty("today_count")]
		public int TodayCount { get; set; }
		[JsonProperty("this_week_count")]
		public int ThisWeekCount { get; set; }
		[JsonProperty("this_month_count")]
		public int ThisMonthCount { get; set; }
		[JsonProperty("total_count")]
		public int TotalCount { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public ViewCounterViewModel(ViewCounter entity) : this()
		{
			FromEntity(entity);
		}
		
		public ViewCounterViewModel()
		{
		}
		
	}
}
