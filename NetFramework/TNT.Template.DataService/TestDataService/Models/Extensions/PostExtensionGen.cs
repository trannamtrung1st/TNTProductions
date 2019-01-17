using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class Post : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class PostExtension
	{
		public static Post Id(this IQueryable<Post> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Post Id(this IEnumerable<Post> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static IQueryable<Post> Active(this IQueryable<Post> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Post> NotActive(this IQueryable<Post> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Post> Active(this IEnumerable<Post> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Post> NotActive(this IEnumerable<Post> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
