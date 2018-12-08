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
	public partial interface IProductCategoryRepository : IBaseRepository<ProductCategory, int>
	{
	}
	
	public partial class ProductCategoryRepository : BaseRepository<ProductCategory, int>, IProductCategoryRepository
	{
		public ProductCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public ProductCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CateID == key);
			return entity;
		}
		
		public override ProductCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key);
			return entity;
		}
		
		public override async Task<ProductCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override ProductCategory Activate(ProductCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCategory Deactivate(ProductCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCategory> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCategory> GetActive(Expression<Func<ProductCategory, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
