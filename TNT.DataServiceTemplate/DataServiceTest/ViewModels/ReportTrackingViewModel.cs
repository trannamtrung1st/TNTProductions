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
	public partial class ReportTrackingViewModel: BaseViewModel<ReportTracking>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("date_update", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateUpdate { get; set; }
		[JsonProperty("update_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UpdatePerson { get; set; }
		[JsonProperty("is_update", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsUpdate { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public ReportTrackingViewModel(ReportTracking entity) : this()
		{
			FromEntity(entity);
		}
		
		public ReportTrackingViewModel()
		{
		}
		
	}
}
