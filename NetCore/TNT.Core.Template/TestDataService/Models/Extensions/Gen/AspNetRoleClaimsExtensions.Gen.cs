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
	public partial class AspNetRoleClaims : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class AspNetRoleClaimsExtension
	{
		public static AspNetRoleClaims Id(this IQueryable<AspNetRoleClaims> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetRoleClaims Id(this IEnumerable<AspNetRoleClaims> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetRoleClaims> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
