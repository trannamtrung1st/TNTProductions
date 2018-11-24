using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TestDataService.ViewModels;

namespace TestDataService.Utilities
{
	public static partial class GeneralUtils
	{
		public static List<VM> ToListVM<E, VM>(this IEnumerable<E> list) where E: IBaseEntity
		{
			return list.Select(e => e.To<VM>()).ToList();
		}
		
		public static List<E> ToListEntities<VM, E>(this IEnumerable<VM> list) where VM: IViewModel
		{
			return list.Select(vm => vm.To<E>()).ToList();
		}
		
	}
}
