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
	public partial class PaymentPartnerViewModel: BaseViewModel<PaymentPartner>
	{
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("partnerName")]
		public string PartnerName { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("companyName")]
		public string CompanyName { get; set; }
		[JsonProperty("contactPerson")]
		public string ContactPerson { get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("website")]
		public string Website { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("att1")]
		public string Att1 { get; set; }
		[JsonProperty("att2")]
		public string Att2 { get; set; }
		[JsonProperty("att3")]
		public string Att3 { get; set; }
		[JsonProperty("att4")]
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
