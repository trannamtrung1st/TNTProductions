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
	public partial interface ICostInventoryMappingService : IBaseService<CostInventoryMapping, CostInventoryMappingViewModel, CostInventoryMappingPK>
	{
	}
	
	public partial class CostInventoryMappingService : BaseService, ICostInventoryMappingService
	{
		private ICostInventoryMappingRepository repository;
		
		public CostInventoryMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostInventoryMappingRepository>(uow);
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
		public CostInventoryMapping Add(CostInventoryMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CostInventoryMapping> AddAsync(CostInventoryMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CostInventoryMapping Update(CostInventoryMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CostInventoryMapping> UpdateAsync(CostInventoryMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CostInventoryMapping Delete(CostInventoryMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CostInventoryMapping> DeleteAsync(CostInventoryMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CostInventoryMapping Delete(CostInventoryMappingPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CostInventoryMapping> DeleteAsync(CostInventoryMappingPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CostInventoryMapping FindById(CostInventoryMappingPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CostInventoryMapping> FindByIdAsync(CostInventoryMappingPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CostInventoryMapping Activate(CostInventoryMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public CostInventoryMapping Activate(CostInventoryMappingPK key)
		{
			return repository.Activate(key);
		}
		
		public CostInventoryMapping Deactivate(CostInventoryMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CostInventoryMapping Deactivate(CostInventoryMappingPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CostInventoryMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CostInventoryMapping> GetActive(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CostInventoryMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CostInventoryMapping FirstOrDefault(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CostInventoryMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CostInventoryMapping> FirstOrDefaultAsync(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CostInventoryMappingService()
		{
			repository = G.TContainer.Resolve<ICostInventoryMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostInventoryMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
