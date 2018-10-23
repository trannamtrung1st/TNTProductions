using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;
using TNT.IoContainer.Container;
using System.Data.Entity;
using T2CDataService.Global;
using T2CDataService.Models.Services;
using T2CDataService.Models;

namespace T2CDataService.Managers
{
	public partial class ServiceManager : IDisposable
	{
		private ITContainer Scope { get; set; }
		private T2CEntities Context { get; set; }
		
		public ServiceManager()
		{
			Scope = G.TContainer.CreateScope();
			Context = new T2CEntities();
			Scope.ManageResources(Context);
		}
		
		public S Service<S>() where S : class, IService
		{
			return Scope.Resolve<S>(Context);
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
				
				if (Scope != null)
					Scope.Dispose();
				
				disposedValue = true;
			}
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		#endregion
		
		~ServiceManager()
		{
			Dispose(false);
		}
		
	}
}
