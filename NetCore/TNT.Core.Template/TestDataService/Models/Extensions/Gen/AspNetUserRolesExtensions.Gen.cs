using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class AspNetUserRolesPK
	{
		public string UserId { get; set; }
		public string RoleId { get; set; }
	}
	
	public partial class AspNetUserRoles : BaseEntity
	{
	}
	
}
