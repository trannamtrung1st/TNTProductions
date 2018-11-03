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
	public partial class PosConfigViewModel: BaseViewModel<PosConfig>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("key", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Key { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Value { get; set; }
		[JsonProperty("pos_file_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosFileId { get; set; }
		[JsonProperty("pos_file", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PosFileViewModel PosFileVM { get; set; }
		
		public PosConfigViewModel(PosConfig entity) : this()
		{
			FromEntity(entity);
		}
		
		public PosConfigViewModel()
		{
		}
		
	}
}
