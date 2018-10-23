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
	public partial class CustomerFilterViewModel: BaseViewModel<CustomerFilter>
	{
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("cusTypeID")]
		public Nullable<int> CusTypeID { get; set; }
		[JsonProperty("ageFrom")]
		public Nullable<int> AgeFrom { get; set; }
		[JsonProperty("ageTo")]
		public Nullable<int> AgeTo { get; set; }
		[JsonProperty("birthdayMonth")]
		public Nullable<int> BirthdayMonth { get; set; }
		[JsonProperty("birthdayFrom")]
		public Nullable<DateTime> BirthdayFrom { get; set; }
		[JsonProperty("birthdayTo")]
		public Nullable<DateTime> BirthdayTo { get; set; }
		[JsonProperty("birthdayOption")]
		public Nullable<int> BirthdayOption { get; set; }
		[JsonProperty("gender")]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("visitedTimesFrom")]
		public Nullable<int> VisitedTimesFrom { get; set; }
		[JsonProperty("visitedTimesTo")]
		public Nullable<int> VisitedTimesTo { get; set; }
		[JsonProperty("isEnableCusType")]
		public Nullable<bool> IsEnableCusType { get; set; }
		[JsonProperty("isEnableAge")]
		public Nullable<bool> IsEnableAge { get; set; }
		[JsonProperty("isEnableBirthday")]
		public Nullable<bool> IsEnableBirthday { get; set; }
		[JsonProperty("isEnableGender")]
		public Nullable<bool> IsEnableGender { get; set; }
		[JsonProperty("isEnableVisitedTimes")]
		public Nullable<bool> IsEnableVisitedTimes { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		
		public CustomerFilterViewModel(CustomerFilter entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerFilterViewModel()
		{
		}
		
	}
}
