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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("person_id")]
		public string PersonId { get; set; }
		[JsonProperty("birth_year")]
		public Nullable<int> BirthYear { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("sex")]
		public Nullable<bool> Sex { get; set; }
		[JsonProperty("rent_id")]
		public Nullable<int> RentId { get; set; }
		[JsonProperty("rent_group")]
		public Nullable<int> RentGroup { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		//[JsonProperty("order_group")]
		//public OrderGroupViewModel OrderGroupVM { get; set; }
		
		public GuestViewModel(Guest entity) : this()
		{
			FromEntity(entity);
		}
		
		public GuestViewModel()
		{
		}
		
	}
}
