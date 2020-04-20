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
	public partial class SeoKeywords : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class SeoKeywordsExtension
	{
		public static SeoKeywords Id(this IQueryable<SeoKeywords> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static SeoKeywords Id(this IEnumerable<SeoKeywords> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static bool Existed(this IQueryable<SeoKeywords> query, string key)
		{
			return query.Any(
				e => e.Value == key);
		}
		
	}
}