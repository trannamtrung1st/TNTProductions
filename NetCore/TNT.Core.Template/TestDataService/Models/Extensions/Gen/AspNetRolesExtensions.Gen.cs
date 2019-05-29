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
	public partial class AspNetRoles : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class AspNetRolesExtension
	{
		public static AspNetRoles Id(this IQueryable<AspNetRoles> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetRoles Id(this IEnumerable<AspNetRoles> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetRoles> query, string key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
