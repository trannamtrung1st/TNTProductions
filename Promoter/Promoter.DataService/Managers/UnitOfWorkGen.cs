using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;
using TNT.IoContainer.Container;
using System.Web;
using System.Data.Entity;
using Promoter.DataService.Global;
using Promoter.DataService.Models.Services;
using Promoter.DataService.Models;

namespace Promoter.DataService.Managers
{
	public partial interface IUnitOfWork : IDisposable
	{
		ITContainer Scope { get; set; }
		PromoterEntities Context { get; set; }
		S Service<S>() where S : class, IService;
		int SaveChanges();
		Task<int> SaveChangesAsync();
		DbContextTransaction BeginTransaction();
		
	}
	public partial class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork()
		{
			Scope = G.TContainer.RequestScope;
			Context = new PromoterEntities();
			ResourcePool = new Dictionary<Type, object>();
		}
		
		public UnitOfWork(ITContainer scope)
		{
			Scope = scope;
			Context = new PromoterEntities();
			ResourcePool = new Dictionary<Type, object>();
		}
		
		public ITContainer Scope { get; set; }
		public PromoterEntities Context { get; set; }
		private IDictionary<Type, object> ResourcePool { get; set; }
		
		public S Service<S>() where S : class, IService
		{
			var type = typeof(S);
			if (ResourcePool.ContainsKey(type))
				return (S)ResourcePool[type];
			var service = Scope.Resolve<S>(this);
			ResourcePool.Add(type, service);
			return service;
		}
		
		public int SaveChanges()
		{
			return Context.SaveChanges();
		}
		
		public async Task<int> SaveChangesAsync()
		{
			return await Context.SaveChangesAsync();
		}
		
		public DbContextTransaction BeginTransaction()
		{
			var trans = Context.Database.BeginTransaction();
			Scope.ManageResources(trans);
			return trans;
		}
		
		#region IDisposable Support
		protected bool disposedValue = false;
		
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
				}
				
				disposedValue = true;
				Context.Dispose();
			}
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		#endregion
		
		~UnitOfWork()
		{
			Dispose(false);
		}
		
	}
}
