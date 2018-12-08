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
	public partial interface IEmployeeGroupRepository : IBaseRepository<EmployeeGroup, int>
	{
	}
	
	public partial class EmployeeGroupRepository : BaseRepository<EmployeeGroup, int>, IEmployeeGroupRepository
	{
		public EmployeeGroupRepository(DbContext context) : base(context)
		{
		}
		
		public EmployeeGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeGroup FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeGroup FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeGroup> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeGroup> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeGroup Activate(EmployeeGroup entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeGroup Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeGroup Deactivate(EmployeeGroup entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeGroup Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeGroup> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeGroup> GetActive(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
