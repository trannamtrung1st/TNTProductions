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
	public partial class EmployeeInStoreViewModel: BaseViewModel<EmployeeInStore>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("employeeId")]
		public int EmployeeId { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("assignedDate")]
		public DateTime AssignedDate { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("employee")]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public EmployeeInStoreViewModel(EmployeeInStore entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeInStoreViewModel()
		{
		}
		
	}
}
