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
		[JsonProperty("userId")]
		public System.Guid UserId { get; set; }
		[JsonProperty("propertyNames")]
		public string PropertyNames { get; set; }
		[JsonProperty("propertyValueStrings")]
		public string PropertyValueStrings { get; set; }
		[JsonProperty("propertyValueBinary")]
		public byte[] PropertyValueBinary { get; set; }
		[JsonProperty("lastUpdatedDate")]
		public DateTime LastUpdatedDate { get; set; }
		[JsonProperty("user")]
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
