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
	public partial interface ICheckFingerService : IBaseService<CheckFinger, CheckFingerViewModel, int>
	{
	}
	
	public partial class CheckFingerService : BaseService, ICheckFingerService
	{
		private ICheckFingerRepository repository;
		
		public CheckFingerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICheckFingerRepository>(uow);
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
		public CheckFinger Add(CheckFinger entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CheckFinger> AddAsync(CheckFinger entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CheckFinger Update(CheckFinger entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CheckFinger> UpdateAsync(CheckFinger entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CheckFinger Delete(CheckFinger entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CheckFinger> DeleteAsync(CheckFinger entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CheckFinger Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CheckFinger> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CheckFinger FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CheckFinger> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CheckFinger Activate(CheckFinger entity)
		{
			return repository.Activate(entity);
		}
		
		public CheckFinger Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CheckFinger Deactivate(CheckFinger entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CheckFinger Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CheckFinger> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CheckFinger> GetActive(Expression<Func<CheckFinger, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CheckFinger FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CheckFinger FirstOrDefault(Expression<Func<CheckFinger, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CheckFinger> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CheckFinger> FirstOrDefaultAsync(Expression<Func<CheckFinger, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CheckFingerService()
		{
			repository = G.TContainer.Resolve<ICheckFingerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CheckFingerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
