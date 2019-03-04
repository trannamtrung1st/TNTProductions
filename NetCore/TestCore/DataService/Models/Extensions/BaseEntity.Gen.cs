using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Global;

namespace DataService.Models
{
	public partial interface IBaseEntity
	{
		E To<E>();
		void CopyTo(object dest);
	}
	
	public abstract partial class BaseEntity : IBaseEntity
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
