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
	public partial class DeviceViewModel: BaseViewModel<Device>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("device_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeviceName { get; set; }
		[JsonProperty("device_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeviceCode { get; set; }
		[JsonProperty("config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Config { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public DeviceViewModel(Device entity) : this()
		{
			FromEntity(entity);
		}
		
		public DeviceViewModel()
		{
		}
		
	}
}
