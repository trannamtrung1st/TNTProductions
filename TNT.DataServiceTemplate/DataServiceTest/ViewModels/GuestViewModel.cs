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
	public partial class GuestViewModel: BaseViewModel<Guest>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("person_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PersonId { get; set; }
		[JsonProperty("birth_year", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BirthYear { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Sex { get; set; }
		[JsonProperty("rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentId { get; set; }
		[JsonProperty("rent_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentGroup { get; set; }
		[JsonProperty("note", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Note { get; set; }
		[JsonProperty("order_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderGroupViewModel OrderGroupVM { get; set; }
		
		public GuestViewModel(Guest entity) : this()
		{
			FromEntity(entity);
		}
		
		public GuestViewModel()
		{
		}
		
	}
}
