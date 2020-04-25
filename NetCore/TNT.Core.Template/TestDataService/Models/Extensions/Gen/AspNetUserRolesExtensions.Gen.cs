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
	
	public partial class AspNetUserRoles : IBaseEntity
	{
		public virtual E To<E>()
		{
			return G.Mapper.Map<E>(this);
		}
		
		public virtual void CopyTo(object dest)
		{
			G.Mapper.Map(this, dest);
		}
		
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
