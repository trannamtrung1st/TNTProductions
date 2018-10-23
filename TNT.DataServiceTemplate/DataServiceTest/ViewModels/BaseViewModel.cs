using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;

namespace DataServiceTest.ViewModels
{
	public partial interface IViewModel
	{
		void CopyFrom(object src);
		void CopyTo(object dest);
		ET To<ET>();
	}
	
	public partial interface IBaseViewModel<E>: IViewModel
	{
		void FromEntity(E entity);
		E ToEntity();
	}
	
	public abstract partial class BaseViewModel<E>: IBaseViewModel<E>
	{
		protected E Entity { get; set; }
		
		public virtual void FromEntity(E entity)
		{
			Entity = entity;
			G.Mapper.Map(entity, this);
		}
		
		public virtual void CopyFrom(object src)
		{
			G.Mapper.Map(src, this);
		}
		
		public virtual void CopyTo(object dest)
		{
			G.Mapper.Map(this, dest);
		}
		
		public virtual ET To<ET>()
		{
			return G.Mapper.Map<ET>(this);
		}
		
		public virtual E ToEntity()
		{
			if (Entity!=null)
				return Entity;
			return G.Mapper.Map<E>(this);
		}
		
	}
	
}
