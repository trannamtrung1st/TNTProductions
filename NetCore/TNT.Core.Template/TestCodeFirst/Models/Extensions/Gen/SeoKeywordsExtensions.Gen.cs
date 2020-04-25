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
	public partial class SeoKeywords : IBaseEntity
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


namespace TestCodeFirst.Models.Extensions
{
	public static partial class SeoKeywordsExtension
	{
		public static SeoKeywords Id(this IQueryable<SeoKeywords> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static SeoKeywords Id(this IEnumerable<SeoKeywords> query, string key)
		{
			return query.FirstOrDefault(
				e => e.Value == key);
		}
		
		public static bool Existed(this IQueryable<SeoKeywords> query, string key)
		{
			return query.Any(
				e => e.Value == key);
		}
		
	}
}
