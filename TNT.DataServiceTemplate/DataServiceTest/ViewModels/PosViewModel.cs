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
	public partial class PosViewModel: BaseViewModel<Pos>
	{
		[JsonProperty("pos_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosId { get; set; }
		[JsonProperty("mac_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MacId { get; set; }
		[JsonProperty("pos_config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PosConfig { get; set; }
		[JsonProperty("pos_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PosCode { get; set; }
		[JsonProperty("stores", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreViewModel> StoresVM { get; set; }
		
		public PosViewModel(Pos entity) : this()
		{
			FromEntity(entity);
		}
		
		public PosViewModel()
		{
			this.StoresVM = new HashSet<StoreViewModel>();
		}
		
	}
}
