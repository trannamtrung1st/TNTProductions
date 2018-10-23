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
	public partial interface IGuestService : IBaseService<Guest, GuestViewModel, int>
	{
	}
	
	public partial class GuestService : BaseService, IGuestService
	{
		private IGuestRepository repository;
		
		public GuestService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGuestRepository>(uow);
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
		public Guest Add(Guest entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Guest> AddAsync(Guest entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Guest Update(Guest entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Guest> UpdateAsync(Guest entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Guest Delete(Guest entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Guest> DeleteAsync(Guest entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Guest Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Guest> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Guest FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Guest> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Guest Activate(Guest entity)
		{
			return repository.Activate(entity);
		}
		
		public Guest Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Guest Deactivate(Guest entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Guest Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Guest> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Guest> GetActive(Expression<Func<Guest, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Guest FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Guest FirstOrDefault(Expression<Func<Guest, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Guest> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Guest> FirstOrDefaultAsync(Expression<Func<Guest, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public GuestService()
		{
			repository = G.TContainer.Resolve<IGuestRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~GuestService()
		{
			Dispose(false);
		}
		#endregion
	}
}
