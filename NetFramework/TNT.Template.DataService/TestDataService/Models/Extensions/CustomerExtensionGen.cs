using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class Customer : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CustomerExtension
	{
		public static Customer Id(this IQueryable<Customer> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static Customer Id(this IEnumerable<Customer> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static IQueryable<Customer> Active(this IQueryable<Customer> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Customer> NotActive(this IQueryable<Customer> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Customer> Active(this IEnumerable<Customer> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Customer> NotActive(this IEnumerable<Customer> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
