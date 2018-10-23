using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Models.Services;
using T2CDataService.ViewModels;
using T2CDataService.Managers;
using T2CDataService.Utilities;
using T2CDataService.Models;
using T2CDataService.Global;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace T2CDataService.APIs
{
	public partial interface IBaseApi<E, VM, K>
	{
		VM Add(E entity);
		Task<VM> AddAsync(E entity);
		VM Update(E entity);
		Task<VM> UpdateAsync(E entity);
		VM Delete(E entity);
		Task<VM> DeleteAsync(E entity);
		VM Delete(K key);
		Task<VM> DeleteAsync(K key);
		VM FindById(K key);
		Task<VM> FindByIdAsync(K key);
		VM Activate(E entity);
		VM Activate(K key);
		VM Deactivate(E entity);
		VM Deactivate(K key);
		IEnumerable<VM> GetActive();
		Task<IEnumerable<VM>> GetActiveAsync();
		IEnumerable<VM> GetActive(Expression<Func<E, bool>> expr);
		Task<IEnumerable<VM>> GetActiveAsync(Expression<Func<E, bool>> expr);
		VM FirstOrDefault(Expression<Func<E, bool>> expr);
		Task<VM> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
	}
	
	public abstract partial class BaseApi<E, VM, K, S> : IBaseApi<E, VM, K> where S: class, IBaseService<E, VM, K> where E: IBaseEntity<VM> where VM: class
	{
		public VM Add(E entity)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().Add(entity).ToViewModel();
			};
		}
		
		public async Task<VM> AddAsync(E entity)
		{
			using (var s = new ServiceManager())
			{
				return (await s.Service<S>().AddAsync(entity)).ToViewModel();
			};
		}
		
		public VM Update(E entity)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().Update(entity).ToViewModel();
			};
		}
		
		public async Task<VM> UpdateAsync(E entity)
		{
			using (var s = new ServiceManager())
			{
				return (await s.Service<S>().UpdateAsync(entity)).ToViewModel();
			};
		}
		
		public VM Delete(E entity)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().Delete(entity).ToViewModel();
			};
		}
		
		public async Task<VM> DeleteAsync(E entity)
		{
			using (var s = new ServiceManager())
			{
				return (await s.Service<S>().DeleteAsync(entity)).ToViewModel();
			};
		}
		
		public VM Delete(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = s.Service<S>().Delete(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public async Task<VM> DeleteAsync(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = await s.Service<S>().DeleteAsync(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public VM FindById(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = s.Service<S>().FindById(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public async Task<VM> FindByIdAsync(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = await s.Service<S>().FindByIdAsync(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public VM Activate(E entity)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().Activate(entity).ToViewModel();
			};
		}
		
		public VM Activate(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = s.Service<S>().Activate(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public VM Deactivate(E entity)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().Deactivate(entity).ToViewModel();
			};
		}
		
		public VM Deactivate(K key)
		{
			using (var s = new ServiceManager())
			{
				var entity = s.Service<S>().Deactivate(key);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public IEnumerable<VM> GetActive()
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().GetActive().AsEnumerable().Select(e => e.ToViewModel()).ToList();
			};
		}
		
		public IEnumerable<VM> GetActive(Expression<Func<E, bool>> expr)
		{
			using (var s = new ServiceManager())
			{
				return s.Service<S>().GetActive(expr).AsEnumerable().Select(e => e.ToViewModel()).ToList();
			};
		}
		
		public async Task<IEnumerable<VM>> GetActiveAsync()
		{
			return await Task.Run(() =>
			{
				return GetActive();
			});
		}
		
		public async Task<IEnumerable<VM>> GetActiveAsync(Expression<Func<E, bool>> expr)
		{
			return await Task.Run(() =>
			{
				return GetActive(expr);
			});
		}
		
		public VM FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			using (var s = new ServiceManager())
			{
				var entity = s.Service<S>().FirstOrDefault(expr);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
		public async Task<VM> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			using (var s = new ServiceManager())
			{
				var entity = await s.Service<S>().FirstOrDefaultAsync(expr);
				if (entity != null)
					return entity.ToViewModel();
				return null;
			};
		}
		
	}
}
