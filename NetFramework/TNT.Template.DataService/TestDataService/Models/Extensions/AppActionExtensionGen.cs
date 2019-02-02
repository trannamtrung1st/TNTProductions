using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class AppAction : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class AppActionExtension
	{
		public static AppAction Id(this IQueryable<AppAction> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static AppAction Id(this IEnumerable<AppAction> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
	}
}
