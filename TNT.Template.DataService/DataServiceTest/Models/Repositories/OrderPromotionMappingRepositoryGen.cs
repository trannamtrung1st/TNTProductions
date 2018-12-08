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
	public partial interface IOrderPromotionMappingRepository : IBaseRepository<OrderPromotionMapping, int>
	{
	}
	
	public partial class OrderPromotionMappingRepository : BaseRepository<OrderPromotionMapping, int>, IOrderPromotionMappingRepository
	{
		public OrderPromotionMappingRepository(DbContext context) : base(context)
		{
		}
		
		public OrderPromotionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderPromotionMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderPromotionMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override OrderPromotionMapping Activate(OrderPromotionMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override OrderPromotionMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override OrderPromotionMapping Deactivate(OrderPromotionMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override OrderPromotionMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<OrderPromotionMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<OrderPromotionMapping> GetActive(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
