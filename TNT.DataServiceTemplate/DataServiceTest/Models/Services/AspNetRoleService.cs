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
	public partial interface IAspNetRoleService : IBaseService<AspNetRole, AspNetRoleViewModel, string>
	{
	}
	
	public partial class AspNetRoleService : BaseService, IAspNetRoleService
	{
		private IAspNetRoleRepository repository;
		
		public AspNetRoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetRoleRepository>(uow);
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
		public AspNetRole Add(AspNetRole entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AspNetRole> AddAsync(AspNetRole entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AspNetRole Update(AspNetRole entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AspNetRole> UpdateAsync(AspNetRole entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AspNetRole Delete(AspNetRole entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AspNetRole> DeleteAsync(AspNetRole entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AspNetRole Delete(string key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AspNetRole> DeleteAsync(string key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AspNetRole FindById(string key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AspNetRole> FindByIdAsync(string key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AspNetRole Activate(AspNetRole entity)
		{
			return repository.Activate(entity);
		}
		
		public AspNetRole Activate(string key)
		{
			return repository.Activate(key);
		}
		
		public AspNetRole Deactivate(AspNetRole entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AspNetRole Deactivate(string key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AspNetRole> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AspNetRole> GetActive(Expression<Func<AspNetRole, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AspNetRole FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AspNetRole FirstOrDefault(Expression<Func<AspNetRole, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AspNetRole> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AspNetRole> FirstOrDefaultAsync(Expression<Func<AspNetRole, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AspNetRoleService()
		{
			repository = G.TContainer.Resolve<IAspNetRoleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetRoleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
