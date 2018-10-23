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
	public partial interface IRoomFloorService : IBaseService<RoomFloor, RoomFloorViewModel, int>
	{
	}
	
	public partial class RoomFloorService : BaseService, IRoomFloorService
	{
		private IRoomFloorRepository repository;
		
		public RoomFloorService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomFloorRepository>(uow);
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
		public RoomFloor Add(RoomFloor entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RoomFloor> AddAsync(RoomFloor entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RoomFloor Update(RoomFloor entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RoomFloor> UpdateAsync(RoomFloor entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RoomFloor Delete(RoomFloor entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RoomFloor> DeleteAsync(RoomFloor entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RoomFloor Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RoomFloor> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RoomFloor FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RoomFloor> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RoomFloor Activate(RoomFloor entity)
		{
			return repository.Activate(entity);
		}
		
		public RoomFloor Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public RoomFloor Deactivate(RoomFloor entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RoomFloor Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RoomFloor> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RoomFloor> GetActive(Expression<Func<RoomFloor, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RoomFloor FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RoomFloor FirstOrDefault(Expression<Func<RoomFloor, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RoomFloor> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RoomFloor> FirstOrDefaultAsync(Expression<Func<RoomFloor, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RoomFloorService()
		{
			repository = G.TContainer.Resolve<IRoomFloorRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomFloorService()
		{
			Dispose(false);
		}
		#endregion
	}
}
