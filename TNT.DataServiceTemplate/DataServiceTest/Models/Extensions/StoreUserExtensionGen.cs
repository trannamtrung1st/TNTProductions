using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class StoreUserPK
	{
		public string Username { get; set; }
		public int StoreId { get; set; }
	}
	
	public partial class StoreUser : BaseEntity
	{
	}
}
