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
	public partial interface IProductCollectionRepository : IBaseRepository<ProductCollection, int>
	{
	}
	
	public partial class ProductCollectionRepository : BaseRepository<ProductCollection, int>, IProductCollectionRepository
	{
		public ProductCollectionRepository(DbContext context) : base(context)
		{
		}
		
		public ProductCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCollection FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductCollection FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCollection> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductCollection> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductCollection Activate(ProductCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCollection Deactivate(ProductCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCollection> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCollection> GetActive(Expression<Func<ProductCollection, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
