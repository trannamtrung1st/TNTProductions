using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;
using TNT.IoContainer.Container;

namespace PromoterDataService.Models.Services
{
	public partial interface IService
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
	
	public abstract partial class BaseService<E, VM, K> : IBaseService<E, VM, K>
	{
		protected IBaseRepository<E, K> repository;
		
		public bool AutoSave
		{
			get
			{
				return repository.AutoSave;
			}
			set
			{
				repository.AutoSave = value;
			}
		}
		
		#region CRUD Area
		public E Add(E entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<E> AddAsync(E entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public E Update(E entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<E> UpdateAsync(E entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public E Delete(E entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<E> DeleteAsync(E entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public E Delete(K key)
		{
			return repository.Delete(key);
		}
		
		public async Task<E> DeleteAsync(K key)
		{
			return await repository.DeleteAsync(key);
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
