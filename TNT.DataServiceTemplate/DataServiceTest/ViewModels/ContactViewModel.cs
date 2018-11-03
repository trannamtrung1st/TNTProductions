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
	public partial class ContactViewModel: BaseViewModel<Contact>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("profile_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProfileUrl { get; set; }
		[JsonProperty("birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Birthday { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Username { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("organization", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Organization { get; set; }
		[JsonProperty("job", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Job { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Position { get; set; }
		[JsonProperty("first_location_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FirstLocationId { get; set; }
		[JsonProperty("fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; }
		[JsonProperty("total_visted", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalVisted { get; set; }
		[JsonProperty("type_contact_from", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TypeContactFrom { get; set; }
		[JsonProperty("last_visted", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastVisted { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		
		public ContactViewModel(Contact entity) : this()
		{
			FromEntity(entity);
		}
		
		public ContactViewModel()
		{
		}
		
	}
}
