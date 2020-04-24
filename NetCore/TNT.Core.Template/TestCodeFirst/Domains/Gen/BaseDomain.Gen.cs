using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCodeFirst.Models;
using TestCodeFirst.Models.Repositories;
using TestCodeFirst.ViewModels;
using TNT.Core.Helpers.DI;

namespace TestCodeFirst.Domains
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
