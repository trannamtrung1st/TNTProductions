using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;
using TNT.IoContainer.Container;
using System.Web;
using System.Data.Entity;
using DataServiceTest.Global;
using DataServiceTest.Models.Services;
using DataServiceTest.Models;

namespace DataServiceTest.Managers
{
	public partial interface IUnitOfWork : IDisposable
	{
		bool AutoSave { get; set; }
		ITContainer Scope { get; set; }
		passioTestEntities Context { get; set; }
		S Service<S>() where S : class, IService;
		int SaveChanges();
		Task<int> SaveChangesAsync();
		DbContextTransaction BeginTransaction();
		
	}
	public partial class UnitOfWork : IUnitOfWork
	{
		public bool AutoSave { get; set; }
		public ITContainer Scope { get; set; }
		public passioTestEntities Context { get; set; }
		private IDictionary<Type, object> ResourcePool { get; set; }
		
		public UnitOfWork()
		{
			AutoSave = true;
			Scope = G.TContainer.RequestScope;
			Context = new passioTestEntities();
			ResourcePool = new Dictionary<Type, object>();
		}
		
		public UnitOfWork(ITContainer scope)
		{
			AutoSave = true;
			Scope = scope;
			Scope.ManageResources(this);
			Context = new passioTestEntities();
			ResourcePool = new Dictionary<Type, object>();
		}
		
		public UnitOfWork(bool reqScope)
		{
			AutoSave = true;
			Scope = reqScope ? G.TContainer.CreateRequestScope() : G.TContainer.CreateScope();
			Scope.ManageResources(this);
			Context = new passioTestEntities();
			ResourcePool = new Dictionary<Type, object>();
		}
		
		public S Service<S>() where S : class, IService
		{
			var type = typeof(S);
			if (ResourcePool.ContainsKey(type))
				return (S)ResourcePool[type];
			var service = Scope.ResolveFromPool<S>(this);
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
				if (AutoSave)
				try
				{
					Context.SaveChanges();
				}
				catch (Exception) { }
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
