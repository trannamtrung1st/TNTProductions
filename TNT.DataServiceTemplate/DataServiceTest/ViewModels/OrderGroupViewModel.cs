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
	public partial class OrderGroupViewModel: BaseViewModel<OrderGroup>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("source_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int SourceID { get; set; }
		[JsonProperty("booking_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime BookingDate { get; set; }
		[JsonProperty("get_room_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> GetRoomDate { get; set; }
		[JsonProperty("note", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Note { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("guests", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<GuestViewModel> GuestsVM { get; set; }
		[JsonProperty("sub_rent_groups", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<SubRentGroupViewModel> SubRentGroupsVM { get; set; }
		
		public OrderGroupViewModel(OrderGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderGroupViewModel()
		{
			this.GuestsVM = new HashSet<GuestViewModel>();
			this.SubRentGroupsVM = new HashSet<SubRentGroupViewModel>();
		}
		
	}
}
