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
	public partial interface IEmployeeFingerService : IBaseService<EmployeeFinger, EmployeeFingerViewModel, int>
	{
	}
	
	public partial class EmployeeFingerService : BaseService, IEmployeeFingerService
	{
		private IEmployeeFingerRepository repository;
		
		public EmployeeFingerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeFingerRepository>(uow);
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
		public EmployeeFinger Add(EmployeeFinger entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<EmployeeFinger> AddAsync(EmployeeFinger entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public EmployeeFinger Update(EmployeeFinger entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<EmployeeFinger> UpdateAsync(EmployeeFinger entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public EmployeeFinger Delete(EmployeeFinger entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<EmployeeFinger> DeleteAsync(EmployeeFinger entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public EmployeeFinger Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<EmployeeFinger> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public EmployeeFinger FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<EmployeeFinger> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public EmployeeFinger Activate(EmployeeFinger entity)
		{
			return repository.Activate(entity);
		}
		
		public EmployeeFinger Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public EmployeeFinger Deactivate(EmployeeFinger entity)
		{
			return repository.Deactivate(entity);
		}
		
		public EmployeeFinger Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<EmployeeFinger> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<EmployeeFinger> GetActive(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public EmployeeFinger FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public EmployeeFinger FirstOrDefault(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<EmployeeFinger> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<EmployeeFinger> FirstOrDefaultAsync(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public EmployeeFingerService()
		{
			repository = G.TContainer.Resolve<IEmployeeFingerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeFingerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
