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
	public partial interface IPromotionAwardGiftRepository : IBaseRepository<PromotionAwardGift, int>
	{
	}
	
	public partial class PromotionAwardGiftRepository : BaseRepository<PromotionAwardGift, int>, IPromotionAwardGiftRepository
	{
		public PromotionAwardGiftRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionAwardGiftRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionAwardGift FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override PromotionAwardGift FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionAwardGift> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override async Task<PromotionAwardGift> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override PromotionAwardGift Activate(PromotionAwardGift entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionAwardGift Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionAwardGift Deactivate(PromotionAwardGift entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionAwardGift Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionAwardGift> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionAwardGift> GetActive(Expression<Func<PromotionAwardGift, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
