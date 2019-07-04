using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace TempDataService.Models
{
	public partial class BooksTests : BaseEntity
	{
	}
	
}


namespace TempDataService.Models.Extensions
{
	public static partial class BooksTestsExtension
	{
		public static BooksTests Id(this IMongoQueryable<BooksTests> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static BooksTests Id(this IEnumerable<BooksTests> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static bool Existed(this IMongoQueryable<BooksTests> query, String id)
		{
			return query.Any(
				e => e.Id == id);
		}
		
	}
}
