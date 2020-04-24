using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.ViewModels;
using TestCodeFirst.Models;
using TestCodeFirst.Global;

namespace TestCodeFirst.Models
{
	public partial class AspNetUsers : BaseEntity
	{
	}
	
}


namespace TestCodeFirst.Models.Extensions
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
