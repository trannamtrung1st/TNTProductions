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
	public partial interface IProductComboDetailRepository : IBaseRepository<ProductComboDetail, ProductComboDetailPK>
	{
	}
	
	public partial class ProductComboDetailRepository : BaseRepository<ProductComboDetail, ProductComboDetailPK>, IProductComboDetailRepository
	{
		public ProductComboDetailRepository(DbContext context) : base(context)
		{
		}
		
		public ProductComboDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductComboDetail FindById(ProductComboDetailPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
			return entity;
		}
		
		public override ProductComboDetail FindActiveById(ProductComboDetailPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID && e.Active);
			return entity;
		}
		
		public override async Task<ProductComboDetail> FindByIdAsync(ProductComboDetailPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
			return entity;
		}
		
		public override async Task<ProductComboDetail> FindActiveByIdAsync(ProductComboDetailPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID && e.Active);
			return entity;
		}
		
		public override ProductComboDetail Activate(ProductComboDetail entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductComboDetail Activate(ProductComboDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductComboDetail Deactivate(ProductComboDetail entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductComboDetail Deactivate(ProductComboDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductComboDetail> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductComboDetail> GetActive(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
