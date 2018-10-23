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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("key")]
		public string Key { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("posFileId")]
		public int PosFileId { get; set; }
		[JsonProperty("posFile")]
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
