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
}


namespace TestCodeFirst.Models.Extensions
{
	public static partial class IdentityRoleClaim_string_Extension
	{
		public static IdentityRoleClaim<string> Id(this IQueryable<IdentityRoleClaim<string>> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static IdentityRoleClaim<string> Id(this IEnumerable<IdentityRoleClaim<string>> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<IdentityRoleClaim<string>> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
