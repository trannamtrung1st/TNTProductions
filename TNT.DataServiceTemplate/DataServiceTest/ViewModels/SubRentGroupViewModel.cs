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
	public partial class SubRentGroupViewModel: BaseViewModel<SubRentGroup>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("roomType")]
		public int RoomType { get; set; }
		[JsonProperty("fromDate")]
		public DateTime FromDate { get; set; }
		[JsonProperty("toDate")]
		public DateTime ToDate { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("servicedQuantity")]
		public Nullable<int> ServicedQuantity { get; set; }
		[JsonProperty("rentGroupID")]
		public int RentGroupID { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("sourceId")]
		public Nullable<int> SourceId { get; set; }
		[JsonProperty("orderGroup")]
		public OrderGroupViewModel OrderGroupVM { get; set; }
		[JsonProperty("roomCategory")]
		public RoomCategoryViewModel RoomCategoryVM { get; set; }
		
		public SubRentGroupViewModel(SubRentGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public SubRentGroupViewModel()
		{
		}
		
	}
}
