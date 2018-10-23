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
	public partial interface ICostService : IBaseService<Cost, CostViewModel, int>
	{
	}
	
	public partial class CostService : BaseService, ICostService
	{
		private ICostRepository repository;
		
		public CostService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostRepository>(uow);
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
		public Cost Add(Cost entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Cost> AddAsync(Cost entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Cost Update(Cost entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Cost> UpdateAsync(Cost entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Cost Delete(Cost entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Cost> DeleteAsync(Cost entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Cost Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Cost> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Cost FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Cost> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Cost Activate(Cost entity)
		{
			return repository.Activate(entity);
		}
		
		public Cost Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Cost Deactivate(Cost entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Cost Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Cost> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Cost> GetActive(Expression<Func<Cost, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Cost FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Cost FirstOrDefault(Expression<Func<Cost, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Cost> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Cost> FirstOrDefaultAsync(Expression<Func<Cost, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CostService()
		{
			repository = G.TContainer.Resolve<ICostRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostService()
		{
			Dispose(false);
		}
		#endregion
	}
}
