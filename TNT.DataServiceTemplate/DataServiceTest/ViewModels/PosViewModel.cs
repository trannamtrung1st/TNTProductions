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
		[JsonProperty("posId")]
		public int PosId { get; set; }
		[JsonProperty("macId")]
		public string MacId { get; set; }
		[JsonProperty("posConfig")]
		public string PosConfig { get; set; }
		[JsonProperty("posCode")]
		public string PosCode { get; set; }
		[JsonProperty("stores")]
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
