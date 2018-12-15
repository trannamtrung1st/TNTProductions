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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("rent_id")]
		public int RentID { get; set; }
		[JsonProperty("invoice_id")]
		public int InvoiceID { get; set; }
		//[JsonProperty("order")]
		//public OrderViewModel OrderVM { get; set; }
		//[JsonProperty("vatorder")]
		//public VATOrderViewModel VATOrderVM { get; set; }
		
		public VATOrderMappingViewModel(VATOrderMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public VATOrderMappingViewModel()
		{
		}
		
	}
}
