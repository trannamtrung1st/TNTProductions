using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models.Entities;
using TestDataService.Global;

namespace TestDataService.Models.Entities
{
	public partial class Documents : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class DocumentsExtension
	{
		public static Documents Id(this IQueryable<Documents> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Code == key);
		}
		
		public static Documents Id(this IEnumerable<Documents> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Code == key);
		}
		
		public static bool Existed(this IQueryable<Documents> query, string key)
		{
			return query.Any(
				e => e.Code == key);
		}
		
	}
}
