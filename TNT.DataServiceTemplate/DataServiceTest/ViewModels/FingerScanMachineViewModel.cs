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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("machine_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MachineCode { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Url { get; set; }
		[JsonProperty("ip", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Ip { get; set; }
		[JsonProperty("brand_of_machine", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BrandOfMachine { get; set; }
		[JsonProperty("date_of_manufacture", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateOfManufacture { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("check_fingers", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
