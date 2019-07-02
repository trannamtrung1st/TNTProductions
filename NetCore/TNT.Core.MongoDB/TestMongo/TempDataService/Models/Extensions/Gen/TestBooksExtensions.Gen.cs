using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace TempDataService.Models
{
	public partial class TestBooks : BaseEntity
	{
	}
	
}


namespace TempDataService.Models.Extensions
{
	public static partial class TestBooksExtension
	{
		public static TestBooks Id(this IMongoQueryable<TestBooks> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static TestBooks Id(this IEnumerable<TestBooks> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static bool Existed(this IMongoQueryable<TestBooks> query, String id)
		{
			return query.Any(
				e => e.Id == id);
		}
		
	}
}
