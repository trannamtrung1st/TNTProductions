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
	public partial interface IProductDetailMappingRepository : IBaseRepository<ProductDetailMapping, int>
	{
	}
	
	public partial class ProductDetailMappingRepository : BaseRepository<ProductDetailMapping, int>, IProductDetailMappingRepository
	{
		public ProductDetailMappingRepository(DbContext context) : base(context)
		{
		}
		
		public ProductDetailMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductDetailMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override ProductDetailMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override async Task<ProductDetailMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override async Task<ProductDetailMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override ProductDetailMapping Activate(ProductDetailMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Deactivate(ProductDetailMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductDetailMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<ProductDetailMapping> GetActive(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
