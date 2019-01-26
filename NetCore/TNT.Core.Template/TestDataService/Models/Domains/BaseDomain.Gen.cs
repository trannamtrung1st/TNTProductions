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
		public BaseDomain(DbContext context)
		{
			this.context = context;
		}
		
		public BaseDomain(IUnitOfWork uow)
		{
			this.uow = uow;
			this.context = uow.Context;
		}
		
		protected IUnitOfWork uow;
		
		protected DbContext context;
		
		public IUnitOfWork UoW { get { return uow; } }
		
		public DbContext Context { get { return context; } }
		
	}
}
