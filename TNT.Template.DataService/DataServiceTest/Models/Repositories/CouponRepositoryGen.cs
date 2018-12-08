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
	public partial interface ICouponRepository : IBaseRepository<Coupon, int>
	{
	}
	
	public partial class CouponRepository : BaseRepository<Coupon, int>, ICouponRepository
	{
		public CouponRepository(DbContext context) : base(context)
		{
		}
		
		public CouponRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Coupon FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Coupon FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Coupon> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Coupon> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Coupon Activate(Coupon entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Deactivate(Coupon entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Coupon> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Coupon> GetActive(Expression<Func<Coupon, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
