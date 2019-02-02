using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class EventTrigger : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class EventTriggerExtension
	{
		public static EventTrigger Id(this IQueryable<EventTrigger> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static EventTrigger Id(this IEnumerable<EventTrigger> query, int key)
		{
			return query.FirstOrDefault(
				e => e.ID == key);
		}
		
		public static IQueryable<EventTrigger> Active(this IQueryable<EventTrigger> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<EventTrigger> NotActive(this IQueryable<EventTrigger> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<EventTrigger> Active(this IEnumerable<EventTrigger> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<EventTrigger> NotActive(this IEnumerable<EventTrigger> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
