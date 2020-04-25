using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models;
using TestDataService.Global;

namespace TestDataService.Models
{
}


namespace TestDataService.Models.Extensions
{
	public static partial class SeoKeywordExtension
	{
		public static SeoKeyword Id(this IQueryable<SeoKeyword> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static SeoKeyword Id(this IEnumerable<SeoKeyword> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static bool Existed(this IQueryable<SeoKeyword> query, string key)
		{
			return query.Any(
				e => e.Value == key);
		}
		
	}
}
