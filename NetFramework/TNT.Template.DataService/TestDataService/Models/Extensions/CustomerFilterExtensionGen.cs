using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class CustomerFilter : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CustomerFilterExtension
	{
		public static CustomerFilter Id(this IQueryable<CustomerFilter> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static CustomerFilter Id(this IEnumerable<CustomerFilter> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static IQueryable<CustomerFilter> Active(this IQueryable<CustomerFilter> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<CustomerFilter> NotActive(this IQueryable<CustomerFilter> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<CustomerFilter> Active(this IEnumerable<CustomerFilter> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<CustomerFilter> NotActive(this IEnumerable<CustomerFilter> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
