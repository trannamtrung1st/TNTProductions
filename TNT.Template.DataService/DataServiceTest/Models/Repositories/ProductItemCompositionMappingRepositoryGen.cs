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
	public partial interface IProductItemCompositionMappingRepository : IBaseRepository<ProductItemCompositionMapping, ProductItemCompositionMappingPK>
	{
	}
	
	public partial class ProductItemCompositionMappingRepository : BaseRepository<ProductItemCompositionMapping, ProductItemCompositionMappingPK>, IProductItemCompositionMappingRepository
	{
		public ProductItemCompositionMappingRepository(DbContext context) : base(context)
		{
		}
		
		public ProductItemCompositionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItemCompositionMapping FindById(ProductItemCompositionMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override ProductItemCompositionMapping FindActiveById(ProductItemCompositionMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> FindByIdAsync(ProductItemCompositionMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> FindActiveByIdAsync(ProductItemCompositionMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override ProductItemCompositionMapping Activate(ProductItemCompositionMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Activate(ProductItemCompositionMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Deactivate(ProductItemCompositionMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Deactivate(ProductItemCompositionMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductItemCompositionMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<ProductItemCompositionMapping> GetActive(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
