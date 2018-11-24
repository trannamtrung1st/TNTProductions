using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TestDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface IEmployeeRepository : IBaseRepository<Employee, string>
	{
	}
	
	public partial class EmployeeRepository : BaseRepository<Employee, string>, IEmployeeRepository
	{
		public EmployeeRepository(EmployeeManagerEntities context) : base(context)
		{
		}
		
		public EmployeeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Employee Add(Employee entity)
		{
			
			entity = context.Employees.Add(entity);
			return entity;
		}
		
		public override Employee Remove(Employee entity)
		{
			context.Employees.Attach(entity);
			entity = context.Employees.Remove(entity);
			return entity;
		}
		
		public override Employee Remove(string key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Employees.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Employee> RemoveIf(Expression<Func<Employee, bool>> expr)
		{
			return context.Employees.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Employee> RemoveRange(IEnumerable<Employee> list)
		{
			return context.Employees.RemoveRange(list);
		}
		
		public override Employee FindById(string key)
		{
			var entity = context.Employees.FirstOrDefault(
				e => e.EmpCode == key);
			return entity;
		}
		
		public override Employee FindActiveById(string key)
		{
			var entity = context.Employees.FirstOrDefault(
				e => e.EmpCode == key);
			return entity;
		}
		
		public override async Task<Employee> FindByIdAsync(string key)
		{
			var entity = await context.Employees.FirstOrDefaultAsync(
				e => e.EmpCode == key);
			return entity;
		}
		
		public override async Task<Employee> FindActiveByIdAsync(string key)
		{
			var entity = await context.Employees.FirstOrDefaultAsync(
				e => e.EmpCode == key);
			return entity;
		}
		
		public override Employee FindByIdInclude<TProperty>(string key, params Expression<Func<Employee, TProperty>>[] members)
		{
			IQueryable<Employee> dbSet = context.Employees;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.EmpCode == key);
		}
		
		public override async Task<Employee> FindByIdIncludeAsync<TProperty>(string key, params Expression<Func<Employee, TProperty>>[] members)
		{
			IQueryable<Employee> dbSet = context.Employees;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.EmpCode == key);
		}
		
		public override Employee Activate(Employee entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Employee Activate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Employee Deactivate(Employee entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Employee Deactivate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Employee> GetActive()
		{
			return context.Employees;
		}
		
		public override IQueryable<Employee> GetActive(Expression<Func<Employee, bool>> expr)
		{
			return context.Employees.Where(expr);
		}
		
		public override Employee FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Employee FirstOrDefault(Expression<Func<Employee, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Employee> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Employee> FirstOrDefaultAsync(Expression<Func<Employee, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Employee SingleOrDefault(Expression<Func<Employee, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Employee> SingleOrDefaultAsync(Expression<Func<Employee, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Employee Update(Employee entity)
		{
			entity = context.Employees.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
