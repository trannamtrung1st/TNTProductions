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
	public partial class PartnerMappingViewModel: BaseViewModel<PartnerMapping>
	{
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("partnerId")]
		public Nullable<int> PartnerId { get; set; }
		[JsonProperty("config")]
		public string Config { get; set; }
		[JsonProperty("status")]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("partner")]
		public PartnerViewModel PartnerVM { get; set; }
		
		public PartnerMappingViewModel(PartnerMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public PartnerMappingViewModel()
		{
		}
		
	}
}
