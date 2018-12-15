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
	public partial class MembershipCardTypeViewModel: BaseViewModel<MembershipCardType>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("type_name")]
		public string TypeName { get; set; }
		[JsonProperty("append_code")]
		public string AppendCode { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("is_mobile")]
		public Nullable<bool> IsMobile { get; set; }
		[JsonProperty("type_level")]
		public Nullable<int> TypeLevel { get; set; }
		[JsonProperty("type_point")]
		public Nullable<int> TypePoint { get; set; }
		//[JsonProperty("membership_cards")]
		//public IEnumerable<MembershipCardViewModel> MembershipCardsVM { get; set; }
		
		public MembershipCardTypeViewModel(MembershipCardType entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipCardTypeViewModel()
		{
			//this.MembershipCardsVM = new HashSet<MembershipCardViewModel>();
		}
		
	}
}
