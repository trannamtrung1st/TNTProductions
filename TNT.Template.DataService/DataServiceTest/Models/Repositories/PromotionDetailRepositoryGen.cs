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
	public partial interface IPromotionDetailRepository : IBaseRepository<PromotionDetail, int>
	{
	}
	
	public partial class PromotionDetailRepository : BaseRepository<PromotionDetail, int>, IPromotionDetailRepository
	{
		public PromotionDetailRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionDetail FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override PromotionDetail FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override PromotionDetail Activate(PromotionDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Deactivate(PromotionDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionDetail> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PromotionDetail> GetActive(Expression<Func<PromotionDetail, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
