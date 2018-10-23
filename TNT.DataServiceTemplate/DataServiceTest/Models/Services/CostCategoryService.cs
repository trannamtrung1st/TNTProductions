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
	public partial interface ICostCategoryService : IBaseService<CostCategory, CostCategoryViewModel, int>
	{
	}
	
	public partial class CostCategoryService : BaseService, ICostCategoryService
	{
		private ICostCategoryRepository repository;
		
		public CostCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostCategoryRepository>(uow);
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
		public CostCategory Add(CostCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CostCategory> AddAsync(CostCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CostCategory Update(CostCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CostCategory> UpdateAsync(CostCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CostCategory Delete(CostCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CostCategory> DeleteAsync(CostCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CostCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CostCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CostCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CostCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CostCategory Activate(CostCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public CostCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CostCategory Deactivate(CostCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CostCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CostCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CostCategory> GetActive(Expression<Func<CostCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CostCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CostCategory FirstOrDefault(Expression<Func<CostCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CostCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CostCategory> FirstOrDefaultAsync(Expression<Func<CostCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CostCategoryService()
		{
			repository = G.TContainer.Resolve<ICostCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
