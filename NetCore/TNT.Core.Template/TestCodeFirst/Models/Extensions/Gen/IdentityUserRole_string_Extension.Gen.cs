using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.ViewModels;
using TestCodeFirst.Models;
using TestCodeFirst.Global;
using Microsoft.AspNetCore.Identity;

namespace TestCodeFirst.Models
{
	public partial class IdentityUserRole_string_PK
	{
		public string UserId { get; set; }
		public string RoleId { get; set; }
	}
	
}


namespace TestCodeFirst.Models.Extensions
{
	public static partial class IdentityUserRole_string_Extension
	{
		public static IdentityUserRole<string> Id(this IQueryable<IdentityUserRole<string>> query, IdentityUserRole_string_PK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
		public static IdentityUserRole<string> Id(this IEnumerable<IdentityUserRole<string>> query, IdentityUserRole_string_PK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
		public static bool Existed(this IQueryable<IdentityUserRole<string>> query, IdentityUserRole_string_PK key)
		{
			return query.Any(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
		}
		
	}
}
