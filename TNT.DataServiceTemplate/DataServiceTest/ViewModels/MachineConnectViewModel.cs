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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("machineID")]
		public int MachineID { get; set; }
		[JsonProperty("connectTime")]
		public Nullable<DateTime> ConnectTime { get; set; }
		[JsonProperty("connectResult")]
		public Nullable<bool> ConnectResult { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("brandID")]
		public int BrandID { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("machineName")]
		public string MachineName { get; set; }
		[JsonProperty("machineCode")]
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
