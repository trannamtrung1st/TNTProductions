using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class AppUser : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class AppUserExtension
	{
		public static AppUser Id(this IQueryable<AppUser> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AppUser Id(this IEnumerable<AppUser> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static IQueryable<AppUser> Active(this IQueryable<AppUser> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<AppUser> NotActive(this IQueryable<AppUser> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<AppUser> Active(this IEnumerable<AppUser> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<AppUser> NotActive(this IEnumerable<AppUser> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
