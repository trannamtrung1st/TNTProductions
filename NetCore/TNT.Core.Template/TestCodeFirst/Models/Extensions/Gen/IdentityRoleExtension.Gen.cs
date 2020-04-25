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
	public static partial class IdentityRoleExtension
	{
		public static IdentityRole Id(this IQueryable<IdentityRole> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static IdentityRole Id(this IEnumerable<IdentityRole> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<IdentityRole> query, string key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
