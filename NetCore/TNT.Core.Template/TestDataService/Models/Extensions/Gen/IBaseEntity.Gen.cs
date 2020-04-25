using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial interface IBaseEntity
	{
		E To<E>();
		void CopyTo(object dest);
	}
	
}
