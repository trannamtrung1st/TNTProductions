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
	public partial class AttendanceDateViewModel: BaseViewModel<AttendanceDate>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("dateReport")]
		public DateTime DateReport { get; set; }
		[JsonProperty("totalEmployee")]
		public int TotalEmployee { get; set; }
		[JsonProperty("totalOnTimeEmployee")]
		public int TotalOnTimeEmployee { get; set; }
		[JsonProperty("totalSession")]
		public int TotalSession { get; set; }
		[JsonProperty("totalOnTimeSession")]
		public int TotalOnTimeSession { get; set; }
		[JsonProperty("totalMissSession")]
		public int TotalMissSession { get; set; }
		[JsonProperty("totalMissEmployee")]
		public int TotalMissEmployee { get; set; }
		[JsonProperty("totalComeLate")]
		public int TotalComeLate { get; set; }
		[JsonProperty("totalComeOnTime")]
		public int TotalComeOnTime { get; set; }
		[JsonProperty("totalReturnEarly")]
		public int TotalReturnEarly { get; set; }
		[JsonProperty("totalReturnOntime")]
		public int TotalReturnOntime { get; set; }
		[JsonProperty("totalWorkingTime")]
		public System.TimeSpan TotalWorkingTime { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public AttendanceDateViewModel(AttendanceDate entity) : this()
		{
			FromEntity(entity);
		}
		
		public AttendanceDateViewModel()
		{
		}
		
	}
}
