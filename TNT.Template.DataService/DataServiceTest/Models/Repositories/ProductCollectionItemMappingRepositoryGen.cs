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
	public partial interface IProductCollectionItemMappingRepository : IBaseRepository<ProductCollectionItemMapping, int>
	{
	}
	
	public partial class ProductCollectionItemMappingRepository : BaseRepository<ProductCollectionItemMapping, int>, IProductCollectionItemMappingRepository
	{
		public ProductCollectionItemMappingRepository(DbContext context) : base(context)
		{
		}
		
		public ProductCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCollectionItemMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductCollectionItemMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductCollectionItemMapping Activate(ProductCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCollectionItemMapping Deactivate(ProductCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCollectionItemMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCollectionItemMapping> GetActive(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
