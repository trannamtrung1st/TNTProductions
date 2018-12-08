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
	public partial interface IPromotionStoreMappingRepository : IBaseRepository<PromotionStoreMapping, int>
	{
	}
	
	public partial class PromotionStoreMappingRepository : BaseRepository<PromotionStoreMapping, int>, IPromotionStoreMappingRepository
	{
		public PromotionStoreMappingRepository(DbContext context) : base(context)
		{
		}
		
		public PromotionStoreMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionStoreMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PromotionStoreMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionStoreMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PromotionStoreMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PromotionStoreMapping Activate(PromotionStoreMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionStoreMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionStoreMapping Deactivate(PromotionStoreMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionStoreMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionStoreMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionStoreMapping> GetActive(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
