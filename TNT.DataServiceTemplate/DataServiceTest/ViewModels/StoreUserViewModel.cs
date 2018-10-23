﻿using System;
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
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("store")]
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
