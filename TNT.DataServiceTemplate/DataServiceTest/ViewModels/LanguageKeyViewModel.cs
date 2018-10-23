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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("languageValues")]
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
