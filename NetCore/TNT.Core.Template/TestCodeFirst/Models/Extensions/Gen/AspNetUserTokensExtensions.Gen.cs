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
	public partial class AspNetUserTokensPK
	{
		public string UserId { get; set; }
		public string LoginProvider { get; set; }
		public string Name { get; set; }
	}
	
	public partial class AspNetUserTokens : IBaseEntity
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
	public static partial class AspNetUserTokensExtension
	{
		public static AspNetUserTokens Id(this IQueryable<AspNetUserTokens> query, AspNetUserTokensPK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
		}
		
		public static AspNetUserTokens Id(this IEnumerable<AspNetUserTokens> query, AspNetUserTokensPK key)
		{
			return query.FirstOrDefault(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
		}
		
		public static bool Existed(this IQueryable<AspNetUserTokens> query, AspNetUserTokensPK key)
		{
			return query.Any(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
		}
		
	}
}
