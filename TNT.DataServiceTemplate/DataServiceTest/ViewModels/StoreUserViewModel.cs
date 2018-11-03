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
	public partial class StoreUserViewModel: BaseViewModel<StoreUser>
	{
		[JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Username { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public StoreUserViewModel(StoreUser entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreUserViewModel()
		{
		}
		
	}
}
