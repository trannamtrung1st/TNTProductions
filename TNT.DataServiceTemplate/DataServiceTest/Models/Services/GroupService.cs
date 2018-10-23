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
	public partial interface IGroupService : IBaseService<Group, GroupViewModel, int>
	{
	}
	
	public partial class GroupService : BaseService, IGroupService
	{
		private IGroupRepository repository;
		
		public GroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGroupRepository>(uow);
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
		public Group Add(Group entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Group> AddAsync(Group entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Group Update(Group entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Group> UpdateAsync(Group entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Group Delete(Group entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Group> DeleteAsync(Group entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Group Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Group> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Group FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Group> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Group Activate(Group entity)
		{
			return repository.Activate(entity);
		}
		
		public Group Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Group Deactivate(Group entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Group Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Group> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Group> GetActive(Expression<Func<Group, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Group FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Group FirstOrDefault(Expression<Func<Group, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Group> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Group> FirstOrDefaultAsync(Expression<Func<Group, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public GroupService()
		{
			repository = G.TContainer.Resolve<IGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~GroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
