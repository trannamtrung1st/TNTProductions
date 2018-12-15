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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("gender")]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("profile_url")]
		public string ProfileUrl { get; set; }
		[JsonProperty("birthday")]
		public Nullable<DateTime> Birthday { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("create_date")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("organization")]
		public string Organization { get; set; }
		[JsonProperty("job")]
		public string Job { get; set; }
		[JsonProperty("position")]
		public string Position { get; set; }
		[JsonProperty("first_location_id")]
		public Nullable<int> FirstLocationId { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("total_visted")]
		public Nullable<int> TotalVisted { get; set; }
		[JsonProperty("type_contact_from")]
		public Nullable<int> TypeContactFrom { get; set; }
		[JsonProperty("last_visted")]
		public Nullable<DateTime> LastVisted { get; set; }
		//[JsonProperty("brand")]
		//public BrandViewModel BrandVM { get; set; }
		
		public ContactViewModel(Contact entity) : this()
		{
			FromEntity(entity);
		}
		
		public ContactViewModel()
		{
		}
		
	}
}
