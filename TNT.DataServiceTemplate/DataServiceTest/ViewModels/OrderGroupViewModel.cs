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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("customerID")]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("sourceID")]
		public int SourceID { get; set; }
		[JsonProperty("bookingDate")]
		public DateTime BookingDate { get; set; }
		[JsonProperty("getRoomDate")]
		public Nullable<DateTime> GetRoomDate { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("guests")]
		public ICollection<GuestViewModel> GuestsVM { get; set; }
		[JsonProperty("subRentGroups")]
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
