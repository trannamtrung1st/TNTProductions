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
	public partial interface IRoleService : IBaseService<Role, RoleViewModel, System.Guid>
	{
	}
	
	public partial class RoleService : BaseService, IRoleService
	{
		private IRoleRepository repository;
		
		public RoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoleRepository>(uow);
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
		public Role Add(Role entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Role> AddAsync(Role entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Role Update(Role entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Role> UpdateAsync(Role entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Role Delete(Role entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Role> DeleteAsync(Role entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Role Delete(System.Guid key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Role> DeleteAsync(System.Guid key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Role FindById(System.Guid key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Role> FindByIdAsync(System.Guid key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Role Activate(Role entity)
		{
			return repository.Activate(entity);
		}
		
		public Role Activate(System.Guid key)
		{
			return repository.Activate(key);
		}
		
		public Role Deactivate(Role entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Role Deactivate(System.Guid key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Role> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Role> GetActive(Expression<Func<Role, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Role FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Role FirstOrDefault(Expression<Func<Role, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Role> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Role> FirstOrDefaultAsync(Expression<Func<Role, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RoleService()
		{
			repository = G.TContainer.Resolve<IRoleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
