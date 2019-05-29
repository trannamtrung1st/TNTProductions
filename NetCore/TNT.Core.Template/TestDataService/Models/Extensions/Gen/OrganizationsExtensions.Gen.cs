using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models.Entities;
using TestDataService.Global;

namespace TestDataService.Models.Entities
{
	public partial class Organizations : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class OrganizationsExtension
	{
		public static Organizations Id(this IQueryable<Organizations> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Organizations Id(this IEnumerable<Organizations> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Organizations> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
