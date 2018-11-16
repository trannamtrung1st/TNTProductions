using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class AspNetUserLoginPK
	{
		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
		public string UserId { get; set; }
	}
	
	public partial class AspNetUserLogin : BaseEntity
	{
	}
}
