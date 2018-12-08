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
	public partial interface IProductImageCollectionRepository : IBaseRepository<ProductImageCollection, int>
	{
	}
	
	public partial class ProductImageCollectionRepository : BaseRepository<ProductImageCollection, int>, IProductImageCollectionRepository
	{
		public ProductImageCollectionRepository(DbContext context) : base(context)
		{
		}
		
		public ProductImageCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductImageCollection FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductImageCollection FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductImageCollection> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductImageCollection> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductImageCollection Activate(ProductImageCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductImageCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductImageCollection Deactivate(ProductImageCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductImageCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductImageCollection> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductImageCollection> GetActive(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
