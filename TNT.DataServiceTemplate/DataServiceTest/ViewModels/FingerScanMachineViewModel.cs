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
	public partial class FingerScanMachineViewModel: BaseViewModel<FingerScanMachine>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("machineCode")]
		public string MachineCode { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("ip")]
		public string Ip { get; set; }
		[JsonProperty("brandOfMachine")]
		public string BrandOfMachine { get; set; }
		[JsonProperty("dateOfManufacture")]
		public Nullable<DateTime> DateOfManufacture { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("checkFingers")]
		public ICollection<CheckFingerViewModel> CheckFingersVM { get; set; }
		
		public FingerScanMachineViewModel(FingerScanMachine entity) : this()
		{
			FromEntity(entity);
		}
		
		public FingerScanMachineViewModel()
		{
			this.CheckFingersVM = new HashSet<CheckFingerViewModel>();
		}
		
	}
}
