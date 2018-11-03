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
	public partial class LanguageKeyViewModel: BaseViewModel<LanguageKey>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("language_values", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<LanguageValueViewModel> LanguageValuesVM { get; set; }
		
		public LanguageKeyViewModel(LanguageKey entity) : this()
		{
			FromEntity(entity);
		}
		
		public LanguageKeyViewModel()
		{
			this.LanguageValuesVM = new HashSet<LanguageValueViewModel>();
		}
		
	}
}
