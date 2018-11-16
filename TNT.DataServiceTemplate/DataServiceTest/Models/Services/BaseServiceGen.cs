using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using TNT.IoContainer.Container;

namespace DataServiceTest.Models.Services
{
	public partial interface IService
	{
	}
	public partial interface IBaseService<E, K> : IService
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		
		E Add(E entity);
		E Update(E entity);
		E Remove(E entity);
		E Remove(K key);
		IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		IEnumerable<E> RemoveRange(IEnumerable<E> list);
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
	
	public abstract partial class BaseService<E, K> : IBaseService<E, K>
	{
		protected IBaseRepository<E, K> repository;
		
		public int SaveChanges()
		{
			return repository.SaveChanges();
		}
		
		public async Task<int> SaveChangesAsync()
		{
			return await repository.SaveChangesAsync();
		}
		
		#region CRUD Area
		public E Add(E entity)
		{
			return repository.Add(entity);
		}
		
		public E Update(E entity)
		{
			return repository.Update(entity);
		}
		
		public E Remove(E entity)
		{
			return repository.Remove(entity);
		}
		
		public E Remove(K key)
		{
			return repository.Remove(key);
		}
		
		public IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr)
		{
			return repository.RemoveIf(expr);
		}
		
		public IEnumerable<E> RemoveRange(IEnumerable<E> list)
		{
			return repository.RemoveRange(list);
		}
		
		public E FindById(K key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<E> FindByIdAsync(K key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public E Activate(E entity)
		{
			return repository.Activate(entity);
		}
		
		public E Activate(K key)
		{
			return repository.Activate(key);
		}
		
		public E Deactivate(E entity)
		{
			return repository.Deactivate(entity);
		}
		
		public E Deactivate(K key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<E> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<E> GetActive(Expression<Func<E, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public E FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public E FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<E> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
