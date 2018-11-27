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
	public partial class sysdiagramViewModel: BaseViewModel<sysdiagram>
	{
		[JsonProperty("name")]
		public string name { get; set; }
		[JsonProperty("principal__id")]
		public int principal_id { get; set; }
		[JsonProperty("diagram__id")]
		public int diagram_id { get; set; }
		[JsonProperty("version")]
		public Nullable<int> version { get; set; }
		[JsonProperty("definition")]
		public byte[] definition { get; set; }
		
		public sysdiagramViewModel(sysdiagram entity) : this()
		{
			FromEntity(entity);
		}
		
		public sysdiagramViewModel()
		{
		}
		
	}
}
