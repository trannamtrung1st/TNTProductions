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
	public partial interface IPromotionAwardDiscountRepository : IBaseRepository<PromotionAwardDiscount, int>
	{
	}
	
	public partial class PromotionAwardDiscountRepository : BaseRepository<PromotionAwardDiscount, int>, IPromotionAwardDiscountRepository
	{
		public PromotionAwardDiscountRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionAwardDiscountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionAwardDiscount FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override PromotionAwardDiscount FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionAwardDiscount> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key);
			return entity;
		}
		
		public override async Task<PromotionAwardDiscount> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAwardId == key && e.Active);
			return entity;
		}
		
		public override PromotionAwardDiscount Activate(PromotionAwardDiscount entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionAwardDiscount Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionAwardDiscount Deactivate(PromotionAwardDiscount entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionAwardDiscount Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionAwardDiscount> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionAwardDiscount> GetActive(Expression<Func<PromotionAwardDiscount, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
