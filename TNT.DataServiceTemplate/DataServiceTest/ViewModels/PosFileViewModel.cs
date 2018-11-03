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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("file_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FileName { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("version", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Version { get; set; }
		[JsonProperty("pos_configs", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PosConfigViewModel> PosConfigsVM { get; set; }
		
		public PosFileViewModel(PosFile entity) : this()
		{
			FromEntity(entity);
		}
		
		public PosFileViewModel()
		{
			this.PosConfigsVM = new HashSet<PosConfigViewModel>();
		}
		
	}
}
