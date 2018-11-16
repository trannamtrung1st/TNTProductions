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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("partner_id")]
		public int PartnerID { get; set; }
		[JsonProperty("store_id")]
		public int StoreID { get; set; }
		[JsonProperty("brand_id")]
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
