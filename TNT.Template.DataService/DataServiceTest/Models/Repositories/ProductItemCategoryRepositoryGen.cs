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
	public partial interface IProductItemCategoryRepository : IBaseRepository<ProductItemCategory, int>
	{
	}
	
	public partial class ProductItemCategoryRepository : BaseRepository<ProductItemCategory, int>, IProductItemCategoryRepository
	{
		public ProductItemCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public ProductItemCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItemCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CateID == key);
			return entity;
		}
		
		public override ProductItemCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductItemCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key);
			return entity;
		}
		
		public override async Task<ProductItemCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override ProductItemCategory Activate(ProductItemCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductItemCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductItemCategory Deactivate(ProductItemCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductItemCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductItemCategory> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductItemCategory> GetActive(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
