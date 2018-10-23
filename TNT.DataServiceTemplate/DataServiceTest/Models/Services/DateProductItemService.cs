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
	public partial interface IDateProductItemService : IBaseService<DateProductItem, DateProductItemViewModel, int>
	{
	}
	
	public partial class DateProductItemService : BaseService, IDateProductItemService
	{
		private IDateProductItemRepository repository;
		
		public DateProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateProductItemRepository>(uow);
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
		public DateProductItem Add(DateProductItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DateProductItem> AddAsync(DateProductItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DateProductItem Update(DateProductItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DateProductItem> UpdateAsync(DateProductItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DateProductItem Delete(DateProductItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DateProductItem> DeleteAsync(DateProductItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DateProductItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DateProductItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DateProductItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DateProductItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DateProductItem Activate(DateProductItem entity)
		{
			return repository.Activate(entity);
		}
		
		public DateProductItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DateProductItem Deactivate(DateProductItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DateProductItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DateProductItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DateProductItem> GetActive(Expression<Func<DateProductItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DateProductItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DateProductItem FirstOrDefault(Expression<Func<DateProductItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DateProductItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DateProductItem> FirstOrDefaultAsync(Expression<Func<DateProductItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DateProductItemService()
		{
			repository = G.TContainer.Resolve<IDateProductItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateProductItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
