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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("rentID")]
		public int RentID { get; set; }
		[JsonProperty("invoiceID")]
		public int InvoiceID { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("vATOrder")]
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
