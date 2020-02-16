using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDataService.Models;
using TestDataService.Models.Repositories;
using TestDataService.ViewModels;
using TNT.Core.Helpers.DI;

namespace TestDataService.Domains
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
