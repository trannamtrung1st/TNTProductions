using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using TestDataService.Global;
using TestDataService.Models.Repositories;
using TestDataService.Models.Domains;
using TestDataService.Models.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace TestDataService.Models
{
	public partial interface IUnitOfWork : IDisposable
	{
		IServiceProvider Scope { get; }
		DbContext Context { get; }
		DbSet<E> Set<E>() where E : class;
		S Repository<S>() where S : class, IRepository;
		D Domain<D>() where D : BaseDomain;
		int SaveChanges();
		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
		IDbContextTransaction BeginTransaction();
		
	}
	public partial class UnitOfWork : DataContext, IUnitOfWork
	{
		public UnitOfWork(IServiceProvider scope) : base()
		{
			Scope = scope;
			Context = this;
		}
		
		public UnitOfWork(IServiceProvider scope, DbContextOptions<DataContext> options) : base(options)
		{
			Scope = scope;
			Context = this;
		}
		
		public IServiceProvider Scope { get; }
		public DbContext Context { get; }
		
		public S Repository<S>() where S : class, IRepository
		{
			var repository = Scope.GetService<S>();
			return repository;
		}
		
		public D Domain<D>() where D : BaseDomain
		{
			var domain = Scope.GetService<D>();
			return domain;
		}
		
		public IDbContextTransaction BeginTransaction()
		{
			var trans = this.Database.BeginTransaction();
			return trans;
		}
		
	}
}
