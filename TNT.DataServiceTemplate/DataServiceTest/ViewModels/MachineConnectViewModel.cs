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
	public partial class MachineConnectViewModel: BaseViewModel<MachineConnect>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("machine_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MachineID { get; set; }
		[JsonProperty("connect_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ConnectTime { get; set; }
		[JsonProperty("connect_result", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> ConnectResult { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandID { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("machine_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MachineName { get; set; }
		[JsonProperty("machine_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MachineCode { get; set; }
		
		public MachineConnectViewModel(MachineConnect entity) : this()
		{
			FromEntity(entity);
		}
		
		public MachineConnectViewModel()
		{
		}
		
	}
}
