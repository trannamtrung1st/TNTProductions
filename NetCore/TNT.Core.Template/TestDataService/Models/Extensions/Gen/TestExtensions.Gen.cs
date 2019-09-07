using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace TestDataService.Models
{
	public partial class Test : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class TestExtension
	{
		public static Test Id(this IQueryable<Test> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static Test Id(this IEnumerable<Test> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static bool Existed(this IQueryable<Test> query, String id)
		{
			return query.Any(
				e => e.Id == id);
		}
		
	}
}
