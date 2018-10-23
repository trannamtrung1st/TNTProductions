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
	public partial interface IRoomCategoryPriceGroupMappingService : IBaseService<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingViewModel, RoomCategoryPriceGroupMappingPK>
	{
	}
	
	public partial class RoomCategoryPriceGroupMappingService : BaseService, IRoomCategoryPriceGroupMappingService
	{
		private IRoomCategoryPriceGroupMappingRepository repository;
		
		public RoomCategoryPriceGroupMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryPriceGroupMappingRepository>(uow);
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
		public RoomCategoryPriceGroupMapping Add(RoomCategoryPriceGroupMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> AddAsync(RoomCategoryPriceGroupMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RoomCategoryPriceGroupMapping Update(RoomCategoryPriceGroupMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> UpdateAsync(RoomCategoryPriceGroupMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RoomCategoryPriceGroupMapping Delete(RoomCategoryPriceGroupMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> DeleteAsync(RoomCategoryPriceGroupMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RoomCategoryPriceGroupMapping Delete(RoomCategoryPriceGroupMappingPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> DeleteAsync(RoomCategoryPriceGroupMappingPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RoomCategoryPriceGroupMapping FindById(RoomCategoryPriceGroupMappingPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> FindByIdAsync(RoomCategoryPriceGroupMappingPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMappingPK key)
		{
			return repository.Activate(key);
		}
		
		public RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMappingPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RoomCategoryPriceGroupMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RoomCategoryPriceGroupMapping> GetActive(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RoomCategoryPriceGroupMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RoomCategoryPriceGroupMapping FirstOrDefault(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RoomCategoryPriceGroupMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RoomCategoryPriceGroupMapping> FirstOrDefaultAsync(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RoomCategoryPriceGroupMappingService()
		{
			repository = G.TContainer.Resolve<IRoomCategoryPriceGroupMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomCategoryPriceGroupMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
