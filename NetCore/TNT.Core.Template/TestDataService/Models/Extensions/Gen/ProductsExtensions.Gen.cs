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
	public partial class Products : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class ProductsExtension
	{
		public static Products Id(this IQueryable<Products> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Products Id(this IEnumerable<Products> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Products> query, string key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
