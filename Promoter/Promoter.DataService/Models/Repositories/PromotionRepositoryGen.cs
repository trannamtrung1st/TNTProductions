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
	public partial interface IPromotionRepository : IBaseRepository<Promotion, int>
	{
	}
	
	public partial class PromotionRepository : BaseRepository<Promotion, int>, IPromotionRepository
	{
		public PromotionRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Promotion FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionId == key);
			return entity;
		}
		
		public override Promotion FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PromotionId == key && e.Active);
			return entity;
		}
		
		public override async Task<Promotion> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionId == key);
			return entity;
		}
		
		public override async Task<Promotion> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PromotionId == key && e.Active);
			return entity;
		}
		
		public override Promotion Activate(Promotion entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Promotion Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Promotion Deactivate(Promotion entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Promotion Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Promotion> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Promotion> GetActive(Expression<Func<Promotion, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
