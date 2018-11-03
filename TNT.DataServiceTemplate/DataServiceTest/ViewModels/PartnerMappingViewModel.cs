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
	public partial class PartnerMappingViewModel: BaseViewModel<PartnerMapping>
	{
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("partner_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PartnerId { get; set; }
		[JsonProperty("config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Config { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Status { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("partner", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
