using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Helpers.DI;

namespace TestDataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		[Inject]
		protected readonly IUnitOfWork _uow;
		
		public BaseDomain(ServiceInjection inj)
		{
			inj.Inject(this);
		}
		
	}
}
