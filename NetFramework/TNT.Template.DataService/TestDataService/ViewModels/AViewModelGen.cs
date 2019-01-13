using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Global;
using TestDataService.Models;
using Newtonsoft.Json;

namespace TestDataService.ViewModels
{
	public partial class AViewModel: BaseViewModel<A>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("name")]
		public string Name { get; set; }
		
		public AViewModel(A entity) : base(entity)
		{
		}
		
		public AViewModel()
		{
		}
		
	}
}
