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
	public partial class Logs : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class LogsExtension
	{
		public static Logs Id(this IQueryable<Logs> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Logs Id(this IEnumerable<Logs> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Logs> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
