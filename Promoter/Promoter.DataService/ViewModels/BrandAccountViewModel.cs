using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Global;
using Promoter.DataService.Models;
using Newtonsoft.Json;

namespace Promoter.DataService.ViewModels
{
	public partial class BrandAccountViewModel: BaseViewModel<BrandAccount>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		
		public BrandAccountViewModel(BrandAccount entity) : this()
		{
			FromEntity(entity);
		}
		
		public BrandAccountViewModel()
		{
		}
		
	}
}
