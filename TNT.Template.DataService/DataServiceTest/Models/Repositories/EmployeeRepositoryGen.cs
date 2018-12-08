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
		public EmployeeRepository(DbContext context) : base(context)
		{
		}
		
		public EmployeeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Employee FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Employee FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Employee> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Employee> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Employee> GetActive(Expression<Func<Employee, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
