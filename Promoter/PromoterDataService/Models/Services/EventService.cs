using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IEventService : IBaseService<Event, EventViewModel, int>
	{
	}
	
	public partial class EventService : BaseService, IEventService
	{
		private IEventRepository repository;
		
		public EventService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEventRepository>(uow);
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
		public Event Add(Event entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Event> AddAsync(Event entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Event Update(Event entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Event> UpdateAsync(Event entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Event Delete(Event entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Event> DeleteAsync(Event entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Event Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Event> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Event FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Event> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Event Activate(Event entity)
		{
			return repository.Activate(entity);
		}
		
		public Event Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Event Deactivate(Event entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Event Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Event> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Event> GetActive(Expression<Func<Event, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Event FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Event FirstOrDefault(Expression<Func<Event, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Event> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Event> FirstOrDefaultAsync(Expression<Func<Event, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
