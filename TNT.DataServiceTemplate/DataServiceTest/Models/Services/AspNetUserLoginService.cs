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
	public partial interface IAspNetUserLoginService : IBaseService<AspNetUserLogin, AspNetUserLoginViewModel, AspNetUserLoginPK>
	{
	}
	
	public partial class AspNetUserLoginService : BaseService, IAspNetUserLoginService
	{
		private IAspNetUserLoginRepository repository;
		
		public AspNetUserLoginService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserLoginRepository>(uow);
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
		public AspNetUserLogin Add(AspNetUserLogin entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AspNetUserLogin> AddAsync(AspNetUserLogin entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AspNetUserLogin Update(AspNetUserLogin entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AspNetUserLogin> UpdateAsync(AspNetUserLogin entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AspNetUserLogin Delete(AspNetUserLogin entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AspNetUserLogin> DeleteAsync(AspNetUserLogin entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AspNetUserLogin Delete(AspNetUserLoginPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AspNetUserLogin> DeleteAsync(AspNetUserLoginPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AspNetUserLogin FindById(AspNetUserLoginPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AspNetUserLogin> FindByIdAsync(AspNetUserLoginPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AspNetUserLogin Activate(AspNetUserLogin entity)
		{
			return repository.Activate(entity);
		}
		
		public AspNetUserLogin Activate(AspNetUserLoginPK key)
		{
			return repository.Activate(key);
		}
		
		public AspNetUserLogin Deactivate(AspNetUserLogin entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AspNetUserLogin Deactivate(AspNetUserLoginPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AspNetUserLogin> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AspNetUserLogin> GetActive(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AspNetUserLogin FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AspNetUserLogin FirstOrDefault(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AspNetUserLogin> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AspNetUserLogin> FirstOrDefaultAsync(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AspNetUserLoginService()
		{
			repository = G.TContainer.Resolve<IAspNetUserLoginRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserLoginService()
		{
			Dispose(false);
		}
		#endregion
	}
}
