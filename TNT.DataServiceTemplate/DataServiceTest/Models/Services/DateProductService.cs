using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IDateProductService : IBaseService<DateProduct, DateProductViewModel, int>
	{
	}
	
	public partial class DateProductService : BaseService, IDateProductService
	{
		private IDateProductRepository repository;
		
		public DateProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateProductRepository>(uow);
		}
		
		public override bool AutoSave
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
		public DateProduct Add(DateProduct entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DateProduct> AddAsync(DateProduct entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DateProduct Update(DateProduct entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DateProduct> UpdateAsync(DateProduct entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DateProduct Delete(DateProduct entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DateProduct> DeleteAsync(DateProduct entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DateProduct Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DateProduct> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DateProduct FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DateProduct> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DateProduct Activate(DateProduct entity)
		{
			return repository.Activate(entity);
		}
		
		public DateProduct Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DateProduct Deactivate(DateProduct entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DateProduct Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DateProduct> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DateProduct> GetActive(Expression<Func<DateProduct, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DateProduct FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DateProduct FirstOrDefault(Expression<Func<DateProduct, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DateProduct> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DateProduct> FirstOrDefaultAsync(Expression<Func<DateProduct, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DateProductService()
		{
			repository = G.TContainer.Resolve<IDateProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
