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
	public partial class PaymentPartnerViewModel: BaseViewModel<PaymentPartner>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("partner_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PartnerName { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("company_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CompanyName { get; set; }
		[JsonProperty("contact_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContactPerson { get; set; }
		[JsonProperty("phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PhoneNumber { get; set; }
		[JsonProperty("fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; }
		[JsonProperty("website", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Website { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("att1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att1 { get; set; }
		[JsonProperty("att2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att2 { get; set; }
		[JsonProperty("att3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att3 { get; set; }
		[JsonProperty("att4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att4 { get; set; }
		
		public PaymentPartnerViewModel(PaymentPartner entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaymentPartnerViewModel()
		{
		}
		
	}
}
