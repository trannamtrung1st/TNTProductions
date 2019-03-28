using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class Comment : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CommentExtension
	{
		public static Comment Id(this IQueryable<Comment> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Comment Id(this IEnumerable<Comment> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Comment> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Comment> Active(this IQueryable<Comment> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Comment> NotActive(this IQueryable<Comment> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Comment> Active(this IEnumerable<Comment> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Comment> NotActive(this IEnumerable<Comment> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
