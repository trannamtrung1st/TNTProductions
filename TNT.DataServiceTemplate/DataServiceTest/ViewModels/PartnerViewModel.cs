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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("partnerCode")]
		public string PartnerCode { get; set; }
		[JsonProperty("partnerName")]
		public string PartnerName { get; set; }
		[JsonProperty("partnerType")]
		public Nullable<int> PartnerType { get; set; }
		[JsonProperty("avatarUrl")]
		public string AvatarUrl { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("partnerAddress")]
		public string PartnerAddress { get; set; }
		[JsonProperty("partnerMappings")]
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
