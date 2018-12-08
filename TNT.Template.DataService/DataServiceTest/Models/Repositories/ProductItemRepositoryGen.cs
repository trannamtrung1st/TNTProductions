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
	public partial interface IProductItemRepository : IBaseRepository<ProductItem, int>
	{
	}
	
	public partial class ProductItemRepository : BaseRepository<ProductItem, int>, IProductItemRepository
	{
		public ProductItemRepository(DbContext context) : base(context)
		{
		}
		
		public ProductItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ItemID == key);
			return entity;
		}
		
		public override ProductItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ItemID == key);
			return entity;
		}
		
		public override async Task<ProductItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key);
			return entity;
		}
		
		public override async Task<ProductItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key);
			return entity;
		}
		
		public override ProductItem Activate(ProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Deactivate(ProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductItem> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<ProductItem> GetActive(Expression<Func<ProductItem, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
