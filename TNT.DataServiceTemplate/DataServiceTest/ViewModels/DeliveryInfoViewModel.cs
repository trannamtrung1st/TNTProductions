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
	public partial class DeliveryInfoViewModel: BaseViewModel<DeliveryInfo>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("customer_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerName { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("is_default_delivery_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> isDefaultDeliveryInfo { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
