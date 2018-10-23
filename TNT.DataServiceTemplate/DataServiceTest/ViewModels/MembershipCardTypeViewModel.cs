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
		[JsonProperty("typeName")]
		public string TypeName { get; set; }
		[JsonProperty("appendCode")]
		public string AppendCode { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("isMobile")]
		public Nullable<bool> IsMobile { get; set; }
		[JsonProperty("typeLevel")]
		public Nullable<int> TypeLevel { get; set; }
		[JsonProperty("typePoint")]
		public Nullable<int> TypePoint { get; set; }
		[JsonProperty("membershipCards")]
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
