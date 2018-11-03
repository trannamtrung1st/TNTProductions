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
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid UserId { get; set; }
		[JsonProperty("property_names", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PropertyNames { get; set; }
		[JsonProperty("property_value_strings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PropertyValueStrings { get; set; }
		[JsonProperty("property_value_binary", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public byte[] PropertyValueBinary { get; set; }
		[JsonProperty("last_updated_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime LastUpdatedDate { get; set; }
		[JsonProperty("user", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public UserViewModel UserVM { get; set; }
		
		public ProfileViewModel(Profile entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProfileViewModel()
		{
		}
		
	}
}
