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
	public partial interface ICouponCampaignRepository : IBaseRepository<CouponCampaign, int>
	{
	}
	
	public partial class CouponCampaignRepository : BaseRepository<CouponCampaign, int>, ICouponCampaignRepository
	{
		public CouponCampaignRepository(DbContext context) : base(context)
		{
		}
		
		public CouponCampaignRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CouponCampaign FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponCampaign FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponCampaign> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponCampaign> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponCampaign Activate(CouponCampaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Deactivate(CouponCampaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CouponCampaign> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<CouponCampaign> GetActive(Expression<Func<CouponCampaign, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
