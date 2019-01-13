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
	public partial class BViewModel: BaseViewModel<B>
	{
		//[JsonProperty("id")]
		public int Id { get; set; }
		//[JsonProperty("description")]
		public string Description { get; set; }
		
		public BViewModel(B entity) : base(entity)
		{
		}
		
		public BViewModel()
		{
		}
		
	}
}
