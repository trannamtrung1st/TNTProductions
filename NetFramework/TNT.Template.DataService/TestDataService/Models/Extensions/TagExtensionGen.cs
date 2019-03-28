using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class Tag : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class TagExtension
	{
		public static Tag Id(this IQueryable<Tag> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Tag Id(this IEnumerable<Tag> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Tag> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Tag> Active(this IQueryable<Tag> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Tag> NotActive(this IQueryable<Tag> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Tag> Active(this IEnumerable<Tag> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Tag> NotActive(this IEnumerable<Tag> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
