﻿using System;
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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("date")]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("dateUpdate")]
		public Nullable<DateTime> DateUpdate { get; set; }
		[JsonProperty("updatePerson")]
		public string UpdatePerson { get; set; }
		[JsonProperty("isUpdate")]
		public Nullable<bool> IsUpdate { get; set; }
		[JsonProperty("store")]
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
