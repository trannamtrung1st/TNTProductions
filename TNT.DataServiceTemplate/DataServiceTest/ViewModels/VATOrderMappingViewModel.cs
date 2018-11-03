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
	public partial class VATOrderMappingViewModel: BaseViewModel<VATOrderMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentID { get; set; }
		[JsonProperty("invoice_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InvoiceID { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("vatorder", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VATOrderViewModel VATOrderVM { get; set; }
		
		public VATOrderMappingViewModel(VATOrderMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public VATOrderMappingViewModel()
		{
		}
		
	}
}
