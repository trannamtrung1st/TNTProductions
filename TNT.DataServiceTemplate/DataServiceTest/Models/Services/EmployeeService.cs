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
	public partial interface IEmployeeService : IBaseService<Employee, EmployeeViewModel, int>
	{
	}
	
	public partial class EmployeeService : BaseService, IEmployeeService
	{
		private IEmployeeRepository repository;
		
		public EmployeeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeRepository>(uow);
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
		public Employee Add(Employee entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Employee> AddAsync(Employee entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Employee Update(Employee entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Employee> UpdateAsync(Employee entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Employee Delete(Employee entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Employee> DeleteAsync(Employee entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Employee Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Employee> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Employee FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Employee> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Employee Activate(Employee entity)
		{
			return repository.Activate(entity);
		}
		
		public Employee Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Employee Deactivate(Employee entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Employee Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Employee> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Employee> GetActive(Expression<Func<Employee, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Employee FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Employee FirstOrDefault(Expression<Func<Employee, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Employee> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Employee> FirstOrDefaultAsync(Expression<Func<Employee, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public EmployeeService()
		{
			repository = G.TContainer.Resolve<IEmployeeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
