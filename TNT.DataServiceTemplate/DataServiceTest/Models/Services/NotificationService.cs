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
	public partial interface INotificationService : IBaseService<Notification, NotificationViewModel, int>
	{
	}
	
	public partial class NotificationService : BaseService, INotificationService
	{
		private INotificationRepository repository;
		
		public NotificationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<INotificationRepository>(uow);
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
		public Notification Add(Notification entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Notification> AddAsync(Notification entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Notification Update(Notification entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Notification> UpdateAsync(Notification entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Notification Delete(Notification entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Notification> DeleteAsync(Notification entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Notification Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Notification> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Notification FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Notification> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Notification Activate(Notification entity)
		{
			return repository.Activate(entity);
		}
		
		public Notification Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Notification Deactivate(Notification entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Notification Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Notification> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Notification> GetActive(Expression<Func<Notification, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Notification FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Notification FirstOrDefault(Expression<Func<Notification, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Notification> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Notification> FirstOrDefaultAsync(Expression<Func<Notification, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public NotificationService()
		{
			repository = G.TContainer.Resolve<INotificationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~NotificationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
