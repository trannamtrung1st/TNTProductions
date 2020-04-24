using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.ViewModels;
using TestCodeFirst.Models;
using TestCodeFirst.Global;

namespace TestCodeFirst.Models
{
	public partial class Products : BaseEntity
	{
	}
	
}


namespace TestCodeFirst.Models.Extensions
{
	public static partial class ProductsExtension
	{
		public static Products Id(this IQueryable<Products> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Products Id(this IEnumerable<Products> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Products> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
