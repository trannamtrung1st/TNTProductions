using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IEmployeeRepository : IBaseRepository<Employee, int>
	{
	}
	
	public partial class EmployeeRepository : BaseRepository<Employee, int>, IEmployeeRepository
	{
		public EmployeeRepository() : base()
		{
		}
		
		public EmployeeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Employee Add(Employee entity)
		{
			entity.Active = true;
			entity = context.Employees.Add(entity);
			return entity;
		}
		
		public override Employee Remove(Employee entity)
		{
			context.Employees.Attach(entity);
			entity = context.Employees.Remove(entity);
			return entity;
		}
		
		public override Employee Remove(int key)
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
		
		public override Employee FindById(int key)
		{
			var entity = context.Employees.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Employee FindActiveById(int key)
		{
			var entity = context.Employees.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Employee> FindByIdAsync(int key)
		{
			var entity = await context.Employees.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Employee> FindActiveByIdAsync(int key)
		{
			var entity = await context.Employees.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Employee FindByIdInclude<TProperty>(int key, params Expression<Func<Employee, TProperty>>[] members)
		{
			IQueryable<Employee> dbSet = context.Employees;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Employee> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Employee, TProperty>>[] members)
		{
			IQueryable<Employee> dbSet = context.Employees;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Employee Activate(Employee entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Employee Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Employee Deactivate(Employee entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Employee Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Employee> GetActive()
		{
			return context.Employees.Where(e => e.Active);
		}
		
		public override IQueryable<Employee> GetActive(Expression<Func<Employee, bool>> expr)
		{
			return context.Employees.Where(e => e.Active).Where(expr);
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
