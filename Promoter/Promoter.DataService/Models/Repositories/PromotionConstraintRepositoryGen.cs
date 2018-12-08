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
	public partial interface IPromotionConstraintRepository : IBaseRepository<PromotionConstraint, int>
	{
	}
	
	public partial class PromotionConstraintRepository : BaseRepository<PromotionConstraint, int>, IPromotionConstraintRepository
	{
		public PromotionConstraintRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionConstraintRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionConstraint FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ConstraintId == key);
			return entity;
		}
		
		public override PromotionConstraint FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ConstraintId == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionConstraint> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ConstraintId == key);
			return entity;
		}
		
		public override async Task<PromotionConstraint> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ConstraintId == key && e.Active);
			return entity;
		}
		
		public override PromotionConstraint Activate(PromotionConstraint entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionConstraint Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionConstraint Deactivate(PromotionConstraint entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionConstraint Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionConstraint> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionConstraint> GetActive(Expression<Func<PromotionConstraint, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
