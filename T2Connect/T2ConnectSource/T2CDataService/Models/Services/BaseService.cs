using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TNT.IoContainer.Container;

namespace T2CDataService.Models.Services
{
	public partial interface IService: IResource
	{
	}
	public partial interface IBaseService<E, VM, K> : IService
	{
		bool AutoSave { get; set; }
		
		E Add(E entity);
		Task<E> AddAsync(E entity);
		E Update(E entity);
		Task<E> UpdateAsync(E entity);
		E Delete(E entity);
		Task<E> DeleteAsync(E entity);
		E Delete(K key);
		Task<E> DeleteAsync(K key);
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		E Activate(E entity);
		E Activate(K key);
		E Deactivate(E entity);
		E Deactivate(K key);
		IQueryable<E> GetActive();
		IQueryable<E> GetActive(Expression<Func<E, bool>> expr);
		E FirstOrDefault();
		E FirstOrDefault(Expression<Func<E, bool>> expr);
		Task<E> FirstOrDefaultAsync();
		Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
	}
	
	public abstract partial class BaseService : IService
	{
		public ResourceWrapper Wrapper { get; set; }
		public abstract bool AutoSave { get; set; }
		
		#region IDisposable Support
		protected bool disposedValue = false;
		
		
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
				}
				
				if (Wrapper != null)
					Wrapper.IsFree = true;
				
				disposedValue = true;
			}
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		public virtual void ReInit(params object[] initParams)
		{
			disposedValue = false;
		}
		
		#endregion
		
	}
}
