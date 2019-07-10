using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace TestDataService.Models
{
	public partial class Books : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class BooksExtension
	{
		public static Books Id(this IQueryable<Books> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static Books Id(this IEnumerable<Books> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static bool Existed(this IQueryable<Books> query, String id)
		{
			return query.Any(
				e => e.Id == id);
		}
		
	}
}
