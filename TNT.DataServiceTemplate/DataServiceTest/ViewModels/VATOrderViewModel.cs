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
		[JsonProperty("invoice_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InvoiceID { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandID { get; set; }
		[JsonProperty("vatorder_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VATOrderDetail { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("invoice_no", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string InvoiceNo { get; set; }
		[JsonProperty("check_in_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CheckInPerson { get; set; }
		[JsonProperty("check_in_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CheckInDate { get; set; }
		[JsonProperty("notes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Notes { get; set; }
		[JsonProperty("total", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Total { get; set; }
		[JsonProperty("vatamount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double VATAmount { get; set; }
		[JsonProperty("provider_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProviderID { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProviderViewModel ProviderVM { get; set; }
		[JsonProperty("vatorder_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
