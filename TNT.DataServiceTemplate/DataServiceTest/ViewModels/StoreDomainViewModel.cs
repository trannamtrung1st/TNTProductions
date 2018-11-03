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
	public partial class StoreDomainViewModel: BaseViewModel<StoreDomain>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Protocol { get; set; }
		[JsonProperty("host_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string HostName { get; set; }
		[JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Port { get; set; }
		[JsonProperty("directory", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Directory { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public StoreDomainViewModel(StoreDomain entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreDomainViewModel()
		{
		}
		
	}
}
