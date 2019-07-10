using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace TestDataService.Models
{
	public partial class TNT : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class TNTExtension
	{
		public static TNT Id(this IQueryable<TNT> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static TNT Id(this IEnumerable<TNT> query, String id)
		{
			return query.FirstOrDefault(
				e => e.Id == id);
		}
		
		public static bool Existed(this IQueryable<TNT> query, String id)
		{
			return query.Any(
				e => e.Id == id);
		}
		
	}
}
