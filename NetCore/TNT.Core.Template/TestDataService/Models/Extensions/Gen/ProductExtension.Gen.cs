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
	public static partial class ProductExtension
	{
		public static Product Id(this IQueryable<Product> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Product Id(this IEnumerable<Product> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Product> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
