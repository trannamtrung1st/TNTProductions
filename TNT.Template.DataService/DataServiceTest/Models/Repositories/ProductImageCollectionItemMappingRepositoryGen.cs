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
	public partial interface IProductImageCollectionItemMappingRepository : IBaseRepository<ProductImageCollectionItemMapping, int>
	{
	}
	
	public partial class ProductImageCollectionItemMappingRepository : BaseRepository<ProductImageCollectionItemMapping, int>, IProductImageCollectionItemMappingRepository
	{
		public ProductImageCollectionItemMappingRepository(DbContext context) : base(context)
		{
		}
		
		public ProductImageCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductImageCollectionItemMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductImageCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductImageCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping Activate(ProductImageCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductImageCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductImageCollectionItemMapping Deactivate(ProductImageCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductImageCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductImageCollectionItemMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductImageCollectionItemMapping> GetActive(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
