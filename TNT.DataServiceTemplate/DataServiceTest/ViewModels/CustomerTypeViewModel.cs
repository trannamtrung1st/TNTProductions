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
	public partial class CustomerTypeViewModel: BaseViewModel<CustomerType>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("customer_type1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerType1 { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("customers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerViewModel> CustomersVM { get; set; }
		
		public CustomerTypeViewModel(CustomerType entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerTypeViewModel()
		{
			this.CustomersVM = new HashSet<CustomerViewModel>();
		}
		
	}
}
