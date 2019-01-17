using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Repositories;
using TestDataService.ViewModels;
using TestDataService.Models;
using TestDataService.Global;
using System.Data.Entity;
using System.Linq.Expressions;
using TNT.IoC.Container;

namespace TestDataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		public BaseDomain()
		{
			this.uow = TContainer.RequestScope.ResolveScopeInstance<IUnitOfWork>();
			this.context = uow.Context;
		}
		
		public BaseDomain(IUnitOfWork uow)
		{
			this.uow = uow;
			this.context = uow.Context;
		}
		
		protected IUnitOfWork uow;
		
		public BaseDomain(DbContext context)
		{
			this.context = context;
		}
		
		protected DbContext context;
		
	}
}