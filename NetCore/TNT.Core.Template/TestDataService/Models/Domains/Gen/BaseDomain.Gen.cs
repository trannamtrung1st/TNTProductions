using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Repositories;
using TestDataService.ViewModels;
using TestDataService.Models;
using TestDataService.Global;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TestDataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		protected readonly IUnitOfWork uow;
		
		public BaseDomain(IUnitOfWork uow)
		{
			this.uow = uow;
		}
		
	}
}
