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
	public partial interface IEventLocationService : IBaseService<EventLocation, EventLocationViewModel, int>
	{
	}
	
	public partial class EventLocationService : BaseService, IEventLocationService
	{
		private IEventLocationRepository repository;
		
		public EventLocationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEventLocationRepository>(uow);
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
		public EventLocation Add(EventLocation entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<EventLocation> AddAsync(EventLocation entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public EventLocation Update(EventLocation entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<EventLocation> UpdateAsync(EventLocation entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public EventLocation Delete(EventLocation entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<EventLocation> DeleteAsync(EventLocation entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public EventLocation Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<EventLocation> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public EventLocation FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<EventLocation> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public EventLocation Activate(EventLocation entity)
		{
			return repository.Activate(entity);
		}
		
		public EventLocation Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public EventLocation Deactivate(EventLocation entity)
		{
			return repository.Deactivate(entity);
		}
		
		public EventLocation Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<EventLocation> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<EventLocation> GetActive(Expression<Func<EventLocation, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public EventLocation FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public EventLocation FirstOrDefault(Expression<Func<EventLocation, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<EventLocation> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<EventLocation> FirstOrDefaultAsync(Expression<Func<EventLocation, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public EventLocationService()
		{
			repository = G.TContainer.Resolve<IEventLocationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EventLocationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
