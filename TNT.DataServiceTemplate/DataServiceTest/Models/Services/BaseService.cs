using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TNT.IoContainer.Container;

namespace DataServiceTest.Models.Services
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
	
	public abstract partial class BaseService : Resource, IService
	{
		public abstract bool AutoSave { get; set; }
		
	}
}
