using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoC.Wrapper;
using TNT.IoC.Container;
using System.Web;
using System.Data.Entity;
using TestDataService.Global;
using TestDataService.Models.Repositories;
using TestDataService.Models;

namespace TestDataService.Models
{
	public partial interface IUnitOfWork : IDisposable
	{
		ITContainer Scope { get; }
		DbContext Context { get; }
		DbSet<E> Set<E>() where E : class;
		S Repository<S>() where S : class, IRepository;
		int SaveChanges();
		Task<int> SaveChangesAsync();
		DbContextTransaction BeginTransaction();
		
	}
	public partial class UnitOfWork : AppEntity, IUnitOfWork
	{
		public UnitOfWork()
		{
			Scope = TContainer.RequestScope;
			Context = this;
		}
		
		public UnitOfWork(ITContainer scope)
		{
			Scope = scope;
			Context = this;
		}
		
		public ITContainer Scope { get; }
		public DbContext Context { get; }
		
		public S Repository<S>() where S : class, IRepository
		{
			var repository = Scope.Resolve<S>();
			return repository;
		}
		
		public DbContextTransaction BeginTransaction()
		{
			var trans = this.Database.BeginTransaction();
			return trans;
		}
		
	}
}
