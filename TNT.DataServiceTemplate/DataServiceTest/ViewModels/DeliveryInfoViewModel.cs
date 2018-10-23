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
	public partial class DeliveryInfoViewModel: BaseViewModel<DeliveryInfo>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("customerId")]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("customerName")]
		public string CustomerName { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("isDefaultDeliveryInfo")]
		public Nullable<bool> isDefaultDeliveryInfo { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		
		public DeliveryInfoViewModel(DeliveryInfo entity) : this()
		{
			FromEntity(entity);
		}
		
		public DeliveryInfoViewModel()
		{
		}
		
	}
}
