using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class A : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class AExtension
	{
		public static A Id(this IQueryable<A> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static A Id(this IEnumerable<A> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
	}
}
