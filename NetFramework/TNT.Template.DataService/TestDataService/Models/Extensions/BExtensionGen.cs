using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class B : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class BExtension
	{
		public static B Id(this IQueryable<B> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static B Id(this IEnumerable<B> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
	}
}
