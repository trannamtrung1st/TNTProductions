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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("machine_id")]
		public int MachineID { get; set; }
		[JsonProperty("connect_time")]
		public Nullable<DateTime> ConnectTime { get; set; }
		[JsonProperty("connect_result")]
		public Nullable<bool> ConnectResult { get; set; }
		[JsonProperty("store_id")]
		public int StoreID { get; set; }
		[JsonProperty("brand_id")]
		public int BrandID { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("machine_name")]
		public string MachineName { get; set; }
		[JsonProperty("machine_code")]
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
