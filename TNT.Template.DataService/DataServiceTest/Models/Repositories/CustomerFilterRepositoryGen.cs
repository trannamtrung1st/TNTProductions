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
	public partial interface ICustomerFilterRepository : IBaseRepository<CustomerFilter, int>
	{
	}
	
	public partial class CustomerFilterRepository : BaseRepository<CustomerFilter, int>, ICustomerFilterRepository
	{
		public CustomerFilterRepository(DbContext context) : base(context)
		{
		}
		
		public CustomerFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerFilter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerFilter FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<CustomerFilter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerFilter> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override CustomerFilter Activate(CustomerFilter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CustomerFilter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CustomerFilter Deactivate(CustomerFilter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CustomerFilter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CustomerFilter> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<CustomerFilter> GetActive(Expression<Func<CustomerFilter, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
