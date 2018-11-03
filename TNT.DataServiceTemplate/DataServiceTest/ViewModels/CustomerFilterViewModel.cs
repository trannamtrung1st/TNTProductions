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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("cus_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CusTypeID { get; set; }
		[JsonProperty("age_from", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AgeFrom { get; set; }
		[JsonProperty("age_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AgeTo { get; set; }
		[JsonProperty("birthday_month", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BirthdayMonth { get; set; }
		[JsonProperty("birthday_from", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> BirthdayFrom { get; set; }
		[JsonProperty("birthday_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> BirthdayTo { get; set; }
		[JsonProperty("birthday_option", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BirthdayOption { get; set; }
		[JsonProperty("gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("visited_times_from", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VisitedTimesFrom { get; set; }
		[JsonProperty("visited_times_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VisitedTimesTo { get; set; }
		[JsonProperty("is_enable_cus_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsEnableCusType { get; set; }
		[JsonProperty("is_enable_age", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsEnableAge { get; set; }
		[JsonProperty("is_enable_birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsEnableBirthday { get; set; }
		[JsonProperty("is_enable_gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsEnableGender { get; set; }
		[JsonProperty("is_enable_visited_times", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsEnableVisitedTimes { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
