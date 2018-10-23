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
	public partial class VATOrderViewModel: BaseViewModel<VATOrder>
	{
		[JsonProperty("invoiceID")]
		public int InvoiceID { get; set; }
		[JsonProperty("brandID")]
		public int BrandID { get; set; }
		[JsonProperty("vATOrderDetail")]
		public string VATOrderDetail { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("invoiceNo")]
		public string InvoiceNo { get; set; }
		[JsonProperty("checkInPerson")]
		public string CheckInPerson { get; set; }
		[JsonProperty("checkInDate")]
		public DateTime CheckInDate { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("total")]
		public double Total { get; set; }
		[JsonProperty("vATAmount")]
		public double VATAmount { get; set; }
		[JsonProperty("providerID")]
		public int ProviderID { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("provider")]
		public ProviderViewModel ProviderVM { get; set; }
		[JsonProperty("vATOrderMappings")]
		public ICollection<VATOrderMappingViewModel> VATOrderMappingsVM { get; set; }
		
		public VATOrderViewModel(VATOrder entity) : this()
		{
			FromEntity(entity);
		}
		
		public VATOrderViewModel()
		{
			this.VATOrderMappingsVM = new HashSet<VATOrderMappingViewModel>();
		}
		
	}
}
