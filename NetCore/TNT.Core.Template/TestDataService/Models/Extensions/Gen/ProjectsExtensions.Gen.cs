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
	public partial class Projects : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class ProjectsExtension
	{
		public static Projects Id(this IQueryable<Projects> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Projects Id(this IEnumerable<Projects> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Projects> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
