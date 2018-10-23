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
	public partial interface IAspNetUserService : IBaseService<AspNetUser, AspNetUserViewModel, string>
	{
	}
	
	public partial class AspNetUserService : BaseService, IAspNetUserService
	{
		private IAspNetUserRepository repository;
		
		public AspNetUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserRepository>(uow);
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
		public AspNetUser Add(AspNetUser entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AspNetUser> AddAsync(AspNetUser entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AspNetUser Update(AspNetUser entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AspNetUser> UpdateAsync(AspNetUser entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AspNetUser Delete(AspNetUser entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AspNetUser> DeleteAsync(AspNetUser entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AspNetUser Delete(string key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AspNetUser> DeleteAsync(string key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AspNetUser FindById(string key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AspNetUser> FindByIdAsync(string key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AspNetUser Activate(AspNetUser entity)
		{
			return repository.Activate(entity);
		}
		
		public AspNetUser Activate(string key)
		{
			return repository.Activate(key);
		}
		
		public AspNetUser Deactivate(AspNetUser entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AspNetUser Deactivate(string key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AspNetUser> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AspNetUser> GetActive(Expression<Func<AspNetUser, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AspNetUser FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AspNetUser FirstOrDefault(Expression<Func<AspNetUser, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AspNetUser> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AspNetUser> FirstOrDefaultAsync(Expression<Func<AspNetUser, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AspNetUserService()
		{
			repository = G.TContainer.Resolve<IAspNetUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
