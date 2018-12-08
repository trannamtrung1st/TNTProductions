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
				e => e.PromotionDetailId == key);
			return entity;
		}
		
		public override PromotionDetail FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionDetailId == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailId == key);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailId == key && e.Active);
			return entity;
		}
		
		public override PromotionDetail Activate(PromotionDetail entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionDetail Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionDetail Deactivate(PromotionDetail entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionDetail Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionDetail> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionDetail> GetActive(Expression<Func<PromotionDetail, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
