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
		public ProductComboDetailRepository() : base()
		{
		}
		
		public ProductComboDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductComboDetail Add(ProductComboDetail entity)
		{
			entity.Active = true;
			entity = context.ProductComboDetails.Add(entity);
			return entity;
		}
		
		public override ProductComboDetail Remove(ProductComboDetail entity)
		{
			context.ProductComboDetails.Attach(entity);
			entity = context.ProductComboDetails.Remove(entity);
			return entity;
		}
		
		public override ProductComboDetail Remove(ProductComboDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductComboDetails.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ProductComboDetail> RemoveIf(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return context.ProductComboDetails.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ProductComboDetail> RemoveRange(IEnumerable<ProductComboDetail> list)
		{
			return context.ProductComboDetails.RemoveRange(list);
		}
		
		public override ProductComboDetail FindById(ProductComboDetailPK key)
		{
			var entity = context.ProductComboDetails.FirstOrDefault(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
			return entity;
		}
		
		public override ProductComboDetail FindActiveById(ProductComboDetailPK key)
		{
			var entity = context.ProductComboDetails.FirstOrDefault(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID && e.Active);
			return entity;
		}
		
		public override async Task<ProductComboDetail> FindByIdAsync(ProductComboDetailPK key)
		{
			var entity = await context.ProductComboDetails.FirstOrDefaultAsync(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
			return entity;
		}
		
		public override async Task<ProductComboDetail> FindActiveByIdAsync(ProductComboDetailPK key)
		{
			var entity = await context.ProductComboDetails.FirstOrDefaultAsync(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID && e.Active);
			return entity;
		}
		
		public override ProductComboDetail FindByIdInclude<TProperty>(ProductComboDetailPK key, params Expression<Func<ProductComboDetail, TProperty>>[] members)
		{
			IQueryable<ProductComboDetail> dbSet = context.ProductComboDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
		}
		
		public override async Task<ProductComboDetail> FindByIdIncludeAsync<TProperty>(ProductComboDetailPK key, params Expression<Func<ProductComboDetail, TProperty>>[] members)
		{
			IQueryable<ProductComboDetail> dbSet = context.ProductComboDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ComboID == key.ComboID && e.ProductID == key.ProductID);
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
			return context.ProductComboDetails.Where(e => e.Active);
		}
		
		public override IQueryable<ProductComboDetail> GetActive(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return context.ProductComboDetails.Where(e => e.Active).Where(expr);
		}
		
		public override ProductComboDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductComboDetail FirstOrDefault(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductComboDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductComboDetail> FirstOrDefaultAsync(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductComboDetail SingleOrDefault(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductComboDetail> SingleOrDefaultAsync(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductComboDetail Update(ProductComboDetail entity)
		{
			entity = context.ProductComboDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
