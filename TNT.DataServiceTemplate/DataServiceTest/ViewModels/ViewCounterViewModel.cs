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
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("onlineCount")]
		public int OnlineCount { get; set; }
		[JsonProperty("todayCount")]
		public int TodayCount { get; set; }
		[JsonProperty("thisWeekCount")]
		public int ThisWeekCount { get; set; }
		[JsonProperty("thisMonthCount")]
		public int ThisMonthCount { get; set; }
		[JsonProperty("totalCount")]
		public int TotalCount { get; set; }
		[JsonProperty("store")]
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
