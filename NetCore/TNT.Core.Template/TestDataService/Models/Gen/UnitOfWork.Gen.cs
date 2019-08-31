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
using TestDataService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TestDataService.Models
{
	public partial interface IUnitOfWork : IDisposable
	{
		T GetService<T>();
		int SaveChanges();
		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
		IDbContextTransaction BeginTransaction();
		
	}
	public partial class UnitOfWork : TScrumContext, IUnitOfWork
	{
		public UnitOfWork(IServiceProvider scope) : base()
		{
			this.scope = scope;
		}
		
		public UnitOfWork(IServiceProvider scope, DbContextOptions<TScrumContext> options) : base(options)
		{
			this.scope = scope;
		}
		
		protected readonly IServiceProvider scope;
		
		public T GetService<T>()
		{
			return scope.GetService<T>();
		}
		
		public IDbContextTransaction BeginTransaction()
		{
			var trans = this.Database.BeginTransaction();
			return trans;
		}
		
	}
}
