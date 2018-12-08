using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IPromotionAwardCashbackRepository : IBaseRepository<PromotionAwardCashback, int>
	{
	}
	
	public partial class PromotionAwardCashbackRepository : BaseRepository<PromotionAwardCashback, int>, IPromotionAwardCashbackRepository
	{
		public PromotionAwardCashbackRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionAwardCashbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionAwardCashback FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override PromotionAwardCashback FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionAwardCashback> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override async Task<PromotionAwardCashback> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override PromotionAwardCashback Activate(PromotionAwardCashback entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionAwardCashback Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionAwardCashback Deactivate(PromotionAwardCashback entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionAwardCashback Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionAwardCashback> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionAwardCashback> GetActive(Expression<Func<PromotionAwardCashback, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
