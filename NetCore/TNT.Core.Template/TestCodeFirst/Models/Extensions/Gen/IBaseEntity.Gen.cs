using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Global;

namespace TestCodeFirst.Models
{
	public partial interface IBaseEntity
	{
		E To<E>();
		void CopyTo(object dest);
	}
	
}
