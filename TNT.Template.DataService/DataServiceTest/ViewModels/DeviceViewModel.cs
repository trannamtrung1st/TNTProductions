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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("device_name")]
		public string DeviceName { get; set; }
		[JsonProperty("device_code")]
		public string DeviceCode { get; set; }
		[JsonProperty("config")]
		public string Config { get; set; }
		[JsonProperty("status")]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public DeviceViewModel(Device entity) : this()
		{
			FromEntity(entity);
		}
		
		public DeviceViewModel()
		{
		}
		
	}
}
