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
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string name { get; set; }
		[JsonProperty("principal__id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int principal_id { get; set; }
		[JsonProperty("diagram__id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int diagram_id { get; set; }
		[JsonProperty("version", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> version { get; set; }
		[JsonProperty("definition", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
