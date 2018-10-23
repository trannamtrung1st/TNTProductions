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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("protocol")]
		public string Protocol { get; set; }
		[JsonProperty("hostName")]
		public string HostName { get; set; }
		[JsonProperty("port")]
		public int Port { get; set; }
		[JsonProperty("directory")]
		public string Directory { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("store")]
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
