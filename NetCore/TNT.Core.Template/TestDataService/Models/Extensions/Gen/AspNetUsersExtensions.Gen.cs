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
	public partial class AspNetUsers : IBaseEntity
	{
		public virtual E To<E>()
		{
			return G.Mapper.Map<E>(this);
		}
		
		public virtual void CopyTo(object dest)
		{
			G.Mapper.Map(this, dest);
		}
		
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class AspNetUsersExtension
	{
		public static AspNetUsers Id(this IQueryable<AspNetUsers> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetUsers Id(this IEnumerable<AspNetUsers> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetUsers> query, string key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
