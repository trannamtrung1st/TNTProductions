using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class Interactive : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class InteractiveExtension
	{
		public static Interactive Id(this IQueryable<Interactive> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Interactive Id(this IEnumerable<Interactive> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Interactive> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Interactive> Active(this IQueryable<Interactive> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Interactive> NotActive(this IQueryable<Interactive> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Interactive> Active(this IEnumerable<Interactive> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Interactive> NotActive(this IEnumerable<Interactive> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
