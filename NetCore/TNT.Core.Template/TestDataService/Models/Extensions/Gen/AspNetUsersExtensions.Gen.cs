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
	public partial class AspNetUsers : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class AspNetUsersExtension
	{
		public static AspNetUsers Id(this IQueryable<AspNetUsers> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetUsers Id(this IEnumerable<AspNetUsers> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetUsers> query, string key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
