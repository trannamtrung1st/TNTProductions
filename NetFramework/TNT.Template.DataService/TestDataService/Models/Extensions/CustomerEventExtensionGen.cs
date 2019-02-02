using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class CustomerEvent : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CustomerEventExtension
	{
		public static CustomerEvent Id(this IQueryable<CustomerEvent> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static CustomerEvent Id(this IEnumerable<CustomerEvent> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
	}
}
