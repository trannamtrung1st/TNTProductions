using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial interface IEntity
	{
		IVM To<IVM>();
		void CopyTo(object dest);
	}
	
	public partial interface IBaseEntity<VM>: IEntity
	{
		VM ToViewModel();
	}
	
	public abstract partial class BaseEntity<VM> : IBaseEntity<VM>
	{
		public abstract VM ToViewModel();
		
		public virtual IVM To<IVM>()
		{
			return G.Mapper.Map<IVM>(this);
		}
		
		public virtual void CopyTo(object dest)
		{
			G.Mapper.Map(this, dest);
		}
		
	}
	
}
