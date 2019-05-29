using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models.Entities;
using TestDataService.Global;

namespace TestDataService.Models.Entities
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


namespace TestDataService.Models.Extensions
{
	public static partial class AspNetUserRolesExtension
	{
		public static AspNetUserRoles Id(this IQueryable<AspNetUserRoles> query, AspNetUserRolesPK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
		public static AspNetUserRoles Id(this IEnumerable<AspNetUserRoles> query, AspNetUserRolesPK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
		public static bool Existed(this IQueryable<AspNetUserRoles> query, AspNetUserRolesPK key)
		{
			return query.Any(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
	}
}
