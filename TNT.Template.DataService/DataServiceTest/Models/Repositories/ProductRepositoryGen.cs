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
	public partial interface IProductRepository : IBaseRepository<Product, int>
	{
	}
	
	public partial class ProductRepository : BaseRepository<Product, int>, IProductRepository
	{
		public ProductRepository(DbContext context) : base(context)
		{
		}
		
		public ProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Product FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProductID == key);
			return entity;
		}
		
		public override Product FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProductID == key && e.Active);
			return entity;
		}
		
		public override async Task<Product> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProductID == key);
			return entity;
		}
		
		public override async Task<Product> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProductID == key && e.Active);
			return entity;
		}
		
		public override Product Activate(Product entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Product Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Product Deactivate(Product entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Product Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Product> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Product> GetActive(Expression<Func<Product, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
