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
	public partial interface IRoomCategoryService : IBaseService<RoomCategory, RoomCategoryViewModel, int>
	{
	}
	
	public partial class RoomCategoryService : BaseService, IRoomCategoryService
	{
		private IRoomCategoryRepository repository;
		
		public RoomCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryRepository>(uow);
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
		public RoomCategory Add(RoomCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RoomCategory> AddAsync(RoomCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RoomCategory Update(RoomCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RoomCategory> UpdateAsync(RoomCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RoomCategory Delete(RoomCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RoomCategory> DeleteAsync(RoomCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RoomCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RoomCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RoomCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RoomCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RoomCategory Activate(RoomCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public RoomCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public RoomCategory Deactivate(RoomCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RoomCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RoomCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RoomCategory> GetActive(Expression<Func<RoomCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RoomCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RoomCategory FirstOrDefault(Expression<Func<RoomCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RoomCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RoomCategory> FirstOrDefaultAsync(Expression<Func<RoomCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RoomCategoryService()
		{
			repository = G.TContainer.Resolve<IRoomCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
