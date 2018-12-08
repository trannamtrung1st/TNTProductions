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
	public partial interface IEmployeeInStoreRepository : IBaseRepository<EmployeeInStore, int>
	{
	}
	
	public partial class EmployeeInStoreRepository : BaseRepository<EmployeeInStore, int>, IEmployeeInStoreRepository
	{
		public EmployeeInStoreRepository(DbContext context) : base(context)
		{
		}
		
		public EmployeeInStoreRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeInStore FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeInStore FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeInStore> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeInStore> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeInStore Activate(EmployeeInStore entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeInStore Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeInStore Deactivate(EmployeeInStore entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeInStore Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeInStore> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeInStore> GetActive(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
