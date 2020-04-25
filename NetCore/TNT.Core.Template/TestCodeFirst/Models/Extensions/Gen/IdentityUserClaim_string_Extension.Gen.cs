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
	public static partial class IdentityUserClaim_string_Extension
	{
		public static IdentityUserClaim<string> Id(this IQueryable<IdentityUserClaim<string>> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static IdentityUserClaim<string> Id(this IEnumerable<IdentityUserClaim<string>> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<IdentityUserClaim<string>> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
