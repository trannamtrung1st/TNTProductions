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
	public partial class ProfileViewModel: BaseViewModel<Profile>
	{
		[JsonProperty("user_id")]
		public System.Guid UserId { get; set; }
		[JsonProperty("property_names")]
		public string PropertyNames { get; set; }
		[JsonProperty("property_value_strings")]
		public string PropertyValueStrings { get; set; }
		[JsonProperty("property_value_binary")]
		public byte[] PropertyValueBinary { get; set; }
		[JsonProperty("last_updated_date")]
		public DateTime LastUpdatedDate { get; set; }
		//[JsonProperty("user")]
		//public UserViewModel UserVM { get; set; }
		
		public ProfileViewModel(Profile entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProfileViewModel()
		{
		}
		
	}
}
