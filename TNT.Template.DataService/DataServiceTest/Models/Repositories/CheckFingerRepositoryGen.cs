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
	public partial interface ICheckFingerRepository : IBaseRepository<CheckFinger, int>
	{
	}
	
	public partial class CheckFingerRepository : BaseRepository<CheckFinger, int>, ICheckFingerRepository
	{
		public CheckFingerRepository(DbContext context) : base(context)
		{
		}
		
		public CheckFingerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CheckFinger FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CheckFinger FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<CheckFinger> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CheckFinger> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override CheckFinger Activate(CheckFinger entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CheckFinger Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CheckFinger Deactivate(CheckFinger entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CheckFinger Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CheckFinger> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<CheckFinger> GetActive(Expression<Func<CheckFinger, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
