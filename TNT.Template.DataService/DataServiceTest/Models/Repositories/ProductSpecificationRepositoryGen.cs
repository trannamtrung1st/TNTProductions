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
	public partial interface IProductSpecificationRepository : IBaseRepository<ProductSpecification, int>
	{
	}
	
	public partial class ProductSpecificationRepository : BaseRepository<ProductSpecification, int>, IProductSpecificationRepository
	{
		public ProductSpecificationRepository(DbContext context) : base(context)
		{
		}
		
		public ProductSpecificationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductSpecification FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductSpecification FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductSpecification> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductSpecification> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductSpecification Activate(ProductSpecification entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductSpecification Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductSpecification Deactivate(ProductSpecification entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductSpecification Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductSpecification> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProductSpecification> GetActive(Expression<Func<ProductSpecification, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
