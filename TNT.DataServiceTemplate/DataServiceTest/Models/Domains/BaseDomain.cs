using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models.Services;
using DataServiceTest.ViewModels;
using DataServiceTest.Managers;
using DataServiceTest.Utilities;
using DataServiceTest.Models;
using DataServiceTest.Global;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Domains
{
	public partial interface IBaseDomain<E, VM, K>
	{
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
		IEnumerable<E> GetActive();
		Task<IEnumerable<E>> GetActiveAsync();
		IEnumerable<E> GetActive(Expression<Func<E, bool>> expr);
		Task<IEnumerable<E>> GetActiveAsync(Expression<Func<E, bool>> expr);
		E FirstOrDefault(Expression<Func<E, bool>> expr);
		Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
	}
	
	public abstract partial class BaseDomain<E, VM, K, S> : IBaseDomain<E, VM, K> where S: class, IBaseService<E, VM, K> where E: class, IBaseEntity<VM> where VM: class
	{
		public BaseDomain()
		{
			_uow = G.TContainer.ResolveRequestScope<IUnitOfWork>();
			baseService = _uow.Service<S>();
		}
		
		public BaseDomain(IUnitOfWork uow)
		{
			_uow = uow;
			baseService = _uow.Service<S>();
		}
		
		private IUnitOfWork _uow;
		protected IUnitOfWork UoW
		{
			get
			{
				return _uow;
			}
		}
		
		private S baseService;
		protected S BaseService
		{
			get
			{
				return baseService;
			}
		}
		
		public E Add(E entity)
		{
			return baseService.Add(entity);
		}
		
		public async Task<E> AddAsync(E entity)
		{
			return (await baseService.AddAsync(entity));
		}
		
		public E Update(E entity)
		{
			return baseService.Update(entity);
		}
		
		public async Task<E> UpdateAsync(E entity)
		{
			return (await baseService.UpdateAsync(entity));
		}
		
		public E Delete(E entity)
		{
			return baseService.Delete(entity);
		}
		
		public async Task<E> DeleteAsync(E entity)
		{
			return (await baseService.DeleteAsync(entity));
		}
		
		public E Delete(K key)
		{
			var entity = baseService.Delete(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public async Task<E> DeleteAsync(K key)
		{
			var entity = await baseService.DeleteAsync(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public E FindById(K key)
		{
			var entity = baseService.FindById(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public async Task<E> FindByIdAsync(K key)
		{
			var entity = await baseService.FindByIdAsync(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public E Activate(E entity)
		{
			return baseService.Activate(entity);
		}
		
		public E Activate(K key)
		{
			var entity = baseService.Activate(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public E Deactivate(E entity)
		{
			return baseService.Deactivate(entity);
		}
		
		public E Deactivate(K key)
		{
			var entity = baseService.Deactivate(key);
			if (entity != null)
				return entity;
			return null;
		}
		
		public IEnumerable<E> GetActive()
		{
			return baseService.GetActive().AsEnumerable();
		}
		
		public IEnumerable<E> GetActive(Expression<Func<E, bool>> expr)
		{
			return baseService.GetActive(expr).AsEnumerable();
		}
		
		public async Task<IEnumerable<E>> GetActiveAsync()
		{
			return await Task.Run(() =>
			{
				return GetActive();
			});
		}
		
		public async Task<IEnumerable<E>> GetActiveAsync(Expression<Func<E, bool>> expr)
		{
			return await Task.Run(() =>
			{
				return GetActive(expr);
			});
		}
		
		public E FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			var entity = baseService.FirstOrDefault(expr);
			if (entity != null)
				return entity;
			return null;
		}
		
		public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			var entity = await baseService.FirstOrDefaultAsync(expr);
			if (entity != null)
				return entity;
			return null;
		}
		
	}
}
