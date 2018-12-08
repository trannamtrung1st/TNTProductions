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
	public partial interface IEmployeeFingerRepository : IBaseRepository<EmployeeFinger, int>
	{
	}
	
	public partial class EmployeeFingerRepository : BaseRepository<EmployeeFinger, int>, IEmployeeFingerRepository
	{
		public EmployeeFingerRepository(DbContext context) : base(context)
		{
		}
		
		public EmployeeFingerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeFinger FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeFinger FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeFinger> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeFinger> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeFinger Activate(EmployeeFinger entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeFinger Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeFinger Deactivate(EmployeeFinger entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeFinger Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeFinger> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeFinger> GetActive(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
