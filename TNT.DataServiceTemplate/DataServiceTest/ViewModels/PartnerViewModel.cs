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
	public partial class PartnerViewModel: BaseViewModel<Partner>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("partner_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PartnerCode { get; set; }
		[JsonProperty("partner_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PartnerName { get; set; }
		[JsonProperty("partner_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PartnerType { get; set; }
		[JsonProperty("avatar_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AvatarUrl { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("partner_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PartnerAddress { get; set; }
		[JsonProperty("partner_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PartnerMappingViewModel> PartnerMappingsVM { get; set; }
		
		public PartnerViewModel(Partner entity) : this()
		{
			FromEntity(entity);
		}
		
		public PartnerViewModel()
		{
			this.PartnerMappingsVM = new HashSet<PartnerMappingViewModel>();
		}
		
	}
}
