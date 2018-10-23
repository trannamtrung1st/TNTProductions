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
	public partial interface IProfileService : IBaseService<Profile, ProfileViewModel, System.Guid>
	{
	}
	
	public partial class ProfileService : BaseService, IProfileService
	{
		private IProfileRepository repository;
		
		public ProfileService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProfileRepository>(uow);
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
		public Profile Add(Profile entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Profile> AddAsync(Profile entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Profile Update(Profile entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Profile> UpdateAsync(Profile entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Profile Delete(Profile entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Profile> DeleteAsync(Profile entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Profile Delete(System.Guid key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Profile> DeleteAsync(System.Guid key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Profile FindById(System.Guid key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Profile> FindByIdAsync(System.Guid key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Profile Activate(Profile entity)
		{
			return repository.Activate(entity);
		}
		
		public Profile Activate(System.Guid key)
		{
			return repository.Activate(key);
		}
		
		public Profile Deactivate(Profile entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Profile Deactivate(System.Guid key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Profile> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Profile> GetActive(Expression<Func<Profile, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Profile FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Profile FirstOrDefault(Expression<Func<Profile, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Profile> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Profile> FirstOrDefaultAsync(Expression<Func<Profile, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProfileService()
		{
			repository = G.TContainer.Resolve<IProfileRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProfileService()
		{
			Dispose(false);
		}
		#endregion
	}
}
