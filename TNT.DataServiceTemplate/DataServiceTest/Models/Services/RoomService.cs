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
	public partial interface IRoomService : IBaseService<Room, RoomViewModel, int>
	{
	}
	
	public partial class RoomService : BaseService, IRoomService
	{
		private IRoomRepository repository;
		
		public RoomService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomRepository>(uow);
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
		public Room Add(Room entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Room> AddAsync(Room entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Room Update(Room entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Room> UpdateAsync(Room entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Room Delete(Room entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Room> DeleteAsync(Room entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Room Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Room> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Room FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Room> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Room Activate(Room entity)
		{
			return repository.Activate(entity);
		}
		
		public Room Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Room Deactivate(Room entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Room Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Room> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Room> GetActive(Expression<Func<Room, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Room FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Room FirstOrDefault(Expression<Func<Room, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Room> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Room> FirstOrDefaultAsync(Expression<Func<Room, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RoomService()
		{
			repository = G.TContainer.Resolve<IRoomRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomService()
		{
			Dispose(false);
		}
		#endregion
	}
}
