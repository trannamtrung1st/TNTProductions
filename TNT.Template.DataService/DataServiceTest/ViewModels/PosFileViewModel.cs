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
	public partial class PosFileViewModel: BaseViewModel<PosFile>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("file_name")]
		public string FileName { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("version")]
		public string Version { get; set; }
		//[JsonProperty("pos_configs")]
		//public IEnumerable<PosConfigViewModel> PosConfigsVM { get; set; }
		
		public PosFileViewModel(PosFile entity) : this()
		{
			FromEntity(entity);
		}
		
		public PosFileViewModel()
		{
			//this.PosConfigsVM = new HashSet<PosConfigViewModel>();
		}
		
	}
}
