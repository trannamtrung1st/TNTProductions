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
	public partial interface IEmployeeGroupService : IBaseService<EmployeeGroup, EmployeeGroupViewModel, int>
	{
	}
	
	public partial class EmployeeGroupService : BaseService, IEmployeeGroupService
	{
		private IEmployeeGroupRepository repository;
		
		public EmployeeGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeGroupRepository>(uow);
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
		public EmployeeGroup Add(EmployeeGroup entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<EmployeeGroup> AddAsync(EmployeeGroup entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public EmployeeGroup Update(EmployeeGroup entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<EmployeeGroup> UpdateAsync(EmployeeGroup entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public EmployeeGroup Delete(EmployeeGroup entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<EmployeeGroup> DeleteAsync(EmployeeGroup entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public EmployeeGroup Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<EmployeeGroup> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public EmployeeGroup FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<EmployeeGroup> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public EmployeeGroup Activate(EmployeeGroup entity)
		{
			return repository.Activate(entity);
		}
		
		public EmployeeGroup Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public EmployeeGroup Deactivate(EmployeeGroup entity)
		{
			return repository.Deactivate(entity);
		}
		
		public EmployeeGroup Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<EmployeeGroup> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<EmployeeGroup> GetActive(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public EmployeeGroup FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public EmployeeGroup FirstOrDefault(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<EmployeeGroup> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<EmployeeGroup> FirstOrDefaultAsync(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public EmployeeGroupService()
		{
			repository = G.TContainer.Resolve<IEmployeeGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
