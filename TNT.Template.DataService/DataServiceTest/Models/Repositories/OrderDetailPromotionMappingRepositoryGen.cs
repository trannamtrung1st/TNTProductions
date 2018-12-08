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
	public partial interface IOrderDetailPromotionMappingRepository : IBaseRepository<OrderDetailPromotionMapping, int>
	{
	}
	
	public partial class OrderDetailPromotionMappingRepository : BaseRepository<OrderDetailPromotionMapping, int>, IOrderDetailPromotionMappingRepository
	{
		public OrderDetailPromotionMappingRepository(DbContext context) : base(context)
		{
		}
		
		public OrderDetailPromotionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderDetailPromotionMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderDetailPromotionMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<OrderDetailPromotionMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderDetailPromotionMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override OrderDetailPromotionMapping Activate(OrderDetailPromotionMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override OrderDetailPromotionMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override OrderDetailPromotionMapping Deactivate(OrderDetailPromotionMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override OrderDetailPromotionMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<OrderDetailPromotionMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<OrderDetailPromotionMapping> GetActive(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
