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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("type_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TypeName { get; set; }
		[JsonProperty("append_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AppendCode { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("is_mobile", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsMobile { get; set; }
		[JsonProperty("type_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TypeLevel { get; set; }
		[JsonProperty("type_point", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TypePoint { get; set; }
		[JsonProperty("membership_cards", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<MembershipCardViewModel> MembershipCardsVM { get; set; }
		
		public MembershipCardTypeViewModel(MembershipCardType entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipCardTypeViewModel()
		{
			this.MembershipCardsVM = new HashSet<MembershipCardViewModel>();
		}
		
	}
}
