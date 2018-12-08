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
	public partial interface ICouponProviderRepository : IBaseRepository<CouponProvider, int>
	{
	}
	
	public partial class CouponProviderRepository : BaseRepository<CouponProvider, int>, ICouponProviderRepository
	{
		public CouponProviderRepository(DbContext context) : base(context)
		{
		}
		
		public CouponProviderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CouponProvider FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponProvider FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponProvider> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponProvider> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponProvider Activate(CouponProvider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Deactivate(CouponProvider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CouponProvider> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<CouponProvider> GetActive(Expression<Func<CouponProvider, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
