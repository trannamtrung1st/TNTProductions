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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("customerType1")]
		public string CustomerType1 { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("customers")]
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
