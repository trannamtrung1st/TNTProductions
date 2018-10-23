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
	public partial class SystemPartnerMappingViewModel: BaseViewModel<SystemPartnerMapping>
	{
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("partnerID")]
		public int PartnerID { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("brandID")]
		public int BrandID { get; set; }
		[JsonProperty("att1")]
		public string Att1 { get; set; }
		[JsonProperty("att2")]
		public string Att2 { get; set; }
		[JsonProperty("att3")]
		public string Att3 { get; set; }
		[JsonProperty("att4")]
		public string Att4 { get; set; }
		
		public SystemPartnerMappingViewModel(SystemPartnerMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public SystemPartnerMappingViewModel()
		{
		}
		
	}
}
